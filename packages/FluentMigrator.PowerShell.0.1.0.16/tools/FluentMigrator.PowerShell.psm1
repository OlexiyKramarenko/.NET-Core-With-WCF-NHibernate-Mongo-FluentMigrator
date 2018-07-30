<#    
    .SYNOPSIS
    This module allows easier management of FluentMigrator inside of a Visual Studio Solution.

    .DESCRIPTION
    This module is a wrapper for the migrate.exe of the FluentMigrator project. (https://github.com/schambers/fluentmigrator/wiki/Command-Line-Runner-Options)
#>

Add-Type -TypeDefinition @"
   public enum DatabaseProvider
   {
      SqlServer2000,
      SqlServer2005,
      SqlServer2008,
      SqlServer2012,
      SqlServerce,
      SqlServer,
      MySql,
      PostGres,
      Oracle,
      SQLite,
      Jet
   }
"@

function GetMigratePath
{
    [CmdletBinding()]
    PARAM(
        $provider,
        [switch]
        $WhatIf = $False
    )
    
    $packagesPath = ".\packages";
    if (Test-Path .\.nuget\NuGet.config)
    {
        [xml]$nugetConfig = Get-Content .\.nuget\NuGet.config;
        $repositoryPath = $nugetConfig.SelectSingleNode("/configuration/config/add[@key='repositoryPath']")
        if ($repositoryPath -ne $null)
        {
            $packagesPath = Resolve-Path (Join-Path ".nuget" $repositoryPath.value)
        }
    }

    $migrateExe = ((Get-ChildItem $packagesPath -Recurse "migrate.exe") | where { $_.FullName -match "FluentMigrator.\d+.\d+.\d+(.\d+)?\\tools" }) | Sort-Object -Property FullName -Descending;
    if ($migrateExe -eq $null)
    {
        throw "Couldn't find migrate.exe anywhere. (Searched {0})" -f $packagesPath;
    }
    $migrateExePath = $migrateExe[0].FullName;

    $architecture = "x86";
    if ($env:PROCESSOR_ARCHITECTURE -match "64")
    {
        $architecture = "AnyCPU";
    }

    $version = "40";
    if ($PSVersionTable.CLRVersion.Major -lt 4)
    {
        $version = "35";
    }
    
    Write-Verbose "Looking for FluentMigrator.Runner.dll for architecture '$architecture' and CLR version '$version'.";
    # The default assembly works for x86, version 4.0. No need to copy anything.
    if ($architecture -eq "x86" -and $version -eq "40")
    {
        $fluentRunnerPath = ((Get-ChildItem $packagesPath -Recurse "FluentMigrator.Runner.dll") | where { $_.FullName -match "FluentMigrator.\d+.\d+.\d+(.\d+)?\\tools" }).FullName;
    }
    else
    {
        $fluentRunnerPath = ((Get-ChildItem $packagesPath -Recurse "FluentMigrator.Runner.dll") | where { $_.FullName -match "FluentMigrator.Tools.\d+.\d+.\d+(.\d+)?\\tools\\$architecture\\$version" }).FullName;
        $copyTo = Join-Path (Split-Path $migrateExePath) "FluentMigrator.Runner.dll";
        if ($WhatIf)
        {
            Write-Debug ("WHATIF: Would copy '{0}' to '{1}'" -f $fluentRunnerPath, $copyTo);
        }
        elseif ($fluentRunnerPath -eq $null)
        {
            Write-Warning "Couldn't find FluentMigrator.Runner.dll for architecture $architecture and version $version. Please install FluentMigrator.Tools. Will try to continue anyway!";
        }
        else
        {
            Copy-Item $fluentRunnerPath $copyTo "FluentMigrator.Runner.dll" -Force;
        }
    }
        
    if ($provider -eq "PostGres")
    {
        # Load Npgsql DLL because we will need it later!
        $npgsqlPath = (Join-Path (Split-Path $fluentRunnerPath) "Npgsql.dll");
        if ($WhatIf)
        {
            Write-Debug ("WHATIF: Would load PostGreSQL DLL at '{0}'" -f $npgsqlPath);
        }
        else
        {
            $assembly = [System.Reflection.Assembly]::LoadFrom($npgsqlPath);
        }
    }
    elseif ($provider -eq "SQLite")
    {
        # Load SQLite DLL because we will need it later!
        $sqlitePath = (Join-Path (Split-Path $fluentRunnerPath) "System.Data.SQLite");
        if ($WhatIf)
        {
            Write-Debug ("WHATIF: Would load SQLite DLL at '{0}'" -f $sqlitePath);
        }
        else
        {
            $assembly = [System.Reflection.Assembly]::LoadFrom($sqlitePath);
        }
    }

    return $migrateExePath;
}

function Coalesce($a, $b)
{
    if ($a)
    {
        return $a;
    }
    else
    {
        return $b;
    }
}

function ExecuteMigrateCommand
{
    [CmdletBinding()]
    PARAM(
        $Task,
        $Assembly,
        $Provider,
        $ConnectionString,
        $ConnectionStringName,
        $ConnectionStringConfigurationPath,
        $Namespace,
        $Nested,
        $TransactionPerSession,
        $Timeout,
        $WorkingDirectory,
        $Tag,
        $Context,
        $Profile,
        $Version,
        $Preview,
        $Steps,
        $Output,
        $OutputFileName,
        $DeleteBeforeMigrating,
        $Assemblies,
        [switch]
        $WhatIf = $False,
        [switch]
        $DoNotKillExistingConnections = $False
    )

    if ($WhatIf)
    {
        Set-Variable -Name DebugPreference -Value 'Continue'
    }

    if ($Assemblies)
    {
        foreach ($assembly in $Assemblies)
        {
            Write-Output "Executing task for $($assembly.Assembly)";
            ExecuteMigrateCommand `
                $Task `
                $assembly.Assembly `
                $assembly.Provider `
                $assembly.ConnectionString `
                $assembly.ConnectionStringName `
                $assembly.ConnectionStringConfigurationPath `
                $assembly.Namespace `
                $assembly.Nested `
                (Coalesce $assembly.TransactionPerSession $TransactionPerSession) `
                (Coalesce $assembly.Timeout $Timeout) `
                (Coalesce $assembly.WorkingDirectory $WorkingDirectory) `
                (Coalesce $assembly.Tag $Tag) `
                (Coalesce $assembly.Context $Context) `
                (Coalesce $assembly.Profile $Profile) `
                (Coalesce $assembly.Version $Version) `
                (Coalesce $assembly.Preview $Preview) `
                (Coalesce $assembly.Steps $Steps) `
                (Coalesce $assembly.Output $Output) `
                (Coalesce $assembly.OutputFileName $OutputFileName) `
                (Coalesce $assembly.DeleteBeforeMigrating $DeleteBeforeMigrating) `
                $null `
                -WhatIf:$WhatIf;
        }

        return; // If running a list of assemblies, cannot run only one.
    }
    
    # Called first because it loads managed DLLs for the specified provider.
    $migrateExePath = GetMigratePath $Provider -WhatIf:$WhatIf;

    if ($Task -eq "migrate:up")
    {
        if (!$DoNotKillExistingConnections)
        {
            KillAllConnections $ConnectionString $ConnectionStringName $ConnectionStringConfigurationPath $Provider -WhatIf:$WhatIf;
        }
        if ($DeleteBeforeMigrating)
        {
            DeleteDatabase $ConnectionString $ConnectionStringName $ConnectionStringConfigurationPath $Provider -WhatIf:$WhatIf;
        }
        CreateDatabaseIfNecessary $ConnectionString $ConnectionStringName $ConnectionStringConfigurationPath $Provider -WhatIf:$WhatIf;
    }
    elseif ($Task.StartsWith("rollback"))
    {
        if ($All)
        {
            $Task = "rollback:all";
        }
        elseif ($Version)
        {
            $Task = "rollback:toversion";
        }
    }

    $parameters = "--task $Task";
    $isVerbose = $PSCmdlet.MyInvocation.BoundParameters -and $PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent;
    if ($isVerbose)
    {
        $parameters += " --verbose true";
    }
    if ($Namespace)
    {
        $parameters += " --namespace:`"$Namespace`"";
    }
    if ($Nested)
    {
        $parameters += " --nested";
    }
    if ($TransactionPerSession)
    {
        $parameters += " --transaction-per-session";
    }
    if ($Timeout)
    {
        $parameters += " --timeout:$Timeout";
    }
    if ($WorkingDirectory)
    {
        $parameters += " --workingdirectory:`"$WorkingDirectory`"";
    }
    if ($Tag)
    {
        $parameters += " --tag:`"$Tag`"";
    }
    if ($Context)
    {
        $parameters += " --context:`"$Context`"";
    }
    if ($Profile)
    {
        $parameters += " --profile:`"$Profile`"";
    }
    if ($Version)
    {
        $parameters += " --version:`"$Version`"";
    }
    if ($Preview)
    {
        $parameters += " --preview";
    }
    if ($Steps)
    {
        $parameters += " --steps:$Steps";
    }
    if ($Output)
    {
        $parameters += " --output";
    }
    if ($OutputFileName)
    {
        $parameters += " --outputFilename:`"$OutputFileName`"";
    }

    $parameters += " --assembly `"$Assembly`" --provider $Provider"
    if ($ConnectionString)
    {
        $parameters += " --connectionString:`"$ConnectionString`"";
    }
    else
    {
        $parameters += " --connectionString:`"$ConnectionStringName`" --connectionStringConfigPath:`"$ConnectionStringConfigurationPath`"";
    }

    Write-Verbose "Command will be: `"$migrateExePath`" $parameters";
    if ($WhatIf)
    {
        Write-Debug "WHATIF: Would invoke the following expression: `"$migrateExePath`" $parameters";
    }
    else
    {
        Invoke-Expression "& `"$migrateExePath`" $parameters";
    }
}

function CreateDatabaseIfNecessary
{
    [CmdletBinding()]
    PARAM(
        $connectionString, 
        $connectionStringName, 
        $connectionStringConfigName, 
        $provider,
        [switch]
        $WhatIf = $False
    )

    if ($connectionString)
    {
        "Creating Database for $connectionString (if it doesn't exist)";
    }
    else
    {
        "Creating Database for $connectionStringName in $connectionStringConfigName (if it doesn't exist)";
    }

    if ($provider -eq "PostGres")
    {
        if ($WhatIf)
        {
            Write-Debug "WHATIF: Would check if PostgreSQL database exists and create it if not.";
        }
        else
        {
            $scalar = ExecuteScalar $connectionString $connectionStringName $connectionStringConfigName "SELECT 1 FROM pg_database WHERE datname = '{0}'" $provider;
            if (!$scalar)
            {
                ExecuteCommand $connectionString $connectionStringName $connectionStringConfigName "CREATE DATABASE `"{0}`"" $provider;
            }
        }
    }
    elseif ($provider -eq "SQLite")
    {
        # SQLite automatically creates new database if it doesn't exist
        return;
    }
    else
    {
        if ($WhatIf)
        {
            Write-Debug "WHATIF: Would check if SQL Server database exists and create it if not.";
        }
        else
        {
            ExecuteCommand $connectionString $connectionStringName $connectionStringConfigName "IF db_id('{0}') IS NULL CREATE DATABASE [{0}]" $provider;
        }
    }
}

function DeleteDatabase
{
    [CmdletBinding()]
    PARAM(
        $connectionString, 
        $connectionStringName, 
        $connectionStringConfigName, 
        $provider,
        [switch]
        $WhatIf = $False
    )

    if ($connectionString)
    {
        "Deleting Database for $connectionString (if it exist)";
    }
    else
    {
        "Deleting Database for $connectionStringName in $connectionStringConfigName (if it exist)";
    }
    
    $command = "IF db_id('{0}') IS NOT NULL DROP DATABASE [{0}]";
    if ($provider -eq "PostGres")
    {
        $command = "DROP DATABASE IF EXISTS `"{0}`"";
    }
    elseif ($provider -eq "SQLite")
    {
        $builder = New-Object -Type System.Data.SQLite.SQLiteConnectionStringBuilder $connectionString;
        $fileName = $builder["Data Source"];

        if ($WhatIf)
        {
            Write-Debug ("WHATIF: Would delete SQLite file at '{0}'" -f $fileName);
        }
        else
        {
            Remove-Item $fileName;
        }
    }

    ExecuteCommand $connectionString $connectionStringName $connectionStringConfigName $command $provider -WhatIf:$WhatIf;
} 

function KillAllConnections
{
    [CmdletBinding()]
    PARAM(
        $connectionString, 
        $connectionStringName, 
        $connectionStringConfigName, 
        $provider,
        [switch]
        $WhatIf = $False
    )

    if ($connectionString)
    {
        "Kill all connections for $connectionString";
    }
    else
    {
        "Kill all connections for $connectionStringName in $connectionStringConfigName";
    }
    
    $command = "
        DECLARE @DatabaseName nvarchar(50)
        SET @DatabaseName = N'{0}'
        DECLARE @Sql varchar(max)
        SELECT @Sql = COALESCE(@Sql,'') + 'Kill ' + Convert(varchar, SPId) + ';'
            FROM MASTER..SysProcesses
            WHERE DBId = DB_ID(@DatabaseName) AND SPId <> @@SPId
        EXEC(@Sql)";
    if ($provider -eq "PostGres")
    {
        $command = "SELECT pg_terminate_backend(pid) FROM pg_stat_activity where datname = '{0}'";
    }
    elseif ($provider -eq "SQLite")
    {
        Write-Debug "Killing connection to SQLite file not supported";
        return;
    }

    ExecuteCommand $connectionString $connectionStringName $connectionStringConfigName $command $provider -WhatIf:$WhatIf;
}

function ExecuteCommand
{
    [CmdletBinding()]
    PARAM(
        $connectionString, 
        $connectionStringName, 
        $connectionStringConfigName, 
        $commandText,
        $provider,
        [switch]
        $WhatIf = $False
    )

    if ($WhatIf)
    {
        Write-Debug "WHATIF: Would execute following SQL on connection $connectionString $connectionStringName $connectionStringConfigName $provider`r`n$commandText";
    }
    else
    {
        $result = GetDbCommand $connectionString $connectionStringName $connectionStringConfigName $commandText $provider;
        $command = $result.Command;
        $conn = $result.Connection;

        $command.ExecuteNonQuery() | Out-Null;
        $command.Dispose();
        $conn.Dispose();
    }
}

function ExecuteScalar
{
    [CmdletBinding()]
    PARAM(
        $connectionString, 
        $connectionStringName, 
        $connectionStringConfigName, 
        $commandText,
        $provider,
        [switch]
        $WhatIf = $False
    )

    Write-Debug "Executing following scalar SQL on connection $connectionString $connectionStringName $connectionStringConfigName $provider`r`n$commandText";
    if ($WhatIf)
    {
        Write-Debug "WHATIF: Would execute following scalar SQL on connection $connectionString $connectionStringName $connectionStringConfigName $provider`r`n$commandText";
    }
    else
    {
        $result = GetDbCommand $connectionString $connectionStringName $connectionStringConfigName $commandText $provider;
        $command = $result.Command;
        $conn = $result.Connection;

        $scalar = $command.ExecuteScalar();
        $command.Dispose();
        $conn.Dispose();
    }

    return $scalar;
}

function GetDbCommand
{
    [CmdletBinding()]
    PARAM(
        $connectionString, 
        $connectionStringName, 
        $connectionStringConfigName, 
        $commandText,
        $provider
    )

    if ($connectionStringName)
    {
        if ($connectionStringConfigName)
        {
            $map = New-Object -Type System.Configuration.ExeConfigurationFileMap;
            $map.ExeConfigFilename = (Resolve-Path $connectionStringConfigName);
            $config = [System.Configuration.ConfigurationManager]::OpenMappedExeConfiguration($map, "None");
        
            $connectionString = $config.ConnectionStrings.ConnectionStrings[$connectionStringName].ConnectionString;
        }
        else
        {
            $connectionString = [Configuration.ConfigurationManager]::ConnectionStrings[$connectionStringName].ConnectionString;
        }
    }
    
    if ($provider -eq "PostGres")
    {
        $builder = New-Object -Type Npgsql.NpgsqlConnectionStringBuilder $connectionString;
        $dbName = $builder.Database;
        $builder.Database = "postgres";

        $conn = New-Object Npgsql.NpgsqlConnection $builder.ConnectionString;
    }
    elseif ($provider -eq "SQLite")
    {
        $conn = New-Object System.Data.SQLite.SQLiteConnection $connectionString;
    }
    else
    {
        $builder = New-Object -Type System.Data.SqlClient.SqlConnectionStringBuilder $connectionString;
        $dbName = $builder.InitialCatalog;
        $builder["Initial Catalog"] = "";

        $conn = New-Object System.Data.SqlClient.SqlConnection $builder.ConnectionString;
    }

    $conn.Open();
    $command = $conn.CreateCommand();
    $command.CommandText = $commandText -f $dbName;

    return @{ "Command" = $command; "Connection" = $conn; };
}

function Get-DatabaseMigration
{
    <#
        .SYNOPSIS
        Gets a list of migrations for the specified database.

        .PARAMETER Assembly
        The path to the DLL that contains the migrations

        .PARAMETER Provider
        The provider for the Database (See the DatabaseProvider enum for a list). Default is SqlServer2012

        .PARAMETER ConnectionString
        The connection string to the database to read migrations for. 

        .PARAMETER ConnectionStringName
        The name of the connection string to the database to read migrations for. Requires passing "ConnectionStringConfigurationPath" as well.

        .PARAMETER ConnectionStringConfigurationPath
        The path to a configuration file to use for reading connection strings.

        .PARAMETER Namespace
        A specific namespace to look for migrations.

        .PARAMETER Nested
        Whether migrations in nested namespaces should be included. Used in conjunction with the Namespace parameter.

        .PARAMETER TransactionPerSession
        The default transaction is one transaction per migration so the default for this switch is false. Run migrations in one transaction per session (task) instead.

        .PARAMETER Timeout
        Overrides the default SqlCommand timeout of 30 seconds.

        .PARAMETER WorkingDirectory
        The directory to load SQL scripts specified by migrations from.

        .PARAMETER Tag
        Filters migrations to be run based on tags.

        .PARAMETER Context
        A string argument that can be used in a migration.

        .PARAMETER Assemblies
        A list of assemblies to run for that command. Get them using Get-Assemblies Cmdlet.

        .PARAMETER WhatIf
        Only outputs what would happen.

        .PARAMETER DoNotKillExistingConnections
        Do not kill existing connections to the database being migrated. This could cause a migration to fail

        .EXAMPLE
        Get-DatabaseMigration -Assembly .\Core.NH\bin\Debug\Core.NH.dll -Provider SqlServer2012 -ConnectionStringName "Core" -ConnectionStringConfigurationPath .\.config\defaultapp.config
    #>
    [CmdletBinding()]
    PARAM(
        [string]
        $Assembly,
    
        [array]
        $Assemblies,

        [DatabaseProvider]
        $Provider = [DatabaseProvider]::SqlServer2012,
    
        [string]
        $ConnectionString,
    
        [string]
        $ConnectionStringName,
    
        [string]
        $ConnectionStringConfigurationPath,

        [string]
        $Namespace,

        [switch]
        $Nested,

        [switch]
        $TransactionPerSession,

        [int]
        $Timeout = $null,

        [string]
        $WorkingDirectory = $null,

        [string]
        $Tag = $null,

        [string]
        $Context = $null,

        [switch]
        $WhatIf = $False,
            
        [switch]
        $DoNotKillExistingConnections = $False
    )
    ExecuteMigrateCommand "listmigrations" $Assembly $Provider $ConnectionString $ConnectionStringName $ConnectionStringConfigurationPath $Namespace $Nested $TransactionPerSession $Timeout $WorkingDirectory $Tag $Context $null $null $null $null $null $null $null $Assemblies -WhatIf:$WhatIf -DoNotKillExistingConnections:$DoNotKillExistingConnections;
}

function Update-Database
{
    <#
        .SYNOPSIS
        Updates the database to the latest version.

        .PARAMETER Assembly
        The path to the DLL that contains the migrations

        .PARAMETER Provider
        The provider for the Database (See the DatabaseProvider enum for a list). Default is SqlServer2012

        .PARAMETER ConnectionString
        The connection string to the database to read migrations for. 

        .PARAMETER ConnectionStringName
        The name of the connection string to the database to read migrations for. Requires passing "ConnectionStringConfigurationPath" as well.

        .PARAMETER ConnectionStringConfigurationPath
        The path to a configuration file to use for reading connection strings.

        .PARAMETER Namespace
        A specific namespace to look for migrations.

        .PARAMETER DeleteBeforeMigrating
        If specified, the database will be deleted before executing the migration. Used for starting anew.

        .PARAMETER Nested
        Whether migrations in nested namespaces should be included. Used in conjunction with the Namespace parameter.

        .PARAMETER TransactionPerSession
        The default transaction is one transaction per migration so the default for this switch is false. Run migrations in one transaction per session (task) instead.

        .PARAMETER Timeout
        Overrides the default SqlCommand timeout of 30 seconds.

        .PARAMETER WorkingDirectory
        The directory to load SQL scripts specified by migrations from.

        .PARAMETER Tag
        Filters migrations to be run based on tags.

        .PARAMETER Context
        A string argument that can be used in a migration.

        .PARAMETER Profile
        A profile to run after migrations are done.

        .PARAMETER Output
        Whether to output to an SQL file. Default SQL file is {AssemblyName}.sql

        .PARAMETER OutputFileName
        FileName for SQL file if -Output is specified.

        .PARAMETER Assemblies
        A list of assemblies to run for that command. Get them using Get-Assemblies Cmdlet.

        .PARAMETER WhatIf
        Only outputs what would happen.

        .PARAMETER DoNotKillExistingConnections
        Do not kill existing connections to the database being migrated. This could cause a migration to fail

        .EXAMPLE
        Update-Database -Assembly .\Core.NH\bin\Debug\Core.NH.dll -Provider SqlServer2012 -ConnectionStringName "Core" -ConnectionStringConfigurationPath .\.config\defaultapp.config -DeleteBeforeMigrating
    #>
    [CmdletBinding()]
    PARAM(
        [string]
        $Assembly,
    
        [array]
        $Assemblies,

        [DatabaseProvider]
        $Provider = [DatabaseProvider]::SqlServer2012,
    
        [string]
        $ConnectionString,
    
        [string]
        $ConnectionStringName,
    
        [string]
        $ConnectionStringConfigurationPath,

        [string]
        $Version,

        [string]
        $Namespace,

        [switch]
        $DeleteBeforeMigrating,

        [switch]
        $Nested,

        [switch]
        $TransactionPerSession,

        [switch]
        $Preview,

        [int]
        $Timeout = $null,

        [string]
        $WorkingDirectory = $null,

        [string]
        $Tag = $null,

        [string]
        $Context = $null,

        [string]
        $Profile = $null,

        [switch]
        $Output,

        [string]
        $OutputFileName,

        [switch]
        $WhatIf = $False,
            
        [switch]
        $DoNotKillExistingConnections = $False
    )

    ExecuteMigrateCommand "migrate:up" $Assembly $Provider $ConnectionString $ConnectionStringName $ConnectionStringConfigurationPath $Namespace $Nested $TransactionPerSession $Timeout $WorkingDirectory $Tag $Context $Profile $Version $Preview $null $Output $OutputFileName $DeleteBeforeMigrating $Assemblies -WhatIf:$WhatIf -DoNotKillExistingConnections:$DoNotKillExistingConnections;
}

function Rollback-Database
{
    <#
        .SYNOPSIS
        Roll back the database to a previous version.

        .PARAMETER Assembly
        The path to the DLL that contains the migrations

        .PARAMETER Provider
        The provider for the Database (See the DatabaseProvider enum for a list). Default is SqlServer2012

        .PARAMETER ConnectionString
        The connection string to the database to read migrations for. 

        .PARAMETER ConnectionStringName
        The name of the connection string to the database to read migrations for. Requires passing "ConnectionStringConfigurationPath" as well.

        .PARAMETER ConnectionStringConfigurationPath
        The path to a configuration file to use for reading connection strings.

        .PARAMETER All
        If specified, rolls back all migrations.

        .PARAMETER Namespace
        A specific namespace to look for migrations.

        .PARAMETER Nested
        Whether migrations in nested namespaces should be included. Used in conjunction with the Namespace parameter.

        .PARAMETER TransactionPerSession
        The default transaction is one transaction per migration so the default for this switch is false. Run migrations in one transaction per session (task) instead.

        .PARAMETER Timeout
        Overrides the default SqlCommand timeout of 30 seconds.

        .PARAMETER WorkingDirectory
        The directory to load SQL scripts specified by migrations from.

        .PARAMETER Tag
        Filters migrations to be run based on tags.

        .PARAMETER Context
        A string argument that can be used in a migration.

        .PARAMETER Output
        Whether to output to an SQL file. Default SQL file is {AssemblyName}.sql

        .PARAMETER OutputFileName
        FileName for SQL file if -Output is specified.

        .PARAMETER Steps
        Number of versions to rollback. Default is 1.

        .PARAMETER Assemblies
        A list of assemblies to run for that command. Get them using Get-Assemblies Cmdlet.

        .PARAMETER WhatIf
        Only outputs what would happen.

        .PARAMETER DoNotKillExistingConnections
        Do not kill existing connections to the database being migrated. This could cause a migration to fail

        .EXAMPLE
        Rollback-Database -Assembly .\Core.NH\bin\Debug\Core.NH.dll -Provider SqlServer2012 -ConnectionStringName "Core" -ConnectionStringConfigurationPath .\.config\defaultapp.config -Steps 2
    #>
    [CmdletBinding()]
    PARAM(
        [string]
        $Assembly,
    
        [array]
        $Assemblies,

        [DatabaseProvider]
        $Provider = [DatabaseProvider]::SqlServer2012,
    
        [string]
        $ConnectionString,
    
        [string]
        $ConnectionStringName,
    
        [string]
        $ConnectionStringConfigurationPath,

        [switch]
        $All,

        [string]
        $Version,

        [string]
        $Namespace,

        [switch]
        $Nested,

        [switch]
        $TransactionPerSession,

        [switch]
        $Preview,

        [int]
        $Timeout = $null,

        [string]
        $WorkingDirectory = $null,

        [string]
        $Tag = $null,

        [string]
        $Context = $null,

        [switch]
        $Output,

        [string]
        $OutputFileName,

        [int]
        $Steps,

        [switch]
        $WhatIf = $False,
            
        [switch]
        $DoNotKillExistingConnections = $False
    )

    ExecuteMigrateCommand "rollback" $Assembly $Provider $ConnectionString $ConnectionStringName $ConnectionStringConfigurationPath $Namespace $Nested $TransactionPerSession $Timeout $WorkingDirectory $Tag $Context $null $Version $Preview $steps $Output $OutputFileName $null $Assemblies -WhatIf:$WhatIf -DoNotKillExistingConnections:$DoNotKillExistingConnections;
}

function Get-Assemblies
{
    <#
        .SYNOPSIS
        Loads assemblies from a file as JSON. Assemblies can then be passed to any other Cmdlet from this module and it will iterate over each assembly while executing the command.

        Any non-mandatory parameter in the JSON can be overriden by passing it directly to the Cmdlet afterwards.

        .PARAMETER FileName
        The path to the JSON file containing the assemblies.

        .EXAMPLE
        Get-Assemblies

        The assembly file is an array with each object containing at least the following properties: Assembly, Provider, ConnectionString (or ConnectionStringName and ConnectionStringConfigurationPath).
    #>
    [CmdletBinding()]
    PARAM(
        [Parameter(Mandatory = $True)]
        [string]
        $FileName
    )

    return Get-Content $FileName -Raw | ConvertFrom-Json;
}

Export-ModuleMember Get-DatabaseMigration;
Export-ModuleMember Update-Database;
Export-ModuleMember Rollback-Database;
Export-ModuleMember Get-Assemblies;
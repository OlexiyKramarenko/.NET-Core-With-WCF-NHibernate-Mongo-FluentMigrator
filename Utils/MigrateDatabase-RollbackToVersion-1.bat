..\packages\FluentMigrator.1.6.0\tools\Migrate.exe /connection "data source=localhost;initial catalog=MyTemp;User ID=sa;Password=******;" /db sqlserver2008 /timeout 600 /task rollback --steps=1 /target ..\DatabaseMigration\bin\Debug\DatabaseMigration.dll
pause

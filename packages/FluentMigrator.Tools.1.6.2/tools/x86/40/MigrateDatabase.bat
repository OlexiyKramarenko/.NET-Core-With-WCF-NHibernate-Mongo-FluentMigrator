Migrate.exe /connection "data source=localhost;initial catalog=MyTemp;
User ID=sa;Password=pswd;" 
/db SQLserver2008 /timeout 600 /target ..\DatabaseMigration.dll
echo 'Please wait while SQL Server 2017 warms up'
sleep 90s

echo 'Initializing database after 90 seconds of wait'
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P January2018 -d master -i initialize-database.sql

echo 'Finished initializing the database'
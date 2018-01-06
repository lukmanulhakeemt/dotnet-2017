#start SQL Server, start the script to create the DB and import the data, start the app
echo 'starting database setup'
/opt/mssql/bin/sqlservr & ./setup-database.sh & bash
# Integrate SQL Server 2017 Linux Docker image

## Build custom image with SQL Server 2017 database initialized

```bash
docker build -t nileshgule/sqldb .
```

## Run custom image

```bash
docker run -it -p 1433:1433 --name sql-db nileshgule/sqldb
```

docker run -d -p 1433:1433 --name sql2017 \
-e 'ACCEPT_EULA=Y' \
-e 'SA_PASSWORD=January2018' \
-e 'MSSQL_PID=Developer'  \
microsoft/mssql-server-linux:2017-latest

docker run -it -p 1433:1433 --name sql2017 \
-e 'ACCEPT_EULA=Y' \
-e 'SA_PASSWORD=January2018' \
-e 'MSSQL_PID=Developer'  \
nileshgule/sqldb

docker exec -it sql2017 /opt/mssql-tools/bin/sqlcmd \
   -S localhost -U SA -P "January@2018" \
   -Q "SELECT Name FROM sys.Databases"

   docker exec -it sql-db /opt/mssql-tools/bin/sqlcmd \
   -S localhost -U SA -P "January2018" \
   -Q "SELECT Name FROM sys.Databases"
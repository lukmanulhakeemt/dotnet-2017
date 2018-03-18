# Integrate SQL Server 2017 Linux Docker image

## Build custom image with SQL Server 2017 database initialized

```bash
docker build -t nileshgule/sqldb .
```

## Run custom image

```bash
docker run -it -p 1433:1433 \
--name sql2017 \
nileshgule/sqldb
```

## Alternate approach to run the image by overriding default settings

```bash
docker run -it -p 1433:1433 --name sql2017 \
-e 'ACCEPT_EULA=Y' \
-e 'SA_PASSWORD=January2018' \
-e 'MSSQL_PID=Developer'  \
nileshgule/sqldb
```

## Query the system databases to ensure startup script has initialized the new DB

```bash
docker exec -it sql2017 /opt/mssql-tools/bin/sqlcmd \
-S localhost \
-U SA \
-P "January2018" \
-Q "SELECT Name FROM sys.Databases"

docker exec -it sql2017 /opt/mssql-tools/bin/sqlcmd \
-S localhost \
-U SA \
-P "January2018" \

```

## Query the TechTalksDB database table to ensure startup script has initialized the new DB with reference data

```bash
docker exec -it sql2017 /opt/mssql-tools/bin/sqlcmd \
-S localhost \
-U SA \
-P "January2018"

USE TechTalksDB
GO

SELECT * FROM KeyValue
GO
```

## Cleanup orphan Docker containers

```bash
echo Y | docker container prune
```

## Cleanup orphan / dangling Docker images

```bash
echo Y | docker image prune
```
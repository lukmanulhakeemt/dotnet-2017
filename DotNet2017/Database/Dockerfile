FROM microsoft/mssql-server-linux:2017-latest

ENV ACCEPT_EULA="Y"
ENV SA_PASSWORD=January2018
ENV MSSQL_PID=Developer

WORKDIR /src

COPY initialize-database.sql ./
COPY setup-database.sh ./
COPY entrypoint.sh ./


EXPOSE 1433

# Grant permissions for the setup-database script to be executable
RUN chmod +x ./setup-database.sh
RUN chmod +x ./entrypoint.sh

# CMD /opt/mssql/bin/sqlservr

CMD bash ./entrypoint.sh
# CMD /opt/mssql/bin/sqlservr
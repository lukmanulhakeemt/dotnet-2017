FROM microsoft/aspnetcore:2.0
WORKDIR /MyFirstCoreWebApi
COPY releaseOutput /MyFirstCoreWebApi
ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080

ENTRYPOINT /bin/bash -c "dotnet CoreWebAPI.dll"
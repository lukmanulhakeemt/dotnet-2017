FROM microsoft/aspnetcore:2.0
WORKDIR /MyFirstCoreWebApi
COPY releaseOutput /MyFirstCoreWebApi
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000

ENTRYPOINT /bin/bash -c "dotnet CoreWebAPI.dll"
FROM microsoft/aspnetcore:2.0
WORKDIR /MyFirstAspNetCoreApp
COPY releaseOutput /MyFirstAspNetCoreApp
ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080
 
ENTRYPOINT /bin/bash -c "dotnet aspnetcoreapp.dll"
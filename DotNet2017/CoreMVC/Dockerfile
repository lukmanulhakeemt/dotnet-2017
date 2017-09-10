FROM microsoft/aspnetcore:2.0
WORKDIR /MyFirstMvcCoreApp
COPY releaseOutput /MyFirstMvcCoreApp
ENV ASPNETCORE_URLS http://*:8000
EXPOSE 8000
 
ENTRYPOINT /bin/bash -c "dotnet CoreMVC.dll"
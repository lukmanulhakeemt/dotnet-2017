FROM microsoft/aspnetcore:2.0
WORKDIR /MyFirstMvcCoreApp
COPY releaseOutput /MyFirstMvcCoreApp
ENV ASPNETCORE_URLS http://*:80
EXPOSE 80
 
ENTRYPOINT /bin/bash -c "dotnet CoreMVC.dll"
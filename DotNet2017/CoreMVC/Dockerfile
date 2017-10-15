FROM microsoft/aspnetcore:2.0

WORKDIR /MyFirstMvcCoreApp

COPY releaseOutput /MyFirstMvcCoreApp

EXPOSE 80

# ENTRYPOINT /bin/bash -c "dotnet CoreMVC.dll"
ENTRYPOINT ["dotnet", "CoreMVC.dll"]
FROM microsoft/aspnetcore:2.0

WORKDIR /MyFirstCoreWebApi

COPY releaseOutput /MyFirstCoreWebApi

EXPOSE 80

# ENTRYPOINT /bin/bash -c "dotnet CoreWebAPI.dll"
ENTRYPOINT ["dotnet", "CoreWebAPI.dll"]
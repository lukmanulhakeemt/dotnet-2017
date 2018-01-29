FROM microsoft/aspnetcore-build AS build-env

WORKDIR /MyFirstCoreWebApi

COPY CoreWebAPI.csproj ./
COPY NuGet.config ./
RUN dotnet restore

COPY . ./
RUN dotnet publish --configuration Release --output releaseOutput --no-restore

#build runtime image
FROM microsoft/aspnetcore:2.0

WORKDIR /MyFirstCoreWebApi

COPY --from=build-env /MyFirstCoreWebApi/releaseOutput ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "CoreWebAPI.dll"]
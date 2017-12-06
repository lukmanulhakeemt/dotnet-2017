FROM microsoft/dotnet-nightly:2.1-sdk AS build-env

WORKDIR /MyFirstCoreWebApi

COPY *.csproj ./
COPY NuGet.config ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o releaseOutput --no-restore

#build runtime image
FROM microsoft/dotnet-nightly:2.1-runtime-alpine

WORKDIR /MyFirstCoreWebApi

COPY --from=build-env /MyFirstCoreWebApi/releaseOutput ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "CoreWebAPI.dll"]
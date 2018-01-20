# FROM microsoft/dotnet-nightly:2.1-sdk AS build-env
FROM microsoft/dotnet AS build-env

WORKDIR /MyFirstMvcCoreApp

COPY *.csproj ./
COPY NuGet.config ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o releaseOutput --no-restore

#build runtime image
# FROM microsoft/dotnet-nightly:2.1-runtime-alpine
FROM microsoft/aspnetcore:2.0

WORKDIR /MyFirstMvcCoreApp

COPY --from=build-env /MyFirstMvcCoreApp/releaseOutput ./

EXPOSE 80

ENTRYPOINT ["dotnet", "CoreMVC.dll"]
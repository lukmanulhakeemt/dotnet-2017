FROM microsoft/aspnetcore-build AS build-env

WORKDIR /MyFirstMvcCoreApp

# COPY *.csproj ./
COPY CoreMVC.csproj ./
COPY NuGet.config ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o releaseOutput --no-restore

#build runtime image
FROM microsoft/aspnetcore:2.0

WORKDIR /MyFirstMvcCoreApp

COPY --from=build-env /MyFirstMvcCoreApp/releaseOutput ./

EXPOSE 80

ENTRYPOINT ["dotnet", "CoreMVC.dll"]
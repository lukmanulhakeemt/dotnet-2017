FROM microsoft/aspnetcore-build AS build-env

WORKDIR /MyFirstMvcCoreApp

COPY CoreMVC.csproj ./
COPY NuGet.config ./
RUN dotnet restore

COPY . ./
RUN dotnet publish --configuration Release --output releaseOutput --no-restore

#run test using container
# Homework for attendees 

#build runtime image
FROM microsoft/aspnetcore:2.0

WORKDIR /MyFirstMvcCoreApp

COPY --from=build-env /MyFirstMvcCoreApp/releaseOutput ./

EXPOSE 80

ENTRYPOINT ["dotnet", "CoreMVC.dll"]
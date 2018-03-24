FROM microsoft/aspnetcore-build AS build-env

WORKDIR /RabbitMQProduce

COPY Send.csproj ./
COPY NuGet.config ./
# RUN dotnet restore

COPY . ./

RUN dotnet restore

RUN dotnet publish --configuration Release --output releaseOutput --no-restore

#run test using container
# Homework for attendees 

#build runtime image
FROM microsoft/aspnetcore:2.0

WORKDIR /RabbitMQProduce

COPY --from=build-env /RabbitMQProduce/releaseOutput ./

# EXPOSE 80

ENTRYPOINT ["dotnet", "Send.dll"]
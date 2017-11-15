# Net Core app in Azure

## Step1 - Release build

Publish the artifacts in `Release` configuration

```bash
dotnet publish -c Release -o releaseOutput
```

## Step 2 - Transfer artifacts into container

### 2.1 search images using `docker CLI`

```bash
docker search aspnetcore
```

### 2.2 search images using Docker Hub

### 2.3 Define Dockerfile

Refer to [coremvc Dockerfile](coremvc/Dockerfile) for settings related to MVC application

Refer to [corewebapi Dockerfile](corewebapi/Dockerfile) for settings related to Web API

### 2.4

Build the docker image

```bash
docker rmi $(docker images -f dangling=true -q)

docker build -t coremvc .

docker build -t corewebapi .
```

### 2.5 Run the container 

```bash
docker run -d -p 80:80 coremvc

docker run -d -p 8080:80 corewebapi
```

## Step 3 - Docker compose for build stage

Refer to [docker-compose-build.yml](docker-compose-build.yml)

### Build the images using `docker-compose` command

```bash
docker-compose -f docker-compose-build.yml build
```

## Step 4 - local run using `docker-compose` command

```bash
docker-compose -f docker-compose-build.yml up -d
```

### verify web app & api are working as expected

Use `docker.for.mac.localhost` property to access webapi [http://docker.for.mac.localhost:8080/api/KeyValue](http://docker.for.mac.localhost:8080/api/KeyValue)

Alternatively, special ip `192.168.65.1` can be used as well instead of `docker.for.mac.localhost` 
[http://192.168.65.1:8080/api/KeyValue](http://192.168.65.1:8080/api/KeyValue)

## Step 5 - tag images before publishing to registry

Tag the images with repository name

```bash
docker tag corewebapi nileshgule/corewebapi

docker tag coremvc nileshgule/coremvc
```

## Step 6 - Push images to dockerhub

### Login to Dockerhub account using CLI 

```bash
docker login
```

### Push the images to `Dockerhub` registry to `nileshgule` repository

```bash
docker push nileshgule/corewebapi

docker push nileshgule/coremvc
```

## Step 7 - Provision ACS cluster with Docker Swarm as orchestrator

### Azure container service setting

|Parameter | Value |
|---|---|
|Name | coredemo |
|Resource Group | coredemoresourcegroup |
|Location | Southeast Asia |
|Orchestrator | Swarm |
|DNS prefix | coredemo |
|Master user credential | coreadmin |

## Step 8 - Connect docker client to Swarm management node in Azure

### Open SSH tunnel to Swarm endpoint in SE Asia

```bash
ssh -fNL 2375:localhost:2375 -p 2200 coreadmin@coredemomgmt.southeastasia.cloudapp.azure.com
```

### Set `DOCKER_HOST` environment variable

```bash
export DOCKER_HOST=:2375
```

#### Incase port 2375 is in use from previous sessions use following commands to reset it

```bash
lsof -ti:2375

lsof -ti:2375 | xargs kill -9
```

## Step 9 - Deploy & scale services to Swarm cluster

### Deploy using `docker-compose-azure.yml` file

```bash
docker-compose -f docker-compose.azure.yml up -d
```

### Scale mvc application to 2 instance

```bash
docker-compose -f docker-compose.azure.yml up -d \
--scale coremvc=2
```

### Scale up services to 4 instance

```bash
docker-compose -f docker-compose.azure.yml up -d \
--scale corewebapi=4 \
--scale coremvc=4
```

### Scale down services to 2 instances from 4

```bash
docker-compose -f docker-compose.azure.yml up -d \
--scale corewebapi=2 \
--scale coremvc=2
```

### Bring down all the services

```bash
docker-compose -f docker-compose.azure.yml down
```

### Pro tip

Ensure that exposed ports are consistent between Dockerfile and docker compose file

Access the Web application by browsing to site
[http://coredemoagents.southeastasia.cloudapp.azure.com](http://coredemoagents.southeastasia.cloudapp.azure.com)

API can be accessed using 
[http://coredemoagents.southeastasia.cloudapp.azure.com:8080/api/keyvalue](http://coredemoagents.southeastasia.cloudapp.azure.com:8080/api/keyvalue)

### List of commands to resolve network issue in swarm mode

```bash
docker network inspect dotnet2017_default

docker network disconnect -f dotnet2017_default dotnet2017_corewebapi_4

docker network rm dotnet2017_default
```

## References
---
1 - Overview of [Docker-compose](https://docs.docker.com/compose/reference/overview/) CLI

2 - [Container management](https://docs.microsoft.com/en-us/azure/container-service/dcos-swarm/container-service-docker-swarm) with Docker Swarm

3 - [Step by Step guide to deploying Swarm cluster](http://cloudify.co/2016/11/22/step-by-step-guide-deploying-docker-swarm-with-azure-container-service.html)  with Azure Container Service

4 - [ACS Engine swarm mode](https://azure.microsoft.com/en-us/resources/templates/101-acsengine-swarmmode/)

5 - [Swarm filters](https://docs.docker.com/swarm/scheduler/filter/#use-a-constraint-filter)

6 - [Docker Compose V3](https://docs.docker.com/compose/compose-file/#build)

7 - [Network error solution](https://parekhparthesh.blogspot.sg/2016/08/docker-unable-to-remove-network-has.html)

8 - [Docker Swarm CE currently available as preview in UK West region](https://github.com/MicrosoftDocs/azure-docs/blob/master/articles/container-service/dcos-swarm/container-service-swarm-mode-walkthrough.md)
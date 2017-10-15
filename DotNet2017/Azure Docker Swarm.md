# Net Core app in Azure

Step1 - Release build

Publish the artifacts
```bash
dotnet publish -c Release -o releaseOutput
```

Step 2 - Transfer artifacts into container

2.1 search images using CLI
2.2 search images using Docker Hub

2.3 Define Dockerfile

2.4 
Build the docker image
```bash 
docker rmi $(docker images -f dangling=true -q)

docker build -t coremvc .

docker build -t corewebapi .
```

2.5 Run the container 
```bash
docker run -d -p 80:80 coremvc

docker run -d -p 8080:8080 corewebapi

Step 3 - Docker compose

Step 4 - local run

Step 5 - Provision ACS cluster

## Azure container service setting
Name : coredemo
resource Group : coredemoresourcegroup
Location : Southeast Asia
Orchestrator : Swarm
DNS prefix : coredemo
Master user credential : coreadmin

### Publish proect oupu in `Release` configuration
dotnet publish -c Release -o releaseOutput  

### Build the images
```bash
docker-compose build -f docker-compose-build.yml
```

## Push images to dockerhub

Login to dockerhub account using CLI 
```bash
docker login
``` 

Tag the images with repository name

```bash
docker tag corewebapi nileshgule/corewebapi

docker tag coremvc nileshgule/coremvc
```

Push the images to dockerhub

```bash
docker push nileshgule/corewebapi

docker push nileshgule/coremvc
```

open SSH tunnel to Swarm endpoint in SE Asia
```bash

ssh -fNL 2375:localhost:2375 -p 2200 coreadmin@coredemomgmt.southeastasia.cloudapp.azure.com

ssh-keygen -R newcoredemomgmt.southeastasia.cloudapp.azure.com
```


Set DOCKER_HOST environment variable  
```bash
export DOCKER_HOST=:2375
```

Incase port 2375 is in use from previous sessions use folowing commands to reset it
```bash
lsof -ti:2375

lsof -ti:2375 | xargs kill -9
```

## Deploy to Swarm cluster
Docker compose using azure compose file
```bash
docker-compose -f docker-compose.azure.yml up -d
``` 

Scale mvc application to 2 instance
```bash
docker-compose -f docker-compose.azure.yml up -d --scale coremvc=2
```

Scale up services to 4 instance
```bash

docker-compose -f docker-compose.azure.yml up -d --scale corewebapi=4 --scale coremvc=4
```

Scale down services to 2 instances from 3
```bash
docker-compose -f docker-compose.azure.yml up -d --scale corewebapi=2 --scale coremvc=2

docker-compose -f docker-compose.azure.yml down
```

### Commands to run in case of full swarm mode
```bash
docker-compose -f docker-compose.azure.yml down --rmi all

docker stack deploy -c docker-compose.azure.yml webapp
```

### Pro tip
Ensure that exposed ports are consistent between Dockerfile and docker compose file

Access the Web application by browsing to site
http://coredemoagents.southeastasia.cloudapp.azure.com

API can be accessed using 
http://coredemoagents.southeastasia.cloudapp.azure.com:8080/api/values

## Docker Swarm visualizer
```bash
docker stack deploy -c visualizer.yml viz
```
Visualizer is not working because default Swarm mode in ACS is standalone. Refer to [this](https://github.com/portainer/portainer/issues/704) issue for more details
### ListDocker swarm nodes
```bash
docker node ls

docker node ps

docker node inspect 10.0.0.6
```


References
---
1 - Overview of [Docker-compose](https://docs.docker.com/compose/reference/overview/) CLI

2 - [Container management](https://docs.microsoft.com/en-us/azure/container-service/dcos-swarm/container-service-docker-swarm) with Docker Swarm

3 - [Step by Step guide to deploying Swarm cluster](http://cloudify.co/2016/11/22/step-by-step-guide-deploying-docker-swarm-with-azure-container-service.html)  with Azure Container Service

4 - [ACS Engine swarm mode](https://azure.microsoft.com/en-us/resources/templates/101-acsengine-swarmmode/)

5 - [Swarm filters](https://docs.docker.com/swarm/scheduler/filter/#use-a-constraint-filter)

6 - [Docker Compose V3](https://docs.docker.com/compose/compose-file/#build)

7 - [Network error solution](https://parekhparthesh.blogspot.sg/2016/08/docker-unable-to-remove-network-has.html)
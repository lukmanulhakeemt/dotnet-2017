# Net Core app in Azure

## Azure container service setting
Name : coredemo
resource Group : coredemoresourcegroup
Location : Southeast Asia
Orchestrator : Swarm
DNS prefix : coredemo
Master user credential : coreadmin



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

ssh-keygen -R coredemomgmt.southeastasia.cloudapp.azure.com
```

Incase port 2375 is in use from previous sessions use folowing commands to reset it
```bash
lsof -ti:2375

lsof -ti:2375 | xargs kill -9
```

Set DOCKER_HOST environment variable  
```bash
export DOCKER_HOST=:2375
```

Docker compose using azure compose file
```bash
docker-compose -f docker-compose.azure.yml up -d
``` 

Scale mvc application to 2 instance
```bash
docker-compose -f docker-compose.azure.yml up -d --scale coremvc=2
```

Scale up services to 3 instance
```bash
docker-compose -f docker-compose.azure.yml up -d --scale corewebapi=3 --scale coremvc=3
```

Scale down services to 2 instances from 3
```bash
docker-compose -f docker-compose.azure.yml up -d --scale corewebapi=2 --scale coremvc=2
```

### Pro tip
Ensure that exposed ports are consistent between Dockerfile and docker compose file

Access the Web application by browsing to site
http://coredemoagents.southeastasia.cloudapp.azure.com

API can be accessed using 
http://coredemoagents.southeastasia.cloudapp.azure.com:8080/api/values

References
---
1 - Overview of [Docker-compose](https://docs.docker.com/compose/reference/overview/) CLI

2 - [Container management](https://docs.microsoft.com/en-us/azure/container-service/dcos-swarm/container-service-docker-swarm) with Docker Swarm

3 - [Step by Step guide to deploying Swarm cluster](http://cloudify.co/2016/11/22/step-by-step-guide-deploying-docker-swarm-with-azure-container-service.html)  with Azure Container Service
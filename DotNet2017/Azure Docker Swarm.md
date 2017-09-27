# Net Core app in Azure

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

ssh -fNL 2375:localhost:2375 -p 2200 coredemoadmin@coredemomgmt.southeastasia.cloudapp.azure.com

ssh-keygen -R coredemomgmt.southeastasia.cloudapp.azure.com
```

Set DOCKER_HOST environment variable  
```bash
export DOCKER_HOST=:2375
```

Docker compose using azure compose file
```bash
docker-compose -f docker-compose.azure.yml up -d
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
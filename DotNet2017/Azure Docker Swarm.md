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

open SSH tunnel to Swarm endpoint
```bash
ssh -fNL 2375:localhost:2375 -p 2200 coredemoadmin@coredemomgmt.eastus.cloudapp.azure.com

```

Set DOCKER_HOST environment variable  
```bash
export DOCKER_HOST=:2375
```

Docker compose using azure compose file
```bash
docker-compose up -d -f docker-compose.azure.yml
``` 

References
---
1 - Overview of [Docker-compose](https://docs.docker.com/compose/reference/overview/) CLI

2 - [Container management](https://docs.microsoft.com/en-us/azure/container-service/dcos-swarm/container-service-docker-swarm) with Docker Swarm

3 - [Step by Step guide to deploying Swarm cluster](http://cloudify.co/2016/11/22/step-by-step-guide-deploying-docker-swarm-with-azure-container-service.html)  with Azure Container Service
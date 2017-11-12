## Deploy Swarm using ACS
Use [ACS Engine swarm mode](https://azure.microsoft.com/en-us/resources/templates/101-acsengine-swarmmode/) as the default ACS uses standalone Swarm cluster which is quite old.

Deploy Azure Container Service in Docker Swarm mode with following options

## Azure container service setting
|Parameter | Value |
|---|---|
|Name | coredemo |
|Resource Group | swarmresourcegroup|
|Location | Southeast Asia |
|Master prefix | swarmmaster|
|Master user credential | swarmadmin|
|Agent prefix | swarmagent|

### Open SSH tunnel to Swarm endpoint in SE Asia
```bash
ssh -fNL 2375:localhost:2375 -p 2200 swarmadmin@swarmmaster.southeastasia.cloudapp.azure.com
```

### Set `DOCKER_HOST` environment variable
```bash
export DOCKER_HOST=:2375
```

### List Docker swarm nodes
```bash
docker node ls

docker node ps
```

## Deploy services in Swarm
### Deploy stack to Swarm nodes with stackname `webapp`
```bash
docker stack deploy -c docker-compose.azure.yml webapp
```

### List stacks
```bash
docker stack ls
```

### List tasks in `webapp` stack
```bash
docker stack ps webapp
```

### List all services
```bash
docker service ls
```

### List all tasks related to `coremvc`
```bash
docker service ps webapp_coremvc
```

### List all tasks related to `corewebapi`
```bash
docker service ps webapp_corewebapi
```

## Scale services
### Scale `Coremvc` service to 2 replicas
```bash
docker service scale webapp_coremvc=2
```

### Scale `corewebapi` service to 3 replicas
```bash
docker service scale webapp_corewebapi=3
```

## Pull down the whole stack
```bash
docker stack rm webapp
```

## Docker Swarm visualizer
```bash
docker stack deploy -c visualizer.yml viz

docker service create \
   --name portainer \
   --publish 9000:9000 \
   --constraint 'node.role == manager' \
   --mount type=bind,src=/var/run/docker.sock,dst=/var/run/docker.sock \
   portainer/portainer \
   -H unix:///var/run/docker.sock \
   --tlsverify

docker run -it -d \
-p 5000:5000 \
-e HOST=swarmmaster.southeastasia.cloudapp.azure.com \
-e PORT=5000 \
-v /var/run/docker.sock:/var/run/docker.sock \
julienstroheker/docker-swarm-visualizer

docker service create \
  --name=viz \
  --publish=8080:8080/tcp \
  --constraint=node.role==manager \
  --mount=type=bind,src=/var/run/docker.sock,dst=/var/run/docker.sock \
  dockersamples/visualizer


docker service create \
--name=vizualizer \
--publish=8080:8080 \
--constraint=node.role==manager \
--mount=type=bind,src=/var/run/docker.sock,dst=/var/run/docker.sock \
dockersamples/visualizer

docker service create \
--name web \
-p 8080:80 \
nginx

```

The *visualizer* and *portainer* images did not work after several attempts. Need to debug the issue with visualization further. **Nginx** image was tried to check if Swarm cluster is working fine. 

## Pending items / enhancements
- Use deployment related configuration within docker compose file
- Provide default replicas which can be overridden at runtime
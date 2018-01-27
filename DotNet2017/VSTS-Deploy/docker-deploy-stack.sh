#!/bin/bash

export DOCKER_HOST=:2375  

echo $2 | docker login -u $1 --password-stdin 

cd deploy 
#echo $1
env BUILD_BUILDID=$3 docker stack deploy --compose-file docker-swarm-deploy.yml webapp --with-registry-auth
# env docker stack deploy --compose-file docker-swarm-deploy.yml webapp --with-registry-auth
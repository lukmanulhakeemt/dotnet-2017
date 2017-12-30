#!/bin/bash

export DOCKER_HOST=:2375  
cd deploy 
echo $1
env BUILD_BUILDID=$1 docker stack deploy -c docker-stack-swarm.yml webapp --with-registry-auth
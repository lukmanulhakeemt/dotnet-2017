#!/bin/bash

export DOCKER_HOST=:2375  
export BUILD_BUILDID=$1
cd deploy 
docker stack deploy -c docker-stack-swarm.yml webapp --with-registry-auth
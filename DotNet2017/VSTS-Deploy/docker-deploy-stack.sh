#!/bin/bash

#export DOCKER_HOST=:2375  && cd deploy && docker stack deploy -c docker-compose.azure.yml webapp --with-registry-auth

export DOCKER_HOST=:2375  
cd deploy 
docker stack deploy -c docker-compose.azure.yml webapp --with-registry-auth
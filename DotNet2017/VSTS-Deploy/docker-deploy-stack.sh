#!/bin/bash

export DOCKER_HOST=:2375  

echo $2 | docker login -u $1 --password-stdin 

cd deploy 

env BUILD_BUILDID=$3 docker stack deploy --compose-file docker-compose-deploy.yml --prune webapp --with-registry-auth
#!/bin/bash

echo $(docker.password) | docker login -u $(docker.username) --password-stdin 
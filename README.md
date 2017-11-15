# DotNet Core Demo
This repository contains projects for exploring the features of `DotNet Core`. It was stared as part of a demo for community event. Along with Core features, we extended it to explore new and upcoming technologies like `Docker, Azure Container Services, Docker Swarm and Kubernetes`.

There are mainly two projects which are used for exploring container related technologies.
- coremvc
- corewebapi

## Coremvc

This is a ASP.NET Core MVC website. It has a simple UI to search for values using a key. The key store can be inmemory list or a collection returned from a web API.

## Corewebapi

This project provides an API to return a collection of predefined values.

These two projects are then used to play around with container technologies including Docker, Docker Swarm and Kubernetes.

## Run and Scale apps using Docker Swarm in Azure Container Service (ACS)

Refer to [Azure Docker Swarm](DotNet2017/AzureDockerSwarm.md) for details on how to run the application on **Microsoft Azure** cloud. It uses **Azure Container Service (ACS)** with **Docker Swarm** as Orchestrator. At the time of this writing ACS works with an older version of Swarm and not the Docker Swarm mode available in latest version of Docker. It runs as a standalone master.

The same services can also be run on a full fledge Swarm cluster. Refer to [Azure Docker Swarm Mode](DotNet2017/AzureDockerSwarmMode.md) for more details.

## Run and scale apps using Kubernetes

This is currently work in progress. Updates will be available soon.

# Commands related to Azure Container Service (AKS)

## Set Azure CLI in interactive mode

```bash

az interactive

```

## Enable AKS preview for subscription

```bash

az provider show -n Microsoft.ContainerService

```

## Monitor state of registration

```bash

az provider show -n Microsoft.ContainerService

```

## Variables for the azure CLI script

```bash

resourceGroupName="k8sResourceGroup"
resourceGroupLocaltion="East US"
clusterName="coreDemoAKSCluster"

```

## Create Resource Group

```bash

az group create \
--name $resourceGroupName \
--location $resourceGroupLocaltion \
--output jsonc

```

## Create AKS cluster

```bash

time \
az aks create \
--resource-group $resourceGroupName \
--name $clusterName \
--node-count 2 \
--kubernetes-version 1.8.1 \
--output jsonc

```

## Connect to AKS cluster

```bash

az aks get-credentials \
--resource-group $resourceGroupName \
--name $clusterName

```

## Verify connection to cluster

```bash

kubectl get nodes

```

## Get cluster versions

```bash

az aks get-upgrades \
--name $clusterName \
--resource-group $resourceGroupName \
--output jsonc

```

## Upgrade cluster to 1.8.1 version (if required)

```bash

az aks upgrade \
--name $clusterName \
--resource-group $resourceGroupName \
--kubernetes-version 1.8.1 \
--output jsonc

```

## Create persistent volume claim in Kubernetes

### Create a secret for SA password

```bash

kubectl create secret generic mssql --from-literal=SA_PASSWORD="January2018"
kubectl create secret generic mssql --from-literal=SA_PASSWORD="MyC0m9l&xP@ssw0rd"

```

### Get secret

```bash

kubectl get secrets

```

### Describe secret named mssql

```bash

kubectl describe secrets/mssql

```

### Create Azure disk as persistent volume and persistent volume claim named `mssql-data`

```bash

kubectl apply -f pvc.yml

kubectl describe pod mssql-deployment-69d56b9996-jthjw

```

### Verify persistent volume claim `mssql-data`

```bash

kubectl describe pvc mssql-data

```

### Verify persistent volume

```bash

kubectl describe pv

kubectl apply -f sqldeployment.yml

```

## Run the application

```bash

kubectl create -f coredemo.yml

```

## Monitor the progress of service

```bash

kubectl get service coremvc --watch

kubectl get service mssql-deployment --watch

```

## Browse AKS cluster dashboard

```bash

az aks browse \
--resource-group $resourceGroupName \
--name $clusterName

```

## Get persistant volume details

```bash

kubectl get pv mssql-data

```

## Delete resource group

```bash

az group delete \
--name $resourceGroupName \
--yes \
--no-wait

```

## Connect to SQL DB using sql-tools image

```bash

docker run -it nileshgule/sqlclient

sqlcmd -U someuser -P s0mep@ssword -z a_new_p@a$$w0rd
```
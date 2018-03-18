# Azure Resource template

## Login to Azure account (not required in case of cloud shell)

```bash

az login

```

## Set subscription ID (not required in case of cloud shell)

```bash

az account set --subscription "Visual Studio Enterprise"

az account set --subscription "Azure Pass"

```

## Create resource group

```bash

az group create \
--name swarmresourcegroup \
--location "Southeast Asia"

```

## Create deployment using remote template file

```bash

az group deployment create \
    --name "coredemo" \
    --resource-group "swarmresourcegroup" \
    --template-uri https://raw.githubusercontent.com/azure/azure-quickstart-templates/master/101-acsengine-swarmmode/azuredeploy.json

```

## Create deployment using remote template file with local parameters

```bash

az group deployment create \
    --name "coredemo" \
    --resource-group "swarmresourcegroup" \
    --template-uri https://raw.githubusercontent.com/azure/azure-quickstart-templates/master/101-acsengine-swarmmode/azuredeploy.json \
    --parameters parameters.json

```

## Create deployment using local template file and parameters

```bash

az group deployment create \
    --name "coredemo" \
    --resource-group "swarmresourcegroup" \
    --template-file azuredeploy.json \
    --parameters parameters.json

```

## Delete resources at the end

```bash

echo y | az group delete --name swarmresourcegroup

```
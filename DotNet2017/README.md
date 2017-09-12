## Setup developemnt environment for MacOsX
- Install .net Core SDK from the [link](https://www.microsoft.com/net/core#macos)
- `dotnet` command is not recognized if you are using Oh My Zsh as the terminal. To resolve the issue use symbolic link to the dotnet installation directory by using 
```bash
ln -s /usr/local/share/dotnet/dotnet /usr/local/bin/
```

Create a new ASP.Net Core app
```bash
dotnet new razor -o aspnetcoreapp
```

Publish the artifacts
```bash
dotnet publish -c Release -o releaseOutput
```
Build the docker image
```bash 
docker build -t aspnetcoreapp .
```

Run the container 
```bash
docker run -d -p 8000:8000 aspnetcoreapp
```

### Verify application is running fine by navigating to the following link in the browser
`http://localhost:8000`

#### At times "localhost" may not work especillay if docker machine is setup using Docker Toolkit; in that case try to identify the IP address of the docker machine using below command on the docker host machine
```docker
$ docker-machine ip
```
#### Other useful commands
##### List containers with their IP
```docker
$ docker inspect -f '{{.Name}} - {{.NetworkSettings.IPAddress }}' $(docker ps -aq)
```
##### RUN a docker image with a friendly "container" name
```docker
$ docker run --name **friendly-container-name** **docker-image-name**
```

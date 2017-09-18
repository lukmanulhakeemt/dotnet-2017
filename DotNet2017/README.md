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

## Setup developemnt environment for Windows 8 (prior to Win10)
- Install [Docker toolbox](https://docs.docker.com/toolbox/toolbox_install_windows/) on your Windows machine which is prior to Windows 10. If you are already on Windows 10 machine try out [Docker for Windows](https://docs.docker.com/docker-for-windows/)
- Start Docker Quickstart Terminal
- On your machine try out following command to ensure Docker Toolbox setup is complete
```cmd
docker version
```
- Install *_VS Code_* or Install *_VS 2017_* IDE for project. I used *_VS 2017_* for this demo. 

### Project Descritpion
1) CoreConsoleApp
2) CoreMVC
3) CoreWebAPI

### Some useful commands

#### At times "localhost" may not work especillay if docker machine is setup using Docker Toolkit; in that case try to identify the IP address of the docker machine using below command on the docker host machine
```bash
docker-machine ip
```

#### List containers with their IP
```bash
docker inspect -f '{{.Name}} - {{.NetworkSettings.IPAddress }}' $(docker ps -aq)
```

#### RUN a docker image with a friendly "container" name
```bash
docker run --name friendly-container-name docker-image-name
```
## Learn Docker
Try out the [Get Started](https://docs.docker.com/get-started/) Docker tutorial. 

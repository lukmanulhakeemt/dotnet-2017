## Setup developemnt environment for MacOsX
- Install .net Core SDK from the [link](https://www.microsoft.com/net/core#macos)
- `dotnet` command is not recognized if you are using Oh My Zsh as the terminal. To resolve the issue use symbolic link to the dotnet installation directory by using 
```bash
ln -s /usr/local/share/dotnet/dotnet /usr/local/bin/
```
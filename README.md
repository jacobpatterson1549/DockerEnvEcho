# DockerEnvEcho

DockerEnvEcho runs a small web server.
It has and endpoint that echos the program's environmental arguments.
For security, only arguments with a key starting with `MY_` are shown.
Locally, the arguments can be set in the following places:
* in launchSettings.json, when running in Visual Studio or VS Code
* in docker-compose.yml, when running with docker (`docker compose up --build`)
* on the command line:
    * windows: `set MY_arg1=v1 && set MY_arg2=v2 && set MY_arg3=v3 &&  dotnet run`
    * linux: `MY_arg1=v1 MY_arg2=v2  MY_arg3=v3 dotnet run`
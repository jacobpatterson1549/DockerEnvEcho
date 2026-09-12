# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY . ./
RUN dotnet build -c release -o /app/build
RUN dotnet test
RUN dotnet publish -c release -o /app/publish

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish   ./
ENTRYPOINT ["dotnet", "DockerEnvEcho.dll"]
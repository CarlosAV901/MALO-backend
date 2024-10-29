# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
ENV DB_CONNECTION_STRING="Server=104.198.255.228;Database=Empleos_db;User Id=sqlserver;Password='a;6u{EN1XfeqX(lb';TrustServerCertificate=True;"


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MALO.Microservice.Empleosdb.API/MALO.Microservice.Empleosdb.API.csproj", "MALO.Microservice.Empleosdb.API/"]
COPY ["MALO.Microservice.Empleosdb.Aplication/MALO.Microservice.Empleosdb.Aplication.csproj", "MALO.Microservice.Empleosdb.Aplication/"]
COPY ["MALO.Microservice.Empleosdb.Domain/MALO.Microservice.Empleosdb.Domain.csproj", "MALO.Microservice.Empleosdb.Domain/"]
COPY ["MALO.Microservice.Empleosdb.Infraestructure/MALO.Microservice.Empleosdb.Infraestructure.csproj", "MALO.Microservice.Empleosdb.Infraestructure/"]
RUN dotnet restore "./MALO.Microservice.Empleosdb.API/MALO.Microservice.Empleosdb.API.csproj"
COPY . .
WORKDIR "/src/MALO.Microservice.Empleosdb.API"
RUN dotnet build "./MALO.Microservice.Empleosdb.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MALO.Microservice.Empleosdb.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:$PORT
ENTRYPOINT ["dotnet", "MALO.Microservice.Empleosdb.API.dll"]
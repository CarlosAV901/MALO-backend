# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ENV DB_CONNECTION_STRING="Server=104.198.255.228;Database=Usuarios_db;User Id=sqlserver;Password='a;6u{EN1XfeqX(lb';TrustServerCertificate=True;"

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MALO.Microservice.Empleos.API/MALO.Microservice.Empleos.API.csproj", "MALO.Microservice.Empleos.API/"]
COPY ["MALO.Microservice.Empleo.Aplication/MALO.Microservice.Empleos.Aplication.csproj", "MALO.Microservice.Empleo.Aplication/"]
COPY ["MALO.Microservice.Empleos.Domain/MALO.Microservice.Empleos.Domain.csproj", "MALO.Microservice.Empleos.Domain/"]
COPY ["MALO.Microservice.Empleos.Infraestructure/MALO.Microservice.Empleos.Infraestructure.csproj", "MALO.Microservice.Empleos.Infraestructure/"]
RUN dotnet restore "./MALO.Microservice.Empleos.API/MALO.Microservice.Empleos.API.csproj"
COPY . .
WORKDIR "/src/MALO.Microservice.Empleos.API"
RUN dotnet build "./MALO.Microservice.Empleos.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MALO.Microservice.Empleos.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MALO.Microservice.Empleos.API.dll"]
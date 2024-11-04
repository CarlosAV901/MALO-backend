# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
ENV DB_CONNECTION_STRING="Server=104.198.255.228;Database=Documentos_db;User Id=sqlserver;Password='a;6u{EN1XfeqX(lb';TrustServerCertificate=True;"



# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MALO.Microservice.Documentos.API/MALO.Microservice.Documentos.API.csproj", "MALO.Microservice.Documentos.API/"]
COPY ["MALO.Microservice.Documentos.Aplication/MALO.Microservice.Documentos.Aplication.csproj", "MALO.Microservice.Documentos.Aplication/"]
COPY ["MALO.Microservice.Documentos.Domain/MALO.Microservice.Documentos.Domain.csproj", "MALO.Microservice.Documentos.Domain/"]
COPY ["MALO.Microservice.Domumentos.Infraestructure/MALO.Microservice.Domumentos.Infraestructure.csproj", "MALO.Microservice.Domumentos.Infraestructure/"]
RUN dotnet restore "./MALO.Microservice.Documentos.API/MALO.Microservice.Documentos.API.csproj"
COPY . .
WORKDIR "/src/MALO.Microservice.Documentos.API"
RUN dotnet build "./MALO.Microservice.Documentos.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MALO.Microservice.Documentos.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:$PORT
ENTRYPOINT ["dotnet", "MALO.Microservice.Documentos.API.dll"]
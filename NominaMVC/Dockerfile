
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Imagen base de ASP.NET 
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
# Directorio de trabajo dentro del contenedor
WORKDIR /app

# Exponer el puerto 80 de la imagen para luego ser mapeado al host Ej: 80 -> 3000
EXPOSE 80

# Exponer puerto de la bd 
EXPOSE 1433

# Imagen base de compliacion, se usa un alias "build"
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Se define el directorio de trabajo 
WORKDIR /app

# Se copian los archivos del local a la imagen
COPY . .
#COPY ["src/PublicApi/PublicApi.csproj", "./PublicApi/"]
#RUN dotnet restore "./PublicApi/PublicApi.csproj"
#COPY . .
WORKDIR "/app"  
RUN dotnet restore 

RUN dotnet build "./NominaMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./NominaMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NominaMVC.dll"]

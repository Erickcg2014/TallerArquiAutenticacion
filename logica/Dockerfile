# ============================
#       Etapa 1 — Build
# ============================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar todo el proyecto
COPY . .

# Restaurar paquetes primero (IMPORTANTE)
RUN dotnet restore

# Publicar en Release
RUN dotnet publish -c Release -o /app/publish


# ============================
#       Etapa 2 — Runtime
# ============================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "logica.dll"]

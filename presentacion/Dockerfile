# ============================
#   Etapa 1 — Build
# ============================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar todo el proyecto
COPY . .

# Limpiar antes (importante)
RUN dotnet clean

# Restaurar dependencias
RUN dotnet restore

# Publicar en modo Release
RUN dotnet publish -c Release -o /app/publish


# ============================
#   Etapa 2 — Runtime
# ============================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copiar la publicación
COPY --from=build /app/publish .

# Exponer puerto por defecto
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "presentacion.dll"]

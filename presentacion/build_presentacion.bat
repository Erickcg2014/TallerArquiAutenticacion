@echo off
echo ===============================
echo LIMPIANDO PROYECTO .NET
echo ===============================
dotnet clean

echo Eliminando carpetas bin y obj...
rmdir /s /q bin
rmdir /s /q obj

echo ===============================
echo COMPILANDO PROYECTO
echo ===============================
dotnet build

echo ===============================
echo PUBLICANDO PROYECTO
echo ===============================
dotnet publish -c Release -o publish

echo ===============================
echo CONSTRUYENDO IMAGEN DOCKER
echo ===============================
docker build -t presentacion:latest .

echo.
echo Imagen creada correctamente: presentacion:latest
echo.
echo (Opcional) Subir a Docker Hub:
echo docker tag presentacion:latest USUARIO/presentacion:latest
echo docker push USUARIO/presentacion:latest
pause

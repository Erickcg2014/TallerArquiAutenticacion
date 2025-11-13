@echo off
echo ===============================
echo  LIMPIANDO PROYECTO .NET
echo ===============================
dotnet clean

echo Eliminando bin y obj...
rmdir /s /q bin
rmdir /s /q obj

echo ===============================
echo  COMPILANDO PROYECTO
echo ===============================
dotnet build

echo ===============================
echo  PUBLICANDO PROYECTO
echo ===============================
dotnet publish -c Release -o publish

echo ===============================
echo  CONSTRUYENDO IMAGEN DOCKER
echo ===============================
docker build -t logica:latest .

echo.
echo Imagen creada: logica:latest
echo.
echo Para subir a DockerHub:
echo docker tag logica:latest USUARIO/logica:latest
echo docker push USUARIO/logica:latest
pause

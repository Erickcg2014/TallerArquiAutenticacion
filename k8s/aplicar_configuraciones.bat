@echo off
echo ===================================
echo APLICANDO CONFIGURACIONES EN KUBERNETES
echo ===================================

echo.
echo -----------------------------------
echo ELIMINANDO DESPLIEGUES PREVIOS
echo -----------------------------------
kubectl delete -f logica.yaml --ignore-not-found
kubectl delete -f presentacion.yaml --ignore-not-found

echo.
echo -----------------------------------
echo APLICANDO NUEVA CONFIGURACION: LOGICA (BACKEND)
echo -----------------------------------
kubectl apply -f logica.yaml

echo.
echo -----------------------------------
echo APLICANDO NUEVA CONFIGURACION: PRESENTACION (FRONTEND)
echo -----------------------------------
kubectl apply -f presentacion.yaml

echo.
echo ===================================
echo      DESPLIEGUE COMPLETADO
echo ===================================

echo.
echo === PODS ACTIVOS ===
kubectl get pods

echo.
echo === SERVICIOS DISPONIBLES ===
kubectl get svc

echo.
echo -----------------------------------
echo PRESENTACION disponible en:
echo   http://localhost:30080
echo -----------------------------------
echo (Minikube / Docker Desktop NodePort)
echo.

pause

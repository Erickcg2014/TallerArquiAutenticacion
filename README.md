# 🧩 Taller: Autenticación y Despliegue

## 👥 Grupo

- _Erick Santiago Camargo García_
- _David Julián Cuadros Astro_

---

## 🏗 Construcción del proyecto

1. Entrar a la carpeta **logica** y ejecutar:  
   bash
   build_logica.bat

2. Entrar a la carpeta **presentacion** y ejecutar:  
   bash
   build_presentacion.bat

3. Entrar a la carpeta **k8s** y ejecutar:  
   bash
   aplicar_configuraciones.bat

---

## ☸ Comandos de Kubernetes

📦 Ver los pods activos:
bash
kubectl get pods

🌐 Ver los servicios y sus puertos:
bash
kubectl get svc

---

## 🔄 Reconstrucción del entorno

Si deseas _recrear los pods_:

bash
kubectl delete --all pods

> Los pods se volverán a crear automáticamente según las configuraciones aplicadas.

---

## 🌍 Acceso a la aplicación

Abre en el navegador:  
👉 [http://localhost:30081](http://localhost:30081)

---

## 🔐 Credenciales de acceso

| Campo        | Valor |
| ------------ | ----- |
| _Usuario_    | admin |
| _Contraseña_ | 123   |

---

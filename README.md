# Sistema de Gestión de Requerimientos de Adquisiciones

Este proyecto es una aplicación web desarrollada en Angular (frontend) y .NET (backend) para gestionar el registro, consulta, modificación y seguimiento de requerimientos de adquisición de bienes y servicios.

## Arquitectura del Proyecto

- **Frontend:** Angular 15+
- **Backend:** .NET 6 / .NET Core Web API
- **Base de datos:** SQL Server (u otra, si aplica)
- **Comunicación:** API RESTful
- **Testing de APIs:** Postman

---

##  Funcionalidades

### Consulta
- Visualización de requerimientos registrados
- Detalles como presupuesto, unidad, tipo, cantidad, proveedor, etc.

###  Registro
- Formulario para ingresar nuevos requerimientos con validaciones
- Registro de documentación y valores

###  Historial
- Seguimiento de cambios realizados en cada requerimiento
- Trazabilidad de acciones por fecha

### Backend
- CRUD completo de adquisiciones
- API REST protegida y documentada
- Conexión con base de datos

---

##  Estructura del Proyecto
/frontend /src/app /components /services /models angular.json

/backend /Controllers /Models /Services appsettings.json


---

## Cómo ejecutar el proyecto

### 1. Clona el repositorio

      ```bash
      https://github.com/nestorm94/prueba_adres/new/main?filename=README.md  

### 2. Levanta el backend (.NET)
  cd backend
  dotnet restore
  dotnet run
### 3. Levanta el frontend (Angular)

  cd frontend
  npm install
  ng serve


## Requisitos
Node.js 18+

Angular CLI

.NET 6 SDK

SQL Server (o el gestor que utilices)


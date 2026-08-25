# Práctica No. 3 - Arquitectura en Capas

## Descripción

API REST para administrar productos de una tienda, construida con arquitectura en capas (Controller → Service → IRepository → Repository → Base de datos), usando inyección de dependencias.

## Tecnologías

- .NET 8 / ASP.NET Core Web API
- Entity Framework Core 8 (SQL Server)
- SQL Server

## Estructura de capas

| Capa | Archivo | Responsabilidad |
|---|---|---|
| Model | `Models/Producto.cs` | Entidad Producto (Id, Nombre, Precio, Stock). |
| Controller | `Controllers/ProductosController.cs` | Recibe peticiones HTTP y delega en el Service. |
| Service | `Services/ProductoService.cs` | Lógica de negocio. Depende de `IProductoRepository`. |
| Repository | `Repositories/ProductoRepository.cs` | Acceso a datos con EF Core. |
| Persistencia | `Data/AppDbContext.cs` | Conexión con SQL Server. |
| DI | `Program.cs` | Registra las dependencias. |

## Endpoints

- `GET /api/productos` — todos los productos
- `GET /api/productos/{id}` — un producto por Id

## Crear la base de datos

1. Ajustar la cadena de conexión en `appsettings.json`.
2. Instalar la herramienta EF Core (si falta): `dotnet tool install --global dotnet-ef`
3. Crear la base de datos:
```bash
   dotnet ef migrations add InicialProductos
   dotnet ef database update
```

## Ejecutar el proyecto

```bash
dotnet restore
dotnet run
```

**¿Qué ventaja obtiene el sistema al hacer que el Service dependa de una interfaz (`IRepository`) en lugar de depender directamente de una clase concreta de Repository?**

El Service queda desacoplado de cómo se accede realmente a los datos: no le importa si vienen de SQL Server u otra fuente, solo conoce el contrato. Esto facilita las pruebas unitarias (se puede mockear `IProductoRepository`), permite cambiar la implementación de persistencia sin tocar el Service ni el Controller, y cumple el Principio de Inversión de Dependencias (SOLID): los módulos de alto nivel no dependen de los de bajo nivel, ambos dependen de una abstracción.

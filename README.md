# CRUD de Personas con ASP.NET Core y SQL Server

Este es un proyecto sencillo desarrollado con ASP.NET Core y Entity Framework Core que implementa operaciones CRUD (Crear, Leer, Actualizar, Eliminar) para una entidad Persona. La base de datos utilizada es SQL Server.

## 🧱 Tecnologías utilizadas

- ASP.NET Core
- Entity Framework Core
- SQL Server
- Visual Studio
- C#
- Docker (opcional, si se usó contenedor para SQL Server)

## 📦 Características del proyecto

- CRUD completo para la entidad Persona.
- Conexión a base de datos SQL Server utilizando EF Core.
- Migraciones aplicadas mediante Entity Framework.
- Arquitectura sencilla ideal para aprender lo básico de ASP.NET y bases de datos relacionales.

## 📄 Estructura de la entidad Persona

```csharp
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

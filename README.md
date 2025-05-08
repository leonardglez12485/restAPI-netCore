# TestAPI

TestAPI es una API desarrollada en .NET 9.0 que utiliza Entity Framework Core y Swashbuckle para la generación de documentación Swagger. Este proyecto incluye controladores para manejar datos de personas y pronósticos del clima.

## Características

- **Framework**: .NET 9.0
- **Base de datos**: SQLite y SQL Server (compatibilidad con Entity Framework Core)
- **Documentación**: Swagger (Swashbuckle)
- **Controladores**:
  - `PersonController`: Gestión de datos de personas.
  - `WeatherForecastController`: Pronósticos del clima.

## Estructura del Proyecto

```
├── Controllers/
│   ├── DemoController.cs
│   ├── HomeController.cs
│   ├── PersonController.cs
│   └── WeatherForecastController.cs
├── Data/
│   └── DataContex.cs
├── Entities/
│   └── Person.cs
├── Migrations/
│   ├── 20250508173336_InitialMigrations.cs
│   ├── 20250508173336_InitialMigrations.Designer.cs
│   └── DataContexModelSnapshot.cs
├── appsettings.json
├── Program.cs
├── TestAPI.csproj
└── README.md
```

## Requisitos Previos

- .NET SDK 9.0 o superior
- SQLite o SQL Server para la base de datos
- Visual Studio Code (opcional)

## Configuración

1. Clona este repositorio:
   ```bash
   git clone <URL_DEL_REPOSITORIO>
   cd TestAPI
   ```

2. Configura las variables de entorno en el archivo `.env` (si es necesario).

3. Restaura las dependencias:
   ```bash
   dotnet restore
   ```

4. Aplica las migraciones de la base de datos:
   ```bash
   dotnet ef database update
   ```

## Ejecución

Para ejecutar el proyecto en modo desarrollo:

```bash
dotnet run
```

La API estará disponible en `http://localhost:5000`.

## Documentación Swagger

Accede a la documentación Swagger en:

```
http://localhost:5000/swagger
```

## Pruebas

Para ejecutar las pruebas (si están configuradas):

```bash
dotnet test
```

## Contribuciones

Las contribuciones son bienvenidas. Por favor, abre un issue o un pull request para sugerir mejoras.

## Licencia

Este proyecto está bajo la licencia MIT. Consulta el archivo `LICENSE` para más detalles.
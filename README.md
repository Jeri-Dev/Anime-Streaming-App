
# Anime-Streaming-App

Este es un proyecto de practica para la universidad, el cual consta de Cruds de generos, productoras y series donde tambien hay un gran numero de filtros y reproduccion "Streaming" de los animes por pantalla.





## Herramientas necesarias

- SQL Server
- Entity Framework
- .NET 8



## Features

- CRUD de Generos 
- CRUD de Prdouctoras
- CRUD de Series usando los antes mencioandos
- Filtros de busqueda
- Filtros por Genero, productoras, de A-Z y de Z-A
- Reproduccion de cada anime en pantalla diferente



## Screenshots

![App Screenshot](https://via.placeholder.com/468x300?text=App+Screenshot+Here)


![App Screenshot](https://via.placeholder.com/468x300?text=App+Screenshot+Here)


![App Screenshot](https://via.placeholder.com/468x300?text=App+Screenshot+Here)


## Usage Requirements

Para usar la aplicacion debe tener sql server y en el archivo 
appsettings.Development.json cambiar el nombre de la Database 
y el nombre del servidor de tu SQL Server
```
{
  "ConnectionStrings": {
    "DefaultConn": "Server= <YourServerName> ;Database= <YourDatabaseName> ;Trusted_Connection=true;TrustServerCertificate=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```


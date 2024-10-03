# NetforemostAPI

API web construida con .NET 8, diseñada para gestionar la asignación de saldos a diferentes gestores, esta permite  obtener la lista de gestores y los saldos asignados a cada uno.

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Instalación

1. Clona el repositorio:

   ```bash
   git clone https://github.com/LorenzoSanchez00/Back-NetForemost.git
   cd NetforemostAPI
   ```

2. Restaura las dependencias:

  ```bash
  dotnet restore
  ```

3. Configura la cadena de conexión en appsettings.json:

  ```json
  "ConnectionStrings": {
    "Connection": "Server= TuServidor; Database=NombreDB; Trusted_Connection=True; TrustServerCertificate=True"}
  ```

4. Crea la BBDD con el archivo: **SQL-Scripts.txt**

## Uso

La API proporciona los siguientes endpoints:

**Obtener Gestores**

Método GET:
  ```C#
  /api/Saldos/gestores
  ```

*Descripción:* Obtiene una lista de todos los gestores.

**Obtener Saldos Asignados**

Método GET: 
  ```C#
  /api/Saldos
  ```

*Descripción:* Obtiene la lista de saldos asignados a cada gestor.

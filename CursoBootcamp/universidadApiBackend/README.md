
# Comandos Básicos de Entity Framework Core

1. Add-Migration
    ```bash
    Add-Migration <NombreDeLaMigración>
    ```
    
    Este comando se utiliza para crear una nueva migración basada en los cambios que has hecho en tu modelo de datos (clases de entidad). Una migración es un conjunto de instrucciones para actualizar la base de datos a un nuevo estado.
    
    * Ejemplo: Add-Migration Inicial

2. Update-Database

    ```bash
    Update-Database
    ```
    Aplica las migraciones pendientes a la base de datos. Si especificas el nombre de una migración, la base de datos se actualizará a ese estado.
    
    * Ejemplo: Update-Database 


3. Remove-Migration

    ```bash
    Remove-Migration
    ```
    Este comando elimina la última migración creada, siempre y cuando no haya sido aplicada a la base de datos.
    
    * Ejemplo: Remove-Migration 

4. Get-Help

    ```bash
    Get-Help <NombreDelComando>
    ```
    Proporciona información sobre cómo utilizar un comando específico.
    
    * Ejemplo: Get-Help Add-Migration 

5. Scaffold-DbContext

    ```bash
    Scaffold-DbContext "<CadenaDeConexion>" <Proveedor> -OutputDir <DirectorioDeSalida>
    ```
    
    Genera las clases de entidad y el contexto de base de datos a partir de una base de datos existente. Este comando es útil para la ingeniería inversa.
    
    * Ejemplo: Scaffold-DbContext "Server=.;Database=MiBaseDeDatos;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

## Comandos Adicionales de Entity Framework Core

6. Script-Migration

    ```bash
    Script-Migration [-From <DeMigración>] [-To <AMigración>]
    ```
    Genera un script SQL para aplicar migraciones desde un estado específico de la base de datos a otro.
    
    * Ejemplo: Script-Migration -From Inicial -To Actualizacion 
    
 7. Drop-Database

    ```bash
    Drop-Database
    ```
    Elimina la base de datos actual. Este comando es útil si necesitas comenzar de nuevo con la estructura de la base de datos.
    
    * Ejemplo: Drop-Database

### Ejemplos de Uso Combinado

Crear una Nueva Migración y Actualizar la Base de Datos

```bash
Add-Migration AñadirNuevaTabla
Update-Database
```

Eliminar la Última Migración
```bash
Remove-Migration
```
Ingeniería Inversa de una Base de Datos Existente
```bash
Scaffold-DbContext "Server=.;Database=MiBaseDeDatos;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```


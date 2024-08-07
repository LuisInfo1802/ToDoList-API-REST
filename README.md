# Proyecto de API de Tareas

Este proyecto es una API de ejemplo para gestionar tareas utilizando ASP.NET Core y MySQL. A continuación, se detallan los pasos necesarios para configurar y ejecutar el proyecto, así como los endpoints disponibles.

## Requisitos

- **Visual Studio 2022**
  - Instala las cargas de trabajo **Desarrollo de ASP.NET y web** y **Desarrollo de escritorio de .NET** a través del Visual Studio Installer.
  
  ![Screenshot](https://i.postimg.cc/VvncYt4G/img1.png)

- **MySQL**
  - Importa el archivo **Query tasks.sql** en MySQL. Inicia sesión en tu localhost, selecciona **File** y luego **Open SQL Script** para abrir y ejecutar el archivo SQL.

  ![Screenshot](https://i.postimg.cc/Dw8P83tG/imagen-2024-08-06-231128241.png)

## Configuración en Visual Studio

- **Modificar `appsettings.json`**
  - Antes de ejecutar el proyecto, ajusta la propiedad `MySqlConnection` con tus credenciales de MySQL. La configuración por defecto es:

    ```json
    "AllowedHosts": "*",
    "ConnectionStrings": {
      "MySqlConnection": "server=localhost;port=3306;database=task;uid=root;password=root"
    }
    ```

  - Cambia los valores de `server`, `port`, `database`, `uid`, y `password` según tu configuración.

## Endpoints de la API

- **Insertar una nueva tarea (POST)**
  - URL: `https://localhost:7296/api/Tasks`
  - Ejemplo de JSON:
    ```json
    {
      "title": "Tarea test01",
      "description": "Test01 task01",
      "isComplete": false,
      "createAt": "2024-08-07T05:25:51.524Z"
    }
    ```

- **Obtener todas las tareas (GET)**
  - URL: `https://localhost:7296/api/Tasks`
  - Respuesta JSON:
    ```json
    [
      {
        "id": 2,
        "title": "Tarea test01",
        "description": "Test01 task01",
        "isComplete": false,
        "createAt": "2024-08-07T05:25:52"
      },
      {
        "id": 3,
        "title": "Tarea test02",
        "description": "Test01 task02 prueba",
        "isComplete": true,
        "createAt": "2024-08-07T05:25:52"
      }
    ]
    ```

- **Obtener una tarea específica (GET)**
  - URL: `https://localhost:7296/api/Tasks/{id}`
  - Respuesta JSON:
    ```json
    {
      "id": 2,
      "title": "Tarea test01",
      "description": "Test01 task01",
      "isComplete": false,
      "createAt": "2024-08-07T05:25:52"
    }
    ```

- **Modificar una tarea específica (PUT)**
  - URL: `https://localhost:7296/api/Tasks/`
  - Ejemplo de JSON:
    ```json
    {
      "id": 2,
      "title": "Modificado",
      "description": "Tarea02 test Modify",
      "isComplete": false,
      "createAt": "2026-12-02T05:36:57.513Z"
    }
    ```

- **Eliminar una tarea específica (DELETE)**
  - URL: `https://localhost:7296/api/Tasks?id=3`
  - Respuesta: Un mensaje con el código 200 indicando que la tarea fue eliminada correctamente.

## Notas Adicionales

- Asegúrate de que MySQL esté corriendo y accesible en el `localhost` con las credenciales proporcionadas.
- Verifica que la base de datos y las tablas se hayan creado correctamente después de ejecutar el script SQL.

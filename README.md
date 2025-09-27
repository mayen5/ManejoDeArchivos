# Manejo de Archivos en C# (.NET 6)

Proyecto de consola que demuestra operaciones básicas de entrada/salida (E/S) con archivos y directorios usando la biblioteca estándar de .NET. Es útil para aprender a:

- Leer archivos de texto línea por línea
- Crear y escribir archivos
- Anexar contenido (editar sin borrar lo existente)
- Sobrescribir archivos
- Verificar existencia de archivos
- Eliminar archivos
- Crear directorios

## Requisitos

- Visual Studio Community 2022 (con el framework ".NET Desktop Development")
- .NET 6 SDK (se instala junto con Visual Studio si se selecciona el framework adecuado)
- Windows 10/11 (el proyecto utiliza rutas de ejemplo de Windows)

## Estructura del proyecto

- ManejoDeArchivos/
  - ManejoDeArchivos/Program.cs
  - ManejoDeArchivos/Archivos/Archivo.txt (archivo de ejemplo)

## Funcionalidades principales

- leerArchivo(): lee un archivo de texto línea por línea con StreamReader y muestra la ruta utilizada.
- escribirArchivo(): crea el archivo nuevoArchivo.txt y escribe varias líneas de ejemplo.
- editarArchivo(): abre nuevoArchivo.txt en modo anexar (append) y agrega contenido y fecha/hora.
- sobreEscribirArchivo(): reemplaza por completo el contenido de nuevoArchivo.txt si existe.
- existeArchivo(): confirma si nuevoArchivo.txt existe en la ruta configurada.
- eliminarArchivo(): elimina nuevoArchivo.txt si existe.
- crearCarpeta(): crea la carpeta OtrosArchivos dentro de la ruta base si no existe.

Todas estas funciones usan Path.Combine y las clases File, Directory, StreamReader y StreamWriter de System.IO.

## Configuración de rutas

En Program.cs existe una variable path que apunta a un directorio absoluto del proyecto. Para que leerArchivo funcione con el archivo de ejemplo incluido (ManejoDeArchivos/Archivos/Archivo.txt), hay dos opciones:

1) Mantener path apuntando al directorio del proyecto y ajustar el nombre del archivo:
   - nombreArchivo = "Archivos/Archivo.txt"

2) Evitar rutas absolutas y resolver la ruta del proyecto en tiempo de ejecución:

```csharp
// Obtiene la carpeta raíz del proyecto en tiempo de ejecución (útil para depuración)
var basePath = AppContext.BaseDirectory;
var projectRoot = Path.GetFullPath(Path.Combine(basePath, "..", "..", ".."));

// Ahora se puede usar projectRoot como path base
string path = projectRoot;
string rutaArchivo = Path.Combine(path, "Archivos", "Archivo.txt");
```

Recomendación: prefiera rutas relativas basadas en AppContext.BaseDirectory para que el código sea portable.

## Ejecución en Visual Studio Community 2022

1) Abrir Visual Studio Community 2022.
2) Archivo > Abrir > Proyecto/Solución... y seleccionar:
   - ManejoDeArchivos/ManejoDeArchivos.csproj (o la solución si existe).
3) En el Explorador de soluciones, clic derecho sobre el proyecto ManejoDeArchivos > "Establecer como proyecto de inicio".
4) Opcional: ajustar la variable Program.path o migrar a rutas relativas siguiendo la sección "Configuración de rutas".
5) En Program.Main, descomentar la llamada al método que desea probar (por ejemplo, leerArchivo();, crearCarpeta();, etc.).
6) Ejecutar con F5 (Depurar) o Ctrl+F5 (Iniciar sin depurar). La salida aparecerá en la ventana de consola.

Visual Studio restaurará automáticamente los paquetes necesarios y compilará el proyecto antes de ejecutar.

## Buenas prácticas aplicadas y sugeridas

- Disposición de recursos con using/using var para liberar manejadores de archivos automáticamente.
- Manejo de excepciones con try/catch e impresión de mensajes de error.
- Uso de Path.Combine para construir rutas de forma segura e independiente del sistema operativo.
- Sugerido: capturar excepciones específicas (IOException, UnauthorizedAccessException) para diagnósticos más claros.
- Sugerido: usar codificación UTF-8 explícita si el archivo contiene caracteres especiales.

## Próximos pasos (mejoras sugeridas)

- Versiones asíncronas: File.ReadAllTextAsync, StreamReader.ReadLineAsync, etc.
- Inyección de dependencias del sistema de archivos con System.IO.Abstractions para facilitar pruebas unitarias.
- Agregar argumentos de línea de comandos para elegir la operación a ejecutar.
- Registrar eventos y errores usando Microsoft.Extensions.Logging.
- Agregar pruebas unitarias (xUnit/NUnit) para validar cada operación de E/S.

## Autor

Carmelo Mayén

## Aviso

Este repositorio es educativo y no define una licencia explícita. Si piensa reutilizar el código en producción, agregue una licencia y revise las prácticas de seguridad y manejo de errores acordes a su caso de uso.

using System.Dynamic;
using System.Threading.Channels;

class Program
{
    public static string path = @"D:\Users\cmayen\source\repos\ManejoDeArchivos\ManejoDeArchivos\Archivos\";

    public static void leerArchivo()
    {
        string nombreArchivo = "archivo.txt";
        string rutaArchivo = Path.Combine(path, nombreArchivo);

        if (File.Exists(rutaArchivo))
        {
            using (StreamReader sr = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                }
                Console.WriteLine();
                Console.WriteLine("Se esta leyendo el archivo desde la ruta: " + rutaArchivo);
            }
        }
        else
        {
            Console.WriteLine("El archivo no existe en la ruta: " + rutaArchivo);
        }

    }

    public static void escribirArchivo()
    {
        string nombreArchivo = "nuevoArchivo.txt";
        string rutaArchivo = Path.Combine(path, nombreArchivo);

        using(StreamWriter sw = File.CreateText(rutaArchivo))
        {
            sw.WriteLine("Hola mundo!");
            sw.WriteLine("Estamos creando un archivo de texto");
            sw.WriteLine("Curso: 008 - Algoritmos - UMG Chiquimulilla, Santa Rosa");
        }

        Console.WriteLine("Archivo creado exitosamente en la ruta: " + rutaArchivo);
    }

    public static void editarArchivo()
    {
        string nombreArchivo = "nuevoArchivo.txt";

        string rutaCompleta = Path.Combine(path, nombreArchivo);

        try
        {
            using (StreamWriter sw = new StreamWriter(rutaCompleta, true))
            {
                sw.WriteLine("Este es el nuevo contenido del archivo.");
                sw.WriteLine("Estamos editando un archivo.");
                sw.WriteLine("");
                sw.WriteLine(DateTime.Now);
            }

            Console.WriteLine("El Contenido se agrego correctamente");
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error al editar el archivo: {ex.Message}");
        }
    }

    public static void sobreEscribirArchivo()
    {
        string nombreArchivo = "nuevoArchivo.txt";

        string rutaCompleta = Path.Combine (path, nombreArchivo);

        try
        {
            if (File.Exists(rutaCompleta))
            {
                using (StreamWriter sw = File.CreateText(rutaCompleta))
                {
                    sw.WriteLine("Este es le nuevo contenido");
                    sw.WriteLine("Estamos sobreescribiendo el archivo");
                    sw.WriteLine("");
                    sw.WriteLine("Santa Rosa " + DateTime.Now);

                }
                Console.WriteLine("Archivo editado correctamente");
            }
            else
            {
                Console.WriteLine("El archivo no existe");
            }

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error al editar el archivo: {ex.Message}");

        }


    }

    public static bool existeArchivo() {
        string nombreArchivo = "nuevoArchivo.txt";
        string rutaArchivo = Path.Combine(path, nombreArchivo);

        if (File.Exists(rutaArchivo))
        {
            Console.WriteLine("El archivo: " + nombreArchivo + " existe");
            return true;
        }
        else {
            Console.WriteLine("El archivo no existe");
            return false;
        }
    }

    public static void eliminarArchivo()
    {
        string nombreArchivo = "nuevoArchivo.txt";
        string rutaArchivo = Path.Combine (path, nombreArchivo);

        if (existeArchivo())
        {
            File.Delete(rutaArchivo);
            Console.WriteLine("El archivo se elimino correctamente");
        }
    }

    public static void crearCarpeta()
    {
        string nombreCarpeta = "OtrosArchivos";
        string pathPrincipal = @"D:\Users\cmayen\source\repos\ManejoDeArchivos\ManejoDeArchivos";

        string rutaCompleta = Path.Combine(pathPrincipal, nombreCarpeta);

        try
        {
            if (!Directory.Exists(rutaCompleta))
            {
                Directory.CreateDirectory(rutaCompleta);
                Console.WriteLine("Carpeta fue creada exitosamente");
            }
            else 
            {
                Console.WriteLine("La carpeta ya existe");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error al crear la carpeta: {ex.Message}");

        }
    }

    static void Main()
    {
        //leerArchivo();
        //escribirArchivo();
        //editarArchivo();
        //sobreEscribirArchivo();
        //existeArchivo();
        //eliminarArchivo();
        crearCarpeta();
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Linq.Expressions;

using Singleton;

namespace Interfaz
{
    internal class FileManager : IDisposable
    {
        public FileManager()
        {
            while (true)
            {
                string seleccion = "default";

                Logging.Instance.Log("FileManager inicializado");

                Console.WriteLine("Lector y Escritor de Archivos TXT");
                Separacion();
                Console.WriteLine("Ingrese su Opción Preferida");
                Console.WriteLine("1 - Leer un Archivo");
                Console.WriteLine("2 - Escribir en un Archivo");
                Console.WriteLine("3 - Delete un Archivo");
                Console.WriteLine("4 - Salir");
                Separacion();

                try
                {
                    seleccion = Console.ReadLine();
                    Logging.Instance.Log($"Usuario eligio como seleccion: {seleccion}");

                    if (seleccion == null)
                    {
                        Logging.Instance.Log("Selección Nula. ArgumentNullException");
                        throw new ArgumentNullException("Se ingreso una Selección Nula");
                    }
                }
                catch (Exception ex)
                {
                    string errorMessage = "Excepción Generica al Momento de Ingresar una Selección." + ex.Message;
                    Console.WriteLine(errorMessage);
                    Logging.Instance.Log($"Error: {errorMessage}");
                }

                Separacion();

                try
                {
                    switch (seleccion)
                    {
                        case "1":
                            Logging.Instance.Log("Usuario decidio leer un Archivo");
                            leerArchivo();
                            break;

                        case "2":
                            Logging.Instance.Log("Usuario decidio escribir en un Archivo");
                            escribirArchivo();
                            break;

                        case "3":
                            Logging.Instance.Log("Usuario decidio borrar un Archivo");
                            borrarArchivo();
                            break;

                        case "4":
                            Logging.Instance.Log("Usuario decidio salir del FileManager");
                            return;
                            break;

                        default:
                            Logging.Instance.Log("Intento de Ingreso Incorrecto en Selección FileManager");
                            Console.WriteLine("Ingreso Incorrecto");
                            Separacion();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    string errorMessage = "Excepción Generica al Momento de Ingresar una Selección." + ex.Message;
                    Console.WriteLine(errorMessage);
                    Logging.Instance.Log($"Error: {errorMessage}");
                }
            }
        }

        public void Dispose()
        {
            // Donde iría el Código para hacer Dispose si tuviese Recursos no Administrados
            // La Clase no hace uso de Recusos no Administrados, por ende no es necesario el Dispose

            // Sí filePath fuere una Variable de la Clase y no se generase Localmente en cada Función,
            // se podría poner filePath = String.empty para liberar los Recursos que ocupa
        }

        public void Separacion()
        {
            for (int i = 0; i != 49; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine('-');
        }

        int setTotalRows(string convertThis) 
        {
            int totalRows = Convert.ToInt32(convertThis);
            Logging.Instance.Log($"Se intento setear totalRows a: {convertThis}");
            Logging.Instance.Log($"totalRows debería quedar como: {totalRows}");

            if (totalRows <= 0)
            {
                Logging.Instance.Log("Ya que totalRows es menor o igual a 0 se da un Excepción");
                throw new ArgumentOutOfRangeException("No puede Ingresar 0 o Negativas Líneas");
            }

            return totalRows;
        }

        public void leerArchivo()
        {
            Logging.Instance.Log("Función para Leer Archivo Iniciada");
            string filePath = "default";
            Console.WriteLine("Ingrese la Dirección de su Archivo");
            Separacion();

            try
            {
                filePath = Console.ReadLine();
                Logging.Instance.Log($"filePath ingresado: {filePath}");
                if (filePath == null)
                {
                    Logging.Instance.Log("filePath esta vacío. Excepción");
                    throw new ArgumentNullException("No puede estar Vacío el FilePath");
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Excepción Generica." + ex.Message;
                Console.WriteLine(errorMessage);
                Logging.Instance.Log($"Error: {errorMessage}");
            }

            Separacion();

            try
            {
                if (!File.Exists(filePath))
                {
                    Logging.Instance.Log("El Archivo ingresado no existe :(");
                    Console.WriteLine("El Archivo no Existe");
                    Separacion();
                    return;
                }

                using (StreamReader sr = new StreamReader(filePath))
                {
                    Logging.Instance.Log("Leyendo el Archivo :)");
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (FileNotFoundException ex)
            {
                Logging.Instance.Log($"Error de FileNotFoundException. {ex.Message}");
                Console.WriteLine("No se encontro el Archivo. Error " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logging.Instance.Log($"Error de UnauthorizedAccessException. {ex.Message}");
                Console.WriteLine("No hay Acceso al Archivo. Error " + ex.Message);
            }
            catch (IOException ex)
            {
                Logging.Instance.Log($"Error de IOException. {ex.Message}");
                Console.WriteLine("Fallo en el IO. Error " + ex.Message);
            }
            catch (System.Exception ex)
            {
                Logging.Instance.Log($"Error Generico. {ex.Message}");
                Console.WriteLine("Error en la Lectura del Archivo. Error " + ex.Message);
            }
            Separacion();
            return;
        }

        public void escribirArchivo()
        {
            Logging.Instance.Log("Función de Escribir Archivo iniciada");
            string filePath = "default";
            Console.WriteLine("Ingrese la Dirección de su Archivo");
            Separacion();

            try
            {
                filePath = Console.ReadLine();
                Logging.Instance.Log($"FilePath de Archivo a Escribir Ingresado. {filePath}");
                if (filePath == null)
                {
                    Logging.Instance.Log("filePath esta nulo. Excepción de ArgumentNullException");
                    throw new ArgumentNullException("No puede estar Vacío el FilePath");
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Excepción Generica." + ex.Message;
                Console.WriteLine(errorMessage);
                Logging.Instance.Log($"Error: {errorMessage}");
            }

            Separacion();

            if (!File.Exists(filePath))
            {
                Logging.Instance.Log($"Archivo no Existe. {filePath}");
                Console.WriteLine("El Archivo no Existe");
                Separacion();
                return;
            }

            int totalRows = 0;
            try
            {
                Console.WriteLine("¿Cuántas Líneas quiere Ingresar?");
                Separacion();
                totalRows = setTotalRows(Console.ReadLine());
                Separacion();
                Logging.Instance.Log($"Lineas a Ingresar. {totalRows}");
            }
            catch (ArithmeticException ex)
            {
                Logging.Instance.Log($"AirthmeticException. {ex.Message}");
                Console.WriteLine("Error al Momento de Obtener el Total de Lineas a Ingresar. Error " + ex.Message);
            }
            catch (FormatException ex) 
            {
                Logging.Instance.Log($"FormatException. {ex.Message}");
                Console.WriteLine("Error con el Formato de los Números. Ingreso una Letra.");
            }


            Console.WriteLine("Líneas Totales: " + totalRows);
            Separacion();
            try
            {
                for (int i = 0; i != totalRows; i++)
                {
                    Console.WriteLine("Ingrese la Linea " + (i + 1));
                    using (StreamWriter sw = new StreamWriter(filePath, true))
                    {
                        sw.WriteLine("");
                        sw.WriteLine(Console.ReadLine());
                    }
                    Separacion();
                }
            }
            catch (FileNotFoundException ex)
            {
                Logging.Instance.Log($"Error de FileNotFoundException. {ex.Message}");
                Console.WriteLine("No se encontro el Archivo. Error " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logging.Instance.Log($"Error de UnauthorizedAccessException. {ex.Message}");
                Console.WriteLine("No hay Acceso al Archivo. Error " + ex.Message);
            }
            catch (IOException ex)
            {
                Logging.Instance.Log($"Error de IOException. {ex.Message}");
                Console.WriteLine("Fallo en el IO. Error " + ex.Message);
            }
            catch (System.Exception ex)
            {
                Logging.Instance.Log($"Error Generico. {ex.Message}");
                Console.WriteLine("Error en la Lectura del Archivo. Error " + ex.Message);
            }
            return;
        }

        public void borrarArchivo()
        {
            Logging.Instance.Log("Función de Borrar Archivo iniciada");
            string filePath = "default";
            Console.WriteLine("Ingrese la Dirección de su Archivo");
            Separacion();

            try
            {
                filePath = Console.ReadLine();
                Logging.Instance.Log($"filePath ingresado: {filePath}");
                if (filePath == null)
                {
                    Logging.Instance.Log("filePath esta nulo. Excepción de ArgumentNullException");
                    throw new ArgumentNullException("No puede estar Vacío el FilePath");
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Excepción Generica." + ex.Message;
                Console.WriteLine(errorMessage);
                Logging.Instance.Log($"Error: {errorMessage}");
            }


            Separacion();

            if (!File.Exists(filePath))
            {
                Logging.Instance.Log("El Archivo ingresado no existe :(");
                Console.WriteLine("El Archivo no Existe");
                Separacion();
                return;
            }

            try
            {
                File.Delete(filePath);
            }
            catch (FileNotFoundException ex)
            {
                Logging.Instance.Log($"Error de FileNotFoundException. {ex.Message}");
                Console.WriteLine("No se encontro el Archivo. Error " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logging.Instance.Log($"Error de UnauthorizedAccessException. {ex.Message}");
                Console.WriteLine("No hay Acceso al Archivo. Error " + ex.Message);
            }
            catch (IOException ex)
            {
                Logging.Instance.Log($"Error de IOException. {ex.Message}");
                Console.WriteLine("Fallo en el IO. Error " + ex.Message);
            }
            catch (System.Exception ex)
            {
                Logging.Instance.Log($"Error Generico. {ex.Message}");
                Console.WriteLine("Error en la Lectura del Archivo. Error " + ex.Message);
            }

            if (!File.Exists(filePath))
            {
                Logging.Instance.Log("Se borro el Archivo exitosamente");
                Console.WriteLine("Borrado con Exito!");
            }

            Separacion();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Interfaz
{
    internal class Menu : IDisposable
    {
        public Menu()
        {
            while (true)
            {
                string seleccion;

                Console.WriteLine("Lector y Escritor de Archivos TXT");
                Separacion();
                Console.WriteLine("Ingrese su Opción Preferida");
                Console.WriteLine("1 - Leer un Archivo");
                Console.WriteLine("2 - Escribir en un Archivo");
                Console.WriteLine("3 - Delete un Archivo");
                Console.WriteLine("4 - Salir");

                Separacion();
                seleccion = Console.ReadLine();
                Separacion();

                try
                {
                    switch (seleccion)
                    {
                        case "1":
                            leerArchivo();
                            break;

                        case "2":
                            escribirArchivo();
                            break;

                        case "3":
                            borrarArchivo();
                            break;

                        case "4":
                            return;
                            break;

                        default:
                            Console.WriteLine("Ingreso Incorrecto");
                            Separacion();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
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

        public void leerArchivo()
        {
            Console.WriteLine("Ingrese la Dirección de su Archivo");
            Separacion();
            string filePath = Console.ReadLine();
            Separacion();

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("El Archivo no Existe");
                    Separacion();
                    return;
                }

                using (StreamReader sr = new StreamReader(filePath))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("No se encontro el Archivo. Error " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("No hay Acceso al Archivo. Error " + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Fallo en el IO. Error " + ex.Message);
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error en la Lectura del Archivo. Error " + e.Message);
            }
            Separacion();
            return;
        }

        public void escribirArchivo()
        {
            Console.WriteLine("Ingrese la Dirección de su Archivo");
            Separacion();
            string filePath = Console.ReadLine();
            Separacion();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("El Archivo no Existe");
                Separacion();
                return;
            }

            int totalRows = 0;
            try
            {
                Separacion();
                Console.WriteLine("¿Cuántas Líneas quiere Ingresar?");
                Separacion();
                totalRows = Convert.ToInt32(Console.ReadLine());
                Separacion();
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine("Error al Momento de Obtener el Total de Lineas a Ingresar. Error " + ex.Message);
            }

            if (totalRows <= 0)
            {
                Console.WriteLine("No puede escribir 0 o menos Lineas");
                Separacion();
                return;
            }

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
                Console.WriteLine("No se encontro el Archivo. Error " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("No hay Acceso al Archivo. Error " + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Fallo en el IO. Error " + ex.Message);
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error en la Escritura del Archivo. Error " + e.Message);
            }
            return;
        }

        public void borrarArchivo()
        {
            Console.WriteLine("Ingrese la Dirección de su Archivo");
            Separacion();
            string filePath = Console.ReadLine();
            Separacion();

            if (!File.Exists(filePath))
            {
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
                Console.WriteLine("No se encontro el Archivo. Error " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("No hay Acceso al Archivo. Error " + ex.Message);
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error en el borrado del Archivo. Error " + e.Message);
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Borrado con Exito!");
            }

            Separacion();
        }
    }
}

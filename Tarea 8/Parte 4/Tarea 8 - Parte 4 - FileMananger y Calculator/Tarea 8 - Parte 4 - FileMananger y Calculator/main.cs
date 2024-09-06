using System;
using System.Linq.Expressions;
using System.IO;

using Interfaz;
using Calculos;
using Singleton;

class FileManagerPlusCalculator
{
    public static void Separacion()
    {
        for (int i = 0; i != 49; i++)
        {
            Console.Write('-');
        }
        Console.WriteLine('-');
    }

    public static void Main(string[] args)
    {
        string seleccion = "default";

        Logging.Instance.Log("Aplicación Inicializada");

        while (true)
        {
            Console.WriteLine("FILEMANAGER Y CALCULADORA");
            Console.WriteLine("ELIGA A CUAL FUNCIONALIDAD QUIERE ACCEDER");
            Separacion();
            Console.WriteLine("1 - FileManager");
            Console.WriteLine("2 - Calculadora");
            Console.WriteLine("3 - Salir");
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
                        Logging.Instance.Log("Usuario accedio a la Funcionalidad de FileManager");
                        FileManager fileManager = new FileManager();
                        break;

                    case "2":
                        Logging.Instance.Log("Usuario accedio a la Funcionalidad de la Calculadora");
                        Calculadora calculator = new Calculadora();
                        break;

                    case "3":
                        Logging.Instance.Log("Usuario decidio cerrar el Programa");
                        return;
                        break;

                    default:
                        Logging.Instance.Log("Intento de Ingreso no Valido Registrado");
                        Console.WriteLine("Ingreso no Valido. Vuelva a Intentarlo");
                        Separacion();
                        break;
                }
            }
            catch (Exception e) 
            {
                string errorMessage = "Error Generico:" + e.Message;
                Console.WriteLine(errorMessage);
                Logging.Instance.Log(errorMessage);
            }
        }
    }
}




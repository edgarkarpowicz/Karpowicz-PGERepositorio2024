using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Singleton;

namespace Calculos
{
    internal class Calculadora : IDisposable
    {
        int numeroOne;
        int numeroTwo;
        string operador;

        public void Separacion()
        {
            for (int i = 0; i != 49; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine('-');
        }
        public void Dispose()
        {
            // No hace uso de Recursos no Administrados
        }

        public Calculadora()
        {
            while (true)
            {
                string seleccion = "default";

                Logging.Instance.Log("Calculadora inicializada");

                Console.WriteLine("Calculadora");
                Separacion();
                Console.WriteLine("Ingrese su Opción Preferida");
                Console.WriteLine("1 - Ingresar una Operación");
                Console.WriteLine("2 - Salir");

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
                            Logging.Instance.Log("Usuario decidio ingresar una Operación");
                            Operacion();
                            break;

                        case "2":
                            Logging.Instance.Log("Usuario decidio salir de la Calculadora");
                            return;
                            break;

                        default:
                            Logging.Instance.Log("Ingreso no Valido registrado.");
                            Console.WriteLine("Ingreso no Valido. Vuelva a Intentarlo");
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

        public void setNumeroOne()
        {
            Logging.Instance.Log("Seteando el numeroOne");
            try
            {
                numeroOne = Convert.ToInt32(Console.ReadLine());
                Logging.Instance.Log($"numeroOne. {numeroOne}");
            }
            catch (FormatException e)
            {
                Logging.Instance.Log($"Excepción de Formato. {e.Message}");
                Console.WriteLine("Excepción de Formato" + e.ToString());
                Console.WriteLine("Utilizando un Valor de Default");
                numeroOne = 5;
            }
            catch (Exception ex)
            {
                string errorMessage = "Excepción Generica." + ex.Message;
                Console.WriteLine(errorMessage);
                Logging.Instance.Log($"Error: {errorMessage}");
                numeroOne = 5;
            }

            return;
        }

        public void setNumeroTwo()
        {
            Logging.Instance.Log("Seteando el numeroTwo");
            try
            {
                numeroTwo = Convert.ToInt32(Console.ReadLine());
                Logging.Instance.Log($"numeroTwo. {numeroTwo}");
            }
            catch (FormatException e)
            {
                Logging.Instance.Log($"Excepción de Formato. {e.Message}");
                Console.WriteLine("Excepción de Formato" + e.ToString());
                Console.WriteLine("Utilizando un Valor de Default");
                numeroTwo = 10;
            }
            catch (Exception ex)
            {
                string errorMessage = "Excepción Generica." + ex.Message;
                Console.WriteLine(errorMessage);
                Logging.Instance.Log($"Error: {errorMessage}");
                numeroTwo = 10;
            }
        } 

        public void setOperador()
        {
            Logging.Instance.Log("Seteando el Operador");
            try
            {
                operador = Console.ReadLine();
                Logging.Instance.Log($"operador. {operador}");
                if (operador == null)
                {
                    Logging.Instance.Log($"operador nulo");
                    Console.WriteLine("Operador Nulo... Utilizando el de Default");
                    operador = "+";
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Excepción Generica." + ex.Message;
                Console.WriteLine(errorMessage);
                Logging.Instance.Log($"Error: {errorMessage}");
                operador = "+";
            }
        }

        public void Operacion()
        {
            Logging.Instance.Log("Operación Iniciada");

            Console.WriteLine("Ingrese su Primer Número:");
            Separacion();

            setNumeroOne();
            Separacion();

            Console.WriteLine("Ingrese su Segundo Número");
            Separacion();

            setNumeroTwo();
            Separacion();

            Console.WriteLine("Ingrese un Operador VALIDO. +, -, *, /");
            setOperador();
            Separacion();

            int resultado = 0;
            try
            {
                switch (operador)
                {
                    case "+":
                    Logging.Instance.Log("Suma");
                    resultado = numeroOne + numeroTwo;
                    break;

                    case "-":
                    Logging.Instance.Log("Resta");
                    resultado = numeroOne - numeroTwo;
                    break;

                    case "*":
                    Logging.Instance.Log("Multiplicación");
                    resultado = numeroOne * numeroTwo;
                    break;

                    case "/":
                    Logging.Instance.Log("División");
                    resultado = numeroOne / numeroTwo;
                    break;

                    default:
                    Logging.Instance.Log("Fallo con el Operador");
                    Console.WriteLine("Error obteniendo el Resultado. Hay un problema con el Operador");
                    resultado = 0;
                    break;
                }
            }
            catch (Exception ex) 
            {
                Logging.Instance.Log($"Excepción Generica haciendo el Calculo. {ex.Message}");
                Console.WriteLine("Excepcion Generica haciendo el Calculo." + ex.Message); 
            }

            Logging.Instance.Log($"Resultado Final:{resultado}");
            Console.WriteLine("El Resultado Final fue: " + resultado);
            Separacion();
        }
    }
}

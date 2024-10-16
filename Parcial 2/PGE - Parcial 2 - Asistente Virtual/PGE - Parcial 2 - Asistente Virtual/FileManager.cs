using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PGE___Parcial_2___Asistente_Virtual
{
    internal class FileManager // Clase que maneja toda la Interacción con los Archivos //
    {
        string filePath = "../Debug/comandos.txt"; // Dirección Relativa donde se va a guardar nuestro .TXT, es decir, nuestra Base de Datos //
        private Dictionary<(string palabraClave, string respuestaSynthesizer, string ProgramaEjecutar, string Argumento), bool> diccionarioComandos; // El FileManager para poder interactuar y recabar datos de los Comandos que tengamos tiene una Copia de los Comandos //

        public FileManager(Dictionary<(string palabraClave, string respuestaSynthesizer, string ProgramaEjecutar, string Argumento), bool> diccionarioComandos)
        { // Constructor de la Clase. Le damos al FileManager una Copia del Diccionario para que pueda interactuar con el mismo y guardar los Datos requeridos //
            this.diccionarioComandos = diccionarioComandos;
        }

        public Dictionary<(string palabraClave, string respuestaSynthesizer, string ProgramaEjecutar, string Argumento), bool> loadCustomCommands()
        { // Función para obtener los Comandos Custom de la Base de Datos //
            if (!File.Exists(filePath)) // Verifica si no existe el Archivo //
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(File.Open(filePath, System.IO.FileMode.Append))); // Si no existe generamos el Archivo .txt // 
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Acceso no Autorizado al Archivo de los Comandos Custom: " + ex.Message);
                    return null;
                }
                catch (PathTooLongException ex)
                {
                    MessageBox.Show("Path del Archivo de los Comandos Custom demasiado largo: " + ex.Message);
                    return null;
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error de IO accediendo al Archivo de los Comandos Custom: " + ex.Message);
                    return null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción Genérica accediendo al Archivo de los Comandos Custom: " + ex.Message);
                    return null;
                }
            }

            try
            { // Lee al Archivo hasta el final y va cargando lo que encuentre en el Diccionario //
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!(sr.EndOfStream))
                    {
                        string line = sr.ReadLine();

                        if (line != null)
                        {
                            pushDiccionario(line); // Función para cargar en el Diccionario //
                        }
                    }
                }
                return diccionarioComandos;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("No se pudo encontrar el Archivo de los Comandos Custom: " + ex.Message);
                return null;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("FilePath de los Comandos Custom esta nulo: " + ex.Message);
                return null;
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show("Directorio de los Comandos Custom no encontrado: " + ex.Message);
                return null;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error de IO cargando los Comandos Custom: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Génerico cargando los Comandos Custom: " + ex.Message);
                return null;
            }
        }

        private void pushDiccionario(string line)
        { // Función para cargar en el Diccionario los Comandos //
            string[] storage = new string[4];
            int i = 0;
            while (i != 4)
            {
                bool found = false;
                char temp;
                int position = 0;
                while (found != true && position != line.Length)
                {
                    temp = line.ElementAt(position);
                    if (temp == ',')
                    {
                        found = true;
                    }
                    else
                    {
                        position++;
                    }
                }
                storage[i] = line.Substring(0, position);
                if (i != 3)
                {
                    line = line.Remove(0, position + 2);
                }
                found = false;
                i++;
            }
            // Va leyendo al .txt y sabiendo que todos los comandos siguen un orden separados por , verifica la existencia de estas y va guardando en un Array //
            // Una vez llegado el momento, agrega al comando en el Diccionario //
            diccionarioComandos.Add((storage[0], storage[1], storage[2], storage[3]), true);
            return;
        }

        public void pushToFile(string palabraClave, string respuestaSynthesizer, string ProgramaEjecutar, string Argumento)
        { // Función para empujar a la Base de Datos un Comando //
            if (!File.Exists(filePath))
            {
                try // Si no existe el .txt lo creamos //
                {
                    using (StreamWriter sw = new StreamWriter(File.Open(filePath, System.IO.FileMode.Append))) ;
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Acceso no Autorizado al Archivo de los Comandos Custom: " + ex.Message);
                    return;
                }
                catch (PathTooLongException ex)
                {
                    MessageBox.Show("Path del Archivo de los Comandos Custom demasiado largo: " + ex.Message);
                    return;
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error de IO accediendo al Archivo de los Comandos Custom: " + ex.Message);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción Genérica accediendo al Archivo de los Comandos Custom: " + ex.Message);
                    return;
                }
            }

            try
            { // Escribimos en el .txt el Comando //
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(palabraClave + ", " + respuestaSynthesizer + ", " + ProgramaEjecutar + ", " + Argumento);
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("No se pudo encontrar el Archivo de los Comandos Custom: " + ex.Message);
                return;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("FilePath de los Comandos Custom esta nulo: " + ex.Message);
                return;
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show("Directorio de los Comandos Custom no encontrado: " + ex.Message);
                return;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error de IO agregando a los Comandos Custom: " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Génerico agregando a los Comandos Custom: " + ex.Message);
                return;
            }
        }
        public void pushDictionaryFromScratch()
        { // Recrea al Diccionario desde 0 //
            if (File.Exists(filePath))
            {
                try
                { // Si existe el Archivo directamente lo creamos desde 0 //
                    using (StreamWriter sw = new StreamWriter(File.Open(filePath, System.IO.FileMode.Create))) ;
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Acceso no Autorizado al Archivo de los Comandos Custom: " + ex.Message);
                    return;
                }
                catch (PathTooLongException ex)
                {
                    MessageBox.Show("Path del Archivo de los Comandos Custom demasiado largo: " + ex.Message);
                    return;
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error de IO accediendo al Archivo de los Comandos Custom: " + ex.Message);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción Genérica accediendo al Archivo de los Comandos Custom: " + ex.Message);
                    return;
                }
            }

            try
            { // Escribe todos los Comandos del Diccionario en el .txt, sobreescribiendo cualquier contenido que haya tenido //
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    for (int i = 0; i != diccionarioComandos.Count; i++)
                    {
                        var element = diccionarioComandos.ElementAt(i);

                        if (element.Value == true)
                        {
                            writer.WriteLine(element.Key.palabraClave + ", " + element.Key.respuestaSynthesizer + ", " + element.Key.ProgramaEjecutar + ", " + element.Key.Argumento);
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("No se pudo encontrar el Archivo de los Comandos Custom: " + ex.Message);
                return;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("FilePath de los Comandos Custom esta nulo: " + ex.Message);
                return;
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show("Directorio de los Comandos Custom no encontrado: " + ex.Message);
                return;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error de IO agregando a los Comandos Custom: " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Génerico agregando a los Comandos Custom: " + ex.Message);
                return;
            }
        }
    }
}

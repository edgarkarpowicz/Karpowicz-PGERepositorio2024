using System.Windows.Forms;
using System.IO;
using System.Linq.Expressions;

using Logger;

namespace Tarea_9___FileManager
{
    public partial class FileManager : Form
    {
        private string selectedFile;

        public FileManager()
        {
            Logging.Instance.Log("FileManager Inicializado");
            InitializeComponent();
        }

        private void BuscarArchivo_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Usuario se encuentra seleccionando un Archivo");
            OpenFileDialog ArchivoSeleccionado = new OpenFileDialog();

            ArchivoSeleccionado.InitialDirectory = "c:\\";
            ArchivoSeleccionado.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ArchivoSeleccionado.FilterIndex = 0;
            ArchivoSeleccionado.RestoreDirectory = true;

            if (ArchivoSeleccionado.ShowDialog() != DialogResult.OK)
            {
                Logging.Instance.Log("Fallo seleccionando el Archivo");
                return;
            }

            selectedFile = ArchivoSeleccionado.FileName;
            tboxArchivo.Text = selectedFile;
            Logging.Instance.Log($"Se selecciono un Archivo: {selectedFile}");
        }

        private bool archivoExiste()
        {
            Logging.Instance.Log("Verificando si el Archivo seleccionado existe...");
            if (!File.Exists(selectedFile))
            {
                Logging.Instance.Log("Archivo seleccionado no existe");
                System.Windows.Forms.MessageBox.Show("ADVERTENCIA: Archivo Seleccionado no Existe");
                return false;
            }

            Logging.Instance.Log("Archivo seleccionado existe");
            return true;
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            bool verification = archivoExiste();

            if (verification)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(selectedFile))
                    {
                        Logging.Instance.Log("Agregando salto de Línea en el Archivo");
                        rtbLectura.Text = "";
                        rtbLectura.Text += sr.ReadToEnd();
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Logging.Instance.Log($"No se encontro el Archivo ingresado: {ex.Message}");
                    Console.WriteLine("No se encontro el Archivo Ingresado" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCIÓN: Archivo Ingresado no se encontro");
                    return;
                }
                catch (UnauthorizedAccessException ex)
                {
                    Logging.Instance.Log($"No se pudo acceder al Archivo, acceso no autorizado: {ex.Message}");
                    Console.WriteLine("No se pudo acceder al Archivo" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCIÓN: Acceso no Autorizado al Archivo");
                    return;
                }
                catch (IOException ex)
                {
                    Logging.Instance.Log($"Error en el IO: {ex.Message}");
                    Console.WriteLine("Error en el IO" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCIÓN: Problema de IO leyendo el Archivo");
                    return;
                }
                catch (Exception ex)
                {
                    Logging.Instance.Log($"Error Genérico: {ex.Message}");
                    Console.WriteLine("Algo ha ido mal intentando leer el Archivo" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCIÓN: Excepción Genérica leyendo el Archivo");
                    return;
                }
            }
        }

        private void btnEscribir_Click(object sender, EventArgs e)
        {
            bool verification = archivoExiste();

            if (verification)
            {
                try
                {
                    if (File.ReadAllBytes(selectedFile).Length > 0)
                    {
                        using (StreamWriter sr = new StreamWriter(selectedFile, true))
                        {
                            sr.WriteLine("");
                        }
                    }

                    RichTextBox temporalBox = new RichTextBox();
                    temporalBox.LoadFile(selectedFile, RichTextBoxStreamType.PlainText);
                    temporalBox.Text += rtbEscritura.Text;

                    temporalBox.SaveFile(selectedFile, RichTextBoxStreamType.PlainText);
                }
                catch (FileNotFoundException ex)
                {
                    Logging.Instance.Log($"No se encontro el Archivo ingresado: {ex.Message}");
                    Console.WriteLine("No se encontro el Archivo Ingresado" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCIÓN: Archivo Ingresado no se encontro");
                    return;
                }
                catch (UnauthorizedAccessException ex)
                {
                    Logging.Instance.Log($"No se pudo acceder al Archivo, acceso no autorizado: {ex.Message}");
                    Console.WriteLine("No se pudo acceder al Archivo" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCIÓN: Acceso no Autorizado al Archivo");
                    return;
                }
                catch (IOException ex)
                {
                    Logging.Instance.Log($"Error en el IO: {ex.Message}");
                    Console.WriteLine("Error en el IO" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCIÓN: Problema de IO escribiendo el Archivo");
                    return;
                }
                catch (Exception ex)
                {
                    Logging.Instance.Log($"Error Genérico: {ex.Message}");
                    Console.WriteLine("Algo ha ido mal intentando escribir el Archivo" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCIÓN: Excepción Genérica escribiendo el Archivo");
                    return;
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            bool verification = archivoExiste();

            if (verification)
            {
                try
                {
                    File.Delete(selectedFile);

                    if (!File.Exists(selectedFile))
                    {
                        System.Windows.Forms.MessageBox.Show("Se borro el Archivo con Exito");
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Logging.Instance.Log($"No se encontro el Archivo ingresado: {ex.Message}");
                    Console.WriteLine("No se encontro el Archivo Ingresado" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCIÓN: Archivo Ingresado no se encontro");
                    return;
                }
                catch (UnauthorizedAccessException ex)
                {
                    Logging.Instance.Log($"No se pudo acceder al Archivo, acceso no autorizado: {ex.Message}");
                    Console.WriteLine("No se pudo acceder al Archivo" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCIÓN: Acceso no Autorizado al Archivo");
                    return;
                }
                catch (IOException ex)
                {
                    Logging.Instance.Log($"Error en el IO: {ex.Message}");
                    Console.WriteLine("Error en el IO" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCIÓN: Problema de IO borrando el Archivo");
                    return;
                }
                catch (Exception ex)
                {
                    Logging.Instance.Log($"Error Genérico: {ex.Message}");
                    Console.WriteLine("Algo ha ido mal intentando borrar el Archivo" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCIÓN: Excepción Genérica borrando el Archivo");
                    return;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Saliendo de la Aplicación");
            Application.Exit();
        }
    }
}

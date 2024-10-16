using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Speech.Recognition;
using System.Windows.Controls.Primitives;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Speech.Synthesis;
using System.Net.Mime;

using System.Threading;
using System.Windows.Diagnostics;
using System.Xml.Linq;

using System.IO;
using System.Runtime.Remoting.Messaging;
using System.ComponentModel;
using System.Collections;

namespace PGE___Parcial_2___Asistente_Virtual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SpeechRecognitionEngine recognizer; // Variable de Motor de Reconocimiento de Speech //
        string charName = "Jarvis"; // Nombre del ChatBot. Funciona como Palabra //
        SpeechSynthesizer synthesizer; // Variable para sintetizar texto como speech //
        FileManager fileManager; // Variable para el FileManager, que va a operar con los Archivos //

        // Bool representa si es un Comando creado por el Usuario o no. Para los Pre-Existentes es 0
        private Dictionary<(string palabraClave, string respuestaSynthesizer, string ProgramaEjecutar, string Argumento), bool> diccionarioComandos; // Diccionario donde vamos a almacenar todos nuestros Comandos de voz //
        int microfonoAbierto = 0; // Variable (PODRÍA SER BOOLEANA) que utilizamos para verificar si el Microfono esta Abierto //

        public MainWindow()
        {
            InitializeComponent();

            cargarDiccionario(); // Cargamos el Diccionario que tiene todos nuestros Comandos con los Comandos Pre-Existentes //
            loadSpeechRecognition(); // Inicializamos el Reconocimiento de Voz //
            getAllComandos(); // Conseguimos todos los Comandos para hacerles Display en un RichTextBox en la sección de ver comandos //
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Cierra la Aplicación //
        }

        private void cargarDiccionario() // Carga los Comandos Pre-Existentes en un Diccionario para facilitar el Trabajo con los mismos
        {
            diccionarioComandos = new Dictionary<(string palabraClave, string respuestaSynthesizer, string ProgramaEjecutar, string Argumento), bool>();

            diccionarioComandos.Add(("Hello", "Hello", "N/A", "N/A"), false);
            diccionarioComandos.Add(("What is your name", "My Name is Jarvis", "N/A", "N/A"), false);
            diccionarioComandos.Add(("Read the Commands", "N/A", "N/A", "N/A"), false);
            diccionarioComandos.Add(("Open Notepad", "Opening Notepad", "notepad.exe", "N/A"), false);
            diccionarioComandos.Add(("Open Youtube", "Opening Youtube", "chrome.exe", "youtube.com"), false);
            diccionarioComandos.Add(("Open Microsoft Email", "Opening Microsoft Email", "chrome.exe", "outlook.com"), false);
            diccionarioComandos.Add(("Open Google", "Opening Google", "chrome.exe", "N/A"), false);
            diccionarioComandos.Add(("Open Gmail", "Opening Gmail", "chrome.exe", "gmail.com"), false);
            diccionarioComandos.Add(("Open Studio", "Opening Microsoft Visual Studio", "devenv.exe", "N/A"), false);
            diccionarioComandos.Add(("Close the Application", "Closing myself", "N/A", "N/A"), false);
            diccionarioComandos.Add(("Initiate Fat Mode", "Initiating Fat Mode", "C:/Riot Games/Riot Client/RiotClientServices.exe", "N/A"), false);

            fileManager = new FileManager(diccionarioComandos); // Inicializa el FileManager y verifica si hay comandos custom cargados en la Base de Datos // 
            diccionarioComandos = fileManager.loadCustomCommands();
            return;
        }

        private Choices getLibreriaComandos()
        { // Carga todos los Comandos en una Variable de Choices que utiliza el SpeechRecognitionEngine para escuchar y comparar el Audio //
            Choices misChoices = new Choices();

            if (microfonoAbierto == 0)
            {
                for (int i = 0; i < diccionarioComandos.Count; i++)
                {
                    var element = diccionarioComandos.ElementAt(i);
                    string palabraClave = element.Key.palabraClave;
                    misChoices.Add(charName + " " + palabraClave);
                }
                return misChoices;
            }
            else
            {
                for (int i = 0; i < diccionarioComandos.Count; i++)
                {
                    var element = diccionarioComandos.ElementAt(i);
                    string palabraClave = element.Key.palabraClave;
                    misChoices.Add(palabraClave);
                }
                return misChoices;
            }
        }

        private void loadSpeechRecognition()
        { // Carga el Reconocimiento de Voz //
            synthesizer = new SpeechSynthesizer();

            try
            { // Inicializamos la Variable de SpeechRecognitionEngine con el Lenguaje de Ingles - Estados Unidos //
                recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            }
            catch (System.Globalization.CultureNotFoundException) // Si algo va mal, damos una advertencia y cerramos el Programa
            {
                MessageBox.Show("No tiene la Cultura / Datos de Lenguaje de Ingles - Estados Unidos instalados en Windows. Descargelos y vuelva a Intentarlo");
                btnSalir_Click(this, null);
            }
            catch (Exception) 
            {
                MessageBox.Show("Algo ha ido mal! Verifique que tiene la Cultura y Datos de Lenguaje de Ingles - Estados Unidos instalados en Windows");
                btnSalir_Click(this, null);
            }

            var grammarBuilder = new GrammarBuilder(getLibreriaComandos()); // Generamos una Construcción de Gramatica y cargamos la Librería de Comandos //

            grammarBuilder.Culture = recognizer.RecognizerInfo.Culture;

            var grammar = new Grammar(grammarBuilder);
            recognizer.LoadGrammar(grammar); // Cargamos la Gramatica en el Reconocedor de Voz

            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized); // Atamos el Evento de recognizer_SpeechRecognized a SpeechRecognized del Recognizer 

            recognizer.SetInputToDefaultAudioDevice(); // Ponemos el Dispositivo de Audio de Escucha como el de Default en la Computadora. No debería generar Excepciones si ocurre que no existe ninguno, ya que agarra el que este de Default //
            recognizer.RecognizeAsync(RecognizeMode.Multiple); // Configuramos el Recognizer para que pueda escuchar multiples audios y no uno solo y temrine su actividad //
        }

        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        { // Evento que se ejecuta cada vez que el Recognizer reconoce algun Speech dicho //
            if (microfonoAbierto == 0)
            { // Si el Microfono esta Cerrado no sucede nada //
                return;
            }

            // MessageBox.Show("Speech Recognized");

            string resultado = e.Result.Text;
            // Obtenemos el Texto que reconocío el SpeechRecognizer y lo comparamos con alguno de los Comandos que no pueden ser verificados normalmente y poseen un comportamiento especial //
            if (resultado == "Jarvis Read the Commands")
            {
                btnLeerComandos_Click(this, null);
                return;
            } 
            else if (resultado == "Jarvis Close the Application")
            {
                btnSalir_Click(this, null);
                return;
            }
            // Si no se utilizaron ninguno de los Comandos Especiales, comparamos con los Comandos que tengamos en el Diccionario y los Ejecutamos //
            for (int i = 0; i < diccionarioComandos.Count; i++)
            {
                var element = diccionarioComandos.ElementAt(i);
                string palabraClave = element.Key.palabraClave;
                if (charName + " " + palabraClave == resultado)
                {
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        synthesizer.SpeakAsync(element.Key.respuestaSynthesizer);
                    }).Start();

                    if (element.Key.ProgramaEjecutar != "N/A")
                    {
                        if (element.Key.Argumento != "N/A")
                        {
                            try
                            {
                                Process.Start(element.Key.ProgramaEjecutar, element.Key.Argumento);
                            }
                            catch (InvalidOperationException ex)
                            {
                                MessageBox.Show("Operación Invalida Ejecutando Proceso:" + ex.Message);
                                return;
                            }
                            catch (Win32Exception ex)
                            {
                                MessageBox.Show("Excepción de WIN32 al momento de ejecutar el Proceso: " + ex.Message);
                                return;
                            }
                            catch (FileNotFoundException ex)
                            {
                                MessageBox.Show("Archivo / Proceso a ejecutar no encontrado: " + ex.Message);
                                return;
                            }
                        }
                        else
                        {
                            try
                            {
                                Process.Start(element.Key.ProgramaEjecutar);
                            }
                            catch (InvalidOperationException ex)
                            {
                                MessageBox.Show("Operación Invalida Ejecutando Proceso:" + ex.Message);
                                return;
                            }
                            catch (Win32Exception ex)
                            {
                                MessageBox.Show("Excepción de WIN32 al momento de ejecutar el Proceso: " + ex.Message);
                                return;
                            }
                            catch (FileNotFoundException ex)
                            {
                                MessageBox.Show("Archivo / Proceso a ejecutar no encontrado: " + ex.Message);
                                return;
                            }
                        }
                    }
                    return;
                }
            }
            new Thread(() => // Manejamos todas las Instancias en las que utilizamos el Sintetizador en Hilos //
            {
                Thread.CurrentThread.IsBackground = true;
                synthesizer.SpeakAsync("I didn't quite get that");
            }).Start();
            MessageBox.Show("No te entendí!");
            return;
        }

        private void btnMicrofono_Click(object sender, RoutedEventArgs e)
        { // Si se presiona el Boton de Microfono, lo deshabilitamos o habilitamos según el estado en que se encuentre //
            if (microfonoAbierto == 0)
            {
                microfonoAbierto = 1;
                btnMicrofono.Background = Brushes.LightBlue;
            } 
            else
            {
                microfonoAbierto = 0;
                btnMicrofono.Background = Brushes.Red;
            }
        }

        private void getAllComandos()
        { // Conseguimos todos los Comandos almacenados en el Diccionario y los ponemos en el RichTextBox para hacerles Display //
            rtbComandos.Document.Blocks.Clear();
            rtbComandos.AppendText("Intenta decir Jarvis antes de decir los Comandos!");
            
            for(int i = 0; i < diccionarioComandos.Count(); i++)
            {
                var element = diccionarioComandos.ElementAt(i);
                string palabraClave = element.Key.palabraClave;
                rtbComandos.AppendText(Environment.NewLine + palabraClave);
            }
        }

        private void btnLeerComandos_Click(object sender, RoutedEventArgs e)
        { // Si presionamos este Boton, el Sintetizador nos lee todos los Comandos en el RichTextBox //
            new Thread(() =>
            {
                string richText = new TextRange(rtbComandos.Document.ContentStart, rtbComandos.Document.ContentEnd).Text;
                Thread.CurrentThread.IsBackground = true;
                synthesizer.SpeakAsync(richText);
            }).Start();
        }

        private void btnVerComandos_Click(object sender, RoutedEventArgs e)
        { // Para cambiar de pantalla o UI a la que nos permite ver los Comandos //
            if (microfonoAbierto == 1)
            {
                btnMicrofono_Click(this, null);
            }
            // Desactivamos el Microfono, y ocultamos todas las UI que no necesitamos. Además, desactivamos el Sintetizador si esta diciendo algo ya //
            synthesizer.SpeakAsyncCancelAll();
            getAllComandos();
            contenidoPrincipal.Visibility = Visibility.Collapsed;
            verComandosUI.Visibility = Visibility.Visible;
        }

        private void btnAgregarComandos_Click(object sender, RoutedEventArgs e)
        { // Para cambiar la pantalla a la UI de Agregar Comandos //
            if (microfonoAbierto == 1)
            {
                btnMicrofono_Click(this, null);
            }
            // Desactivamos el Microfono, y ocultamos todas las UI que no necesitamos. Además, desactivamos el Sintetizador si esta diciendo algo ya //
            synthesizer.SpeakAsyncCancelAll();
            contenidoPrincipal.Visibility = Visibility.Collapsed;
            agregarComandosUI.Visibility = Visibility.Visible;
        }

        private void btnEditarComandos_Click(object sender, RoutedEventArgs e)
        { // Para cambiar la pantalla a la UI de Editar Comandos //
            if (microfonoAbierto == 1)
            {
                btnMicrofono_Click(this, null);
            }
            // Desactivamos el Microfono, y ocultamos todas las UI que no necesitamos. Además, desactivamos el Sintetizador si esta diciendo algo ya //
            synthesizer.SpeakAsyncCancelAll();
            contenidoPrincipal.Visibility = Visibility.Collapsed;
            editarComandosUI.Visibility = Visibility.Visible;

        }

        private void btnVolverContenidoPrincipal_Click(object sender, RoutedEventArgs e)
        { // Para cambiar la pantalla a la UI de Editar Comandos //
            synthesizer.SpeakAsyncCancelAll();
            // Ocultamos todas las UI que no necesitamos, y apagamos el Sintetizador //
            verComandosUI.Visibility = Visibility.Collapsed;
            agregarComandosUI.Visibility = Visibility.Collapsed;
            editarComandosUI.Visibility = Visibility.Collapsed;
            contenidoPrincipal.Visibility= Visibility.Visible;
        }

        private void btnFileSearch_Click(object sender, RoutedEventArgs e)
        { // Para cuando buscamos un Archivo al cual atar a un Comando. Tiene que ser un .exe si o sí //
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".exe";
            dlg.Filter = "Executable Files | *.exe";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Abrir Archivo
                string filename = dlg.FileName;
                txtBoxFile.Text = filename;
            }
        }

        private bool verifyIfClaveEsUsada(string txtBoxClave)
        { // Verifica si una Palabra Clave ya esta siendo usada. Lo hace checkeando por la existencia de la misma en el Diccionario //
            for (int i = 0; i != diccionarioComandos.Count; i++)
            {
                var element = diccionarioComandos.ElementAt(i);
                string palabraClave = element.Key.palabraClave;
                if (txtBoxClave == palabraClave && element.Value == true || txtBoxClave == palabraClave && element.Value == false)
                {
                    return true;
                }
            }
            return false;
        }

        private bool verifyIfClaveEsPreHecha(string txtBoxClave)
        { // Verifica si una Palabra Clave es una de las Pre-Existentes que agrega el Programa //
            for (int i = 0; i != diccionarioComandos.Count; i++)
            {
                var element = diccionarioComandos.ElementAt(i);
                string palabraClave = element.Key.palabraClave;
                if (txtBoxClave == palabraClave && element.Value == false)
                {
                    return true;
                }
            }
            return false;
        }

        private void deleteClaveUsada(string txtBoxClave) 
        { // Para borrar una Clave que ya este siendo usada del Diccionario de Comandos //
            for (int i = 0; i != diccionarioComandos.Count; i++)
            {
                var element = diccionarioComandos.ElementAt(i);

                string palabraClave = element.Key.palabraClave;
                if (txtBoxClave == palabraClave)
                {
                    diccionarioComandos.Remove((element.Key.palabraClave, element.Key.respuestaSynthesizer, element.Key.ProgramaEjecutar, element.Key.Argumento));
                    return;
                }
            }
        }

        private void btnAgregarComando_Click(object sender, RoutedEventArgs e)
        { // Boton que si presionamos agrega un Comando //
            if (txtBoxClave.Text.Contains(",") || txtBoxRespuesta.Text.Contains(","))
            {
                MessageBox.Show("La Palabra Clave y/o la Respuesta no pueden contener comas (,)");
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    synthesizer.SpeakAsync("La Palabra Clave y la Respuesta no pueden contener Comas");
                }).Start();
                return;
            }
            // Verificamos que los datos ingresados sean correctos //
            if (txtBoxFile.Text == "")
            {
                txtBoxFile.Text = "N/A";
            }
           
            if (txtBoxClave != null && txtBoxRespuesta != null && txtBoxFile != null)
            {
                try
                {
                    bool verification = verifyIfClaveEsUsada(txtBoxClave.Text); // Vemos si la Palabra Clave dada ya esta siendo utilizada //

                    if (verification == true)
                    { // Si ya existe o esta siendo utilizada la palabra clave, terminamos allí //
                        MessageBox.Show("Ya existe una Entrada en los Comandos similar o igual a esta");

                        new Thread(() =>
                        {
                            Thread.CurrentThread.IsBackground = true;
                            synthesizer.SpeakAsync("Ya existe un Comando así!");
                        }).Start();
                        return;
                    }

                    diccionarioComandos.Add((txtBoxClave.Text, txtBoxRespuesta.Text, txtBoxFile.Text, "N/A"), true);
                } // Además, verificamos por Excepciones para en el caso de que si se agrega accidentalmente el Programa lo detecte //
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Ya existe una Entrada en los Comandos similar o igual a esta: " + ex.Message);
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        synthesizer.SpeakAsync("Ya existe un Comando así!");
                    }).Start();
                    return;
                }
                // Una vez el Comando nuevo este agregado, lo guardamos en el Archivo, y regeneramos al SpeechRecognitionEngine, y recargamos los Comandos //
                fileManager = new FileManager(diccionarioComandos);
                fileManager.pushToFile(txtBoxClave.Text, txtBoxRespuesta.Text, txtBoxFile.Text, "N/A");
                loadSpeechRecognition();
                getAllComandos();

                txtBoxClave.Text = "";
                txtBoxRespuesta.Text = "";
                txtBoxFile.Text = "";

                return;
            }
            else
            { // Seguimos manejando al Sintetizador en Hilos //
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    synthesizer.SpeakAsync("Algo ha ido mal! Verifica que has ingresado todos los Datos");
                }).Start();
            }
        }

        private void btnEditarComando_Click(object sender, RoutedEventArgs e)
        { // Botón para Editar Comandos //
            if (txtBoxClaveEditar.Text.Contains(",") || txtBoxRespuestaEditar.Text.Contains(","))
            { // Verificamos que las Palabras Ingresadas no contengan , //
                MessageBox.Show("La Palabra Clave y/o la Respuesta no pueden contener comas (,)");
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    synthesizer.SpeakAsync("La Palabra Clave y la Respuesta no pueden contener Comas");
                }).Start();
                return;
            }

            if (txtBoxFileEditar.Text == "")
            {
                txtBoxFileEditar.Text = "N/A";
            }
            // Una vez este todo verificado, verificamos que ninguno de los txtBox esten Vacíos //
            if (txtBoxClaveEditar.Text != "" && txtBoxRespuestaEditar.Text != "" && txtBoxFileEditar.Text != "")
            {
                bool verification = verifyIfClaveEsUsada(txtBoxClaveEditar.Text);
                bool verification_if_premade = verifyIfClaveEsPreHecha(txtBoxClaveEditar.Text);

                if (verification == true && verification_if_premade == false)
                { // Vemos si la Palabra Clave esta siendo utilizada, y si es una Pre-Hecha. Si es Pre-Hecha no la editamos //
                    deleteClaveUsada(txtBoxClaveEditar.Text);
                    diccionarioComandos.Add((txtBoxClaveEditar.Text, txtBoxRespuestaEditar.Text, txtBoxFileEditar.Text, "N/A"), true);
                    fileManager = new FileManager(diccionarioComandos);
                    fileManager.pushDictionaryFromScratch();
                    // Borramos la Clave y la regeneramos para editarla //
                    loadSpeechRecognition();
                    getAllComandos();

                    txtBoxClaveEditar.Text = "";
                    txtBoxRespuestaEditar.Text = "";
                    txtBoxFileEditar.Text = "";
                } 
                else
                {
                    MessageBox.Show("No existe el Comando con la Palabra Clave Ingresada! No lo podemos editar : (");
                    // Si no existe la Clave directamente retornamos //
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        synthesizer.SpeakAsync("No existe el Comando con la Palabra Clave Ingresada!");
                    }).Start();
                    return;
                }
            }
        }

        private void btnBorrarComando_Click(object sender, RoutedEventArgs e)
        { // Botón para borrar el Comando //
            if (txtBoxFileEditar.Text == "")
            {
                txtBoxFileEditar.Text = "N/A";
            }
            // Verificamos que ninguno de los txtBox esten vaciós //
            if (txtBoxClaveEditar.Text != "" && txtBoxRespuestaEditar.Text != "" && txtBoxFileEditar.Text != "")
            {
                bool verification = verifyIfClaveEsUsada(txtBoxClaveEditar.Text);
                bool verification_if_premade = verifyIfClaveEsPreHecha(txtBoxClaveEditar.Text);
                // Vemos si la Clave esta siendo utilizada y si es Pre-Hecha. Si es Pre-Hecha no la borramos //
                if (verification == true && verification_if_premade == false)
                {
                    deleteClaveUsada(txtBoxClaveEditar.Text);
                    fileManager.pushDictionaryFromScratch();
                    // Borramos la Palabra Clave del Diccionario y recreamos el Diccionario desde cero //
                    loadSpeechRecognition();
                    getAllComandos();

                    txtBoxClaveEditar.Text = "";
                    txtBoxRespuestaEditar.Text = "";
                    txtBoxFileEditar.Text = "";
                }
                else
                {
                    MessageBox.Show("No existe el Comando con la Palabra Clave Ingresada! No lo podemos borrar : (");
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        synthesizer.SpeakAsync("No Existe el Comando con la Palabra Clave Ingresada");
                    }).Start();
                    return;
                }
            }
        }
    }
}
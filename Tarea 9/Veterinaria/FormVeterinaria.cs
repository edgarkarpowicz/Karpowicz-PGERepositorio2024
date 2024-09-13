// FormVeterinaria.cs
using Logger;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Veterinaria;

namespace Veterinaria
{
    public partial class FormVeterinaria : Form
    {
        private ListBox lstAnimales;

        private Label lblVeterinario;
        private Label lblEstadoAnimal;
        private Button btnEnfermo;
        private Button btnSaludable;
        private Label lblVidas;
        private Label lblPuntaje;
        private Label lblPuntajeRecord;

        //static private int vidas = 3;
        private int vidas = 3 + vidaAux;
        static private int vidaAux = 0;
        private int puntaje = 0;

        static private int puntajeRecord = 0;
        private int puntajeRecordAux = 0;

        static private int monedas = 0;
        private int diagnosticosCorrectos = 0;
        private Animal animalActual;
        private Random random = new Random();
        private string veterinarioNombre;
        private FormMainMenu menuPrincipal;

        private List<Animal> animalesPool;  // Lista de animales que pueden aparecer

        public FormVeterinaria(string veterinarioNombre, FormMainMenu menu)
        {
            Logging.Instance.Log("Juego Principal iniciado!");
            this.veterinarioNombre = veterinarioNombre;
            this.menuPrincipal = menu;
            InitializeComponent();

            animalesPool = new List<Animal>
            {
                new Perro(),  // Animales por defecto
                new Gato()
            };

            CargarAnimalesDesbloqueados(menu.AnimalesComprados); // Cargamos los animales que el jugador compró
            GenerarNuevoAnimal();
        }

        private void InitializeComponent()
        {
            this.lblVeterinario = new Label();
            this.lblEstadoAnimal = new Label();
            this.lstAnimales = new ListBox();
            this.btnEnfermo = new Button();
            this.btnSaludable = new Button();
            this.lblVidas = new Label();
            this.lblPuntaje = new Label();
            this.lblPuntajeRecord = new Label();
            this.SuspendLayout();

            // lblVeterinario
            this.lblVeterinario.AutoSize = true;
            this.lblVeterinario.Location = new System.Drawing.Point(30, 20);
            this.lblVeterinario.Size = new System.Drawing.Size(200, 20);
            this.lblVeterinario.Text = $"Veterinario: {veterinarioNombre}";

            // lblEstadoAnimal
            this.lblEstadoAnimal.AutoSize = true;
            this.lblEstadoAnimal.Location = new System.Drawing.Point(30, 60);
            this.lblEstadoAnimal.Size = new System.Drawing.Size(300, 20);

            // lstAnimales
            this.lstAnimales.Location = new System.Drawing.Point(30, 100);
            this.lstAnimales.Size = new System.Drawing.Size(240, 100);

            // btnEnfermo
            this.btnEnfermo.Location = new System.Drawing.Point(30, 220);
            this.btnEnfermo.Size = new System.Drawing.Size(100, 30);
            this.btnEnfermo.Text = "Enfermo";
            this.btnEnfermo.Click += new EventHandler(this.btnEnfermo_Click);

            // btnSaludable
            this.btnSaludable.Location = new System.Drawing.Point(140, 220);
            this.btnSaludable.Size = new System.Drawing.Size(100, 30);
            this.btnSaludable.Text = "Saludable";
            this.btnSaludable.Click += new EventHandler(this.btnSaludable_Click);

            // lblVidas
            this.lblVidas.AutoSize = true;
            this.lblVidas.Location = new System.Drawing.Point(30, 270);
            this.lblVidas.Size = new System.Drawing.Size(100, 20);
            this.lblVidas.Text = $"Vidas: {vidas}";

            // lblPuntaje
            this.lblPuntaje.AutoSize = true;
            this.lblPuntaje.Location = new System.Drawing.Point(30, 300);
            this.lblPuntaje.Size = new System.Drawing.Size(100, 20);
            this.lblPuntaje.Text = $"Puntaje: {puntaje}";

            // lblPuntajeRecord
            this.lblPuntajeRecord.AutoSize = true;
            this.lblPuntajeRecord.Location = new System.Drawing.Point(30, 320);
            this.lblPuntajeRecord.Size = new System.Drawing.Size(100, 20);
            this.lblPuntajeRecord.Text = $"Puntaje más alto: {puntaje}";

            // FormVeterinaria
            this.ClientSize = new System.Drawing.Size(300, 350);
            this.Controls.Add(this.lblVeterinario);
            this.Controls.Add(this.lblEstadoAnimal);
            this.Controls.Add(this.lstAnimales);
            this.Controls.Add(this.btnEnfermo);
            this.Controls.Add(this.btnSaludable);
            this.Controls.Add(this.lblVidas);
            this.Controls.Add(this.lblPuntaje);
            this.Controls.Add(this.lblPuntajeRecord);
            this.Text = "Veterinaria Abierta";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            lblPuntajeRecord.Text = $"Puntaje más alto: {puntajeRecord}";
            this.ResumeLayout(false);
        }

        private void CargarAnimalesDesbloqueados(List<AnimalTienda> animalesComprados)
        {
            Logging.Instance.Log("Se esta intentando cargar los Animales ya comprados");
            foreach (var animal in animalesComprados)
            {
                if (animal.Desbloqueado)
                {
                    Logging.Instance.Log("Hay un Animal Desbloqueado y se esta agregando");
                    animal.AgregarALaPool(animalesPool);
                }
            }
        }

        private void GenerarNuevoAnimal()
        {
            //animalActual = random.Next(2) == 0 ? (Animal)new Perro() : new Gato();
            Logging.Instance.Log("Generando un Nuevo Animal...");
            animalActual = animalesPool[random.Next(animalesPool.Count)];
            lstAnimales.Items.Clear();
            lstAnimales.Items.Add($"{animalActual.GetType().Name}: {animalActual.Nombre}");
            lstAnimales.Items.Add($"Come: {animalActual.EstadoComer()}");
            lstAnimales.Items.Add($"Duerme: {animalActual.EstadoDormir()}");

            // Mostrar el diálogo y reproducir sonido
            lblEstadoAnimal.Text = $"{animalActual.Nombre} {animalActual.Actividad()}";
        }

        private void btnEnfermo_Click(object sender, EventArgs e)
        {
            bool estaEnfermo = !animalActual.ComeBien || !animalActual.DuermeBien;
            Logging.Instance.Log("Bóton de que esta Enfermo presionado");
            if (estaEnfermo)
            {
                DiagnosticoCorrecto();
            }
            else
            {
                DiagnosticoIncorrecto();
            }
        }

        private void btnSaludable_Click(object sender, EventArgs e)
        {
            bool estaSaludable = animalActual.ComeBien && animalActual.DuermeBien;
            Logging.Instance.Log("Bóton de que esta Saludable presionado");
            if (estaSaludable)
            {
                DiagnosticoCorrecto();
            }
            else
            {
                DiagnosticoIncorrecto();
            }
        }

        private void DiagnosticoCorrecto()
        {
            Logging.Instance.Log("Diagnostico Correcto");
            puntaje += 100;
            puntajeRecordAux += 100;

            diagnosticosCorrectos++;
            if (puntajeRecord < puntajeRecordAux)
            {
                puntajeRecord = puntajeRecordAux;
            }

            if (diagnosticosCorrectos % 2 == 0)
            {
                monedas += 10;
            }
            lblPuntaje.Text = $"Puntaje: {puntaje}";
            lblPuntajeRecord.Text = $"Puntaje más alto: {puntajeRecord}";
            GenerarNuevoAnimal();
        }

        private void DiagnosticoIncorrecto()
        {
            Logging.Instance.Log("Diagnostico Incorrecto");
            vidas--;
            lblVidas.Text = $"Vidas: {vidas}";
            if (vidas == 0)
            {
                Logging.Instance.Log("Se perdieron todas las Vidas, de vuelta al Menu");
                MessageBox.Show("Has perdido todas tus vidas. Volviendo al menú principal.");
                this.Close();
                menuPrincipal.ActualizarPuntaje(monedas);
                menuPrincipal.VolverAMenu();
            }
            else
            {
                GenerarNuevoAnimal();
            }
        }

        // Método para aumentar una vida al usuario cuando usa un objeto
        public void AumentarVida(int canVidas)
        {
            Logging.Instance.Log("Aumentando Vidas debido a un Objeto");
            vidaAux += canVidas;
            lblVidas.Text = $"Vidas: {vidas}";
            MessageBox.Show("Has ganado vidas adicional!");
        }
    }
}

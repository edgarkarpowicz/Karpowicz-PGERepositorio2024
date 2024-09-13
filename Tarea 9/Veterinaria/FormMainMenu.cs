// FormMainMenu.cs
using Logger;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Veterinaria
{
    public partial class FormMainMenu : Form
    {
        private FormVeterinaria partida;  // Guardamos la referencia a la partida actual

        private Label lblBienvenida;
        private Button btnJugar;
        private Button btnTienda;
        private Button btnSalir;
        private string VeterinarioNombre;

        private PictureBox picLogo; // Logo de la veterinaria

        private int puntajeMaximo = 0;

        private List<AnimalTienda> animalesComprados = new List<AnimalTienda>();
        private List<Objeto> objetosComprados = new List<Objeto>();
        public List<AnimalTienda> AnimalesComprados => animalesComprados;

        private int monedas = 0;

        public FormMainMenu(string nombreVeterinario)
        {
            Logging.Instance.Log("Menu Principal del Juego abierto");
            Logging.Instance.Log($"Nombre del Veterinario: {nombreVeterinario}");
            InitializeComponent();
            VeterinarioNombre = nombreVeterinario;
            lblBienvenida.Text = $"¡Bienvenido Dr(a). {VeterinarioNombre}!";
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnJugar = new System.Windows.Forms.Button();
            this.btnTienda = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblBienvenida.Location = new System.Drawing.Point(50, 180);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(0, 16);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnJugar
            // 
            this.btnJugar.BackColor = System.Drawing.Color.LightGreen;
            this.btnJugar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnJugar.Location = new System.Drawing.Point(12, 204);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(276, 40);
            this.btnJugar.TabIndex = 2;
            this.btnJugar.Text = "Jugar";
            this.btnJugar.UseVisualStyleBackColor = false;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // btnTienda
            // 
            this.btnTienda.BackColor = System.Drawing.Color.LightGreen;
            this.btnTienda.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnTienda.Location = new System.Drawing.Point(12, 250);
            this.btnTienda.Name = "btnTienda";
            this.btnTienda.Size = new System.Drawing.Size(276, 40);
            this.btnTienda.TabIndex = 3;
            this.btnTienda.Text = "Tienda";
            this.btnTienda.UseVisualStyleBackColor = false;
            this.btnTienda.Click += new System.EventHandler(this.btnTienda_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.LightGreen;
            this.btnSalir.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnSalir.Location = new System.Drawing.Point(12, 328);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(276, 60);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(276, 186);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // FormMainMenu
            // 
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.btnTienda);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Boton de jugar clickeado");
            this.Hide();
            //FormVeterinaria formVeterinaria = new FormVeterinaria(VeterinarioNombre, this);
            partida = new FormVeterinaria(VeterinarioNombre, this);  // Crear nueva instancia de la partida
            //formVeterinaria.Show();
            partida.Show();
        }

        private void btnTienda_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Intentando entrar a la tienda...");
            if (partida == null)
            {
                Logging.Instance.Log("No se ha jugado a una partida aún, no se puede entrar a la tienda...");
                MessageBox.Show("No hay una partida en curso.");
            }
            else
            {
                Logging.Instance.Log("Entrando a la tienda...");
                this.Hide();
                FormTienda tienda = new FormTienda(monedas, this, partida);  // Pasamos la instancia de partida
                tienda.Show();
            }
            //this.Hide();
            //FormTienda tienda = new FormTienda(monedas, this);
            //tienda.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Bóton de salir clickeado. Saliendo...");
            Application.Exit();
        }

        public void ActualizarPuntaje(int nuevasMonedas)
        {
            Logging.Instance.Log("Monedas Actualizadas");
            Logging.Instance.Log($"Antes: {this.monedas}");
            Logging.Instance.Log($"Después: {nuevasMonedas}");
            this.monedas = nuevasMonedas;
        }

        public void VolverAMenu()
        {
            Logging.Instance.Log("Mostrando Menu...");
            this.Show();
        }

        // Al comprar un animal, lo añadimos a la lista de animales comprados
        public void AgregarAnimal(AnimalTienda animal)
        {
            if (!animalesComprados.Contains(animal))
            {
                Logging.Instance.Log("Agregando a un Animal comprado");
                animalesComprados.Add(animal);
            }
        }

        // Método para manejar la compra desde la tienda
        public void ActualizarCompra(Producto producto)
        {
            Logging.Instance.Log("Se compro algo en la Tienda");
            if (producto is AnimalTienda animal)
            {
                Logging.Instance.Log("Se esta intentando agregar a un Animal a la Lista");
                AgregarAnimal(animal);
            }
            else if (producto is Objeto objeto)
            {
                Logging.Instance.Log("Se esta intentando agregar a un Objeto a la Lista");
                objetosComprados.Add(objeto);
            }
        }
    }
}

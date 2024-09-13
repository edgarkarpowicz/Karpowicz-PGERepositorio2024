// FormLogin.cs
using System;
using System.Drawing;
using System.Windows.Forms;

using Logger;

namespace Veterinaria
{
    public partial class FormLogin : Form
    {
        private Label lblNombre;
        private TextBox txtNombre;
        private Button btnIniciar;
        
        public string VeterinarioNombre { get; private set; }

        public FormLogin()
        {
            Logging.Instance.Log("Juego de Veterinario Iniciado");
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(27, 44);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(117, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre del Veterinario:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(30, 60);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnIniciar.ForeColor = System.Drawing.Color.White;
            this.btnIniciar.Location = new System.Drawing.Point(77, 96);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(100, 30);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // FormLogin
            // 
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(259, 161);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnIniciar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Seleccionando el Nombre del Veterinario...");
            VeterinarioNombre = txtNombre.Text;

            try
            {
                if (!string.IsNullOrEmpty(VeterinarioNombre))
                {
                    Logging.Instance.Log($"Nombre del Veterinario seleccionado: {VeterinarioNombre}");
                    this.Hide();
                    FormMainMenu mainMenu = new FormMainMenu(VeterinarioNombre);
                    mainMenu.Show();
                }
                else
                {
                    Logging.Instance.Log("Nombre del Veterinario estaba vacío. Mostrando Advertencia");
                    MessageBox.Show("Por favor, ingrese su nombre.");
                }
            }
            catch (ArgumentNullException ex)
            {
                Logging.Instance.Log($"Excepción de Argumento Nulo seleccionando el Nombre: {ex.Message}");
                VeterinarioNombre = "default_name";
                this.Hide();
                FormMainMenu mainMenu = new FormMainMenu(VeterinarioNombre);
                mainMenu.Show();
            }
            catch (FormatException ex)
            {
                Logging.Instance.Log($"Excepción de Formato seleccionando el Nombre: {ex.Message}");
                VeterinarioNombre = "default_name";
                this.Hide();
                FormMainMenu mainMenu = new FormMainMenu(VeterinarioNombre);
                mainMenu.Show();
            }
            catch (Exception ex)
            {
                Logging.Instance.Log($"Excepción Génerica seleccionando el Nombre: {ex.Message}");
                VeterinarioNombre = "default_name";
                this.Hide();
                FormMainMenu mainMenu = new FormMainMenu(VeterinarioNombre);
                mainMenu.Show();
            }
        }
    }
}

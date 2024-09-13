// FormTienda.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Veterinaria;

using Logger;

namespace Veterinaria
{
    public partial class FormTienda : Form
    {
        private FormVeterinaria partida; // Referencia a la partida en curso

        static private int monedasDisponibles;
        static private bool yaSeHizo = true;

        private Label lblMonedas;
        private Button btnCerrar;
        static private List<Producto> productos; // Lista de objetos y animales
        private FlowLayoutPanel panelProductos; // Panel para mostrar los productos de forma visual
        private FormMainMenu menuPrincipal;

        public FormTienda(int monedas, FormMainMenu menu, FormVeterinaria partida)
        {
            Logging.Instance.Log("Tienda Abierta");
            monedasDisponibles = monedas;
            this.partida = partida;
            this.menuPrincipal = menu;
            InitializeComponent();

            Logging.Instance.Log($"Hay: ${monedasDisponibles}");

            if (yaSeHizo)
            {
                Logging.Instance.Log("Revisando si ya se compro algo");
                CargarProductos();
            }
            Logging.Instance.Log("Mostrando Productos");
            MostrarProductos();
 
        }

        private void InitializeComponent()
        {
            this.lblMonedas = new Label();
            this.btnCerrar = new Button();
            this.panelProductos = new FlowLayoutPanel();
            this.SuspendLayout();

            // lblMonedas
            this.lblMonedas.AutoSize = true;
            this.lblMonedas.Location = new Point(20, 20);
            this.lblMonedas.Size = new Size(200, 20);
            this.lblMonedas.Text = $"Monedas: {monedasDisponibles}";

            // btnCerrar
            this.btnCerrar.Location = new Point(20, 300);
            this.btnCerrar.Size = new Size(100, 30);
            this.btnCerrar.Text = "Cerrar Tienda";
            this.btnCerrar.Click += new EventHandler(this.btnCerrar_Click);

            // panelProductos
            this.panelProductos.Location = new Point(20, 60);
            this.panelProductos.Size = new Size(400, 220);
            this.panelProductos.FlowDirection = FlowDirection.LeftToRight;
            this.panelProductos.WrapContents = true;
            this.panelProductos.AutoScroll = true;

            // FormTienda
            this.ClientSize = new Size(450, 350);
            this.Controls.Add(this.lblMonedas);
            this.Controls.Add(this.panelProductos);
            this.Controls.Add(this.btnCerrar);
            this.Text = "Tienda Retro";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private void CargarProductos()
        {
            // Crear algunos objetos y animales con imágenes simples (sprites)
            Logging.Instance.Log("Cargando los Productos...");
            productos = new List<Producto>
            {
                new Objeto("Comida Premium", 150, Image.FromFile("Sprites\\comida_premium.png"),"vida"),
                new Objeto("Juguete", 300, Image.FromFile("Sprites\\juguete.png"),"vida"),
                new AnimalTienda("Gato Persa", 100, Image.FromFile("Sprites\\Gato.png")),
                new AnimalTienda("Perro Labrador", 120, Image.FromFile("Sprites\\perro.png")),
                new AnimalTienda("Pajaro", 70, Image.FromFile("Sprites\\pajaro.png"))
            };
        }

        private void MostrarProductos()
        {
            Logging.Instance.Log("Mostrando los Productos...");
            foreach (var producto in productos)
            {
                // Crear controles visuales para cada producto
                Panel panel = new Panel
                {
                    Size = new Size(150, 150),
                    BorderStyle = BorderStyle.FixedSingle
                };

                PictureBox pictureBox = new PictureBox
                {
                    Image = producto.Sprite,
                    Size = new Size(64, 64),
                    Location = new Point(40, 10),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                Label lblNombre = new Label
                {
                    Text = producto.Nombre,
                    Location = new Point(10, 80),
                    Size = new Size(130, 20),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Label lblPrecio = new Label
                {
                    Text = $"Precio: {producto.Precio} monedas",
                    Location = new Point(10, 100),
                    Size = new Size(130, 20),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Button btnComprar = new Button
                {
                    Text = "Comprar",
                    Location = new Point(30, 120),
                    Size = new Size(80, 30),
                    Tag = producto // Guardar el producto en el botón para referencia
                };
                btnComprar.Click += new EventHandler(this.btnComprar_Click);

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(lblNombre);
                panel.Controls.Add(lblPrecio);
                panel.Controls.Add(btnComprar);

                panelProductos.Controls.Add(panel);
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Producto producto = (Producto)btn.Tag;

            Logging.Instance.Log("Bóton de Comprar algo presionado");

            if (monedasDisponibles >= producto.Precio)
            {
                Logging.Instance.Log("Se pudo comprar el Producto");
                monedasDisponibles -= producto.Precio;
                lblMonedas.Text = $"Monedas: {monedasDisponibles}";
                string resultadoCompra = producto.Comprar();
                MessageBox.Show(resultadoCompra);

                // Si es un objeto y tiene un efecto en la partida, lo aplicamos
                if (producto is Objeto objeto)
                {
                    Logging.Instance.Log("Es un Objeto");
                    objeto.Usar(partida);  // Asumiendo que "partida" es la instancia de FormVeterinaria
                }

                if (producto is AnimalTienda animal)
                {
                    Logging.Instance.Log("Es un Animal");
                    if (animal.auxDesloqueado)
                    {
                        monedasDisponibles += producto.Precio;
                        lblMonedas.Text = $"Monedas: {monedasDisponibles}";
                    }
                    menuPrincipal.AgregarAnimal(animal);  // Añadimos el animal a la pool de posibilidades
                }
            }
            else
            {
                Logging.Instance.Log("No hay suficiente dinero");
                MessageBox.Show("No tienes suficientes monedas para comprar este producto.");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Bóton de Cerrar Tienda presionado. Volviendo al Menu...");
            this.Hide();
            yaSeHizo = false;
            menuPrincipal.ActualizarPuntaje(monedasDisponibles);
            menuPrincipal.VolverAMenu();
        }
    }
}

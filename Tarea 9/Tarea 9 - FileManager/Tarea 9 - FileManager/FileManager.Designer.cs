namespace Tarea_9___FileManager
{
    partial class FileManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tboxArchivo = new TextBox();
            ArchivoSeleccionado = new OpenFileDialog();
            BuscarArchivo = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnLeer = new Button();
            btnEscribir = new Button();
            btnBorrar = new Button();
            btnSalir = new Button();
            rtbLectura = new RichTextBox();
            rtbEscritura = new RichTextBox();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tboxArchivo
            // 
            tboxArchivo.Font = new Font("Verdana", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tboxArchivo.Location = new Point(12, 13);
            tboxArchivo.Name = "tboxArchivo";
            tboxArchivo.ReadOnly = true;
            tboxArchivo.Size = new Size(356, 23);
            tboxArchivo.TabIndex = 0;
            // 
            // ArchivoSeleccionado
            // 
            ArchivoSeleccionado.FileName = "Archivo";
            // 
            // BuscarArchivo
            // 
            BuscarArchivo.Font = new Font("Verdana", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BuscarArchivo.Location = new Point(374, 10);
            BuscarArchivo.Name = "BuscarArchivo";
            BuscarArchivo.Size = new Size(88, 29);
            BuscarArchivo.TabIndex = 1;
            BuscarArchivo.Text = "📁";
            BuscarArchivo.UseVisualStyleBackColor = true;
            BuscarArchivo.Click += BuscarArchivo_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnLeer);
            flowLayoutPanel1.Controls.Add(btnEscribir);
            flowLayoutPanel1.Controls.Add(btnBorrar);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(12, 45);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(450, 41);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // btnLeer
            // 
            btnLeer.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnLeer.Location = new Point(3, 3);
            btnLeer.Name = "btnLeer";
            btnLeer.Size = new Size(106, 30);
            btnLeer.TabIndex = 0;
            btnLeer.Text = "Leer";
            btnLeer.UseVisualStyleBackColor = true;
            btnLeer.Click += btnLeer_Click;
            // 
            // btnEscribir
            // 
            btnEscribir.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnEscribir.Location = new Point(115, 3);
            btnEscribir.Name = "btnEscribir";
            btnEscribir.Size = new Size(106, 30);
            btnEscribir.TabIndex = 1;
            btnEscribir.Text = "Escribir";
            btnEscribir.UseVisualStyleBackColor = true;
            btnEscribir.Click += btnEscribir_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnBorrar.Location = new Point(227, 3);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(106, 30);
            btnBorrar.TabIndex = 2;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnSalir.Location = new Point(339, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(106, 30);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // rtbLectura
            // 
            rtbLectura.Font = new Font("Verdana", 7.8F);
            rtbLectura.Location = new Point(12, 92);
            rtbLectura.Name = "rtbLectura";
            rtbLectura.ReadOnly = true;
            rtbLectura.Size = new Size(450, 150);
            rtbLectura.TabIndex = 3;
            rtbLectura.Text = "Aquí se Imprime el Texto";
            // 
            // rtbEscritura
            // 
            rtbEscritura.Font = new Font("Verdana", 7.8F);
            rtbEscritura.Location = new Point(12, 248);
            rtbEscritura.Name = "rtbEscritura";
            rtbEscritura.Size = new Size(450, 150);
            rtbEscritura.TabIndex = 4;
            rtbEscritura.Text = "Escriba aquí lo que quiere agregar al Archivo";
            // 
            // FileManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 405);
            Controls.Add(rtbEscritura);
            Controls.Add(rtbLectura);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(BuscarArchivo);
            Controls.Add(tboxArchivo);
            MaximumSize = new Size(492, 452);
            MinimumSize = new Size(492, 452);
            Name = "FileManager";
            Text = "FileManager";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tboxArchivo;
        private OpenFileDialog ArchivoSeleccionado;
        private Button BuscarArchivo;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnLeer;
        private Button btnEscribir;
        private Button btnBorrar;
        private Button btnSalir;
        private RichTextBox rtbLectura;
        private RichTextBox rtbEscritura;
    }
}

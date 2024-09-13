namespace Tarea_9___Calculadora
{
    partial class Calculadora
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
            tableLayoutPanel1 = new TableLayoutPanel();
            btnSiete = new Button();
            btnOcho = new Button();
            btnNueve = new Button();
            btnDividir = new Button();
            btnMultiplicar = new Button();
            btnSeis = new Button();
            btnCinco = new Button();
            btnCuatro = new Button();
            btnUno = new Button();
            btnDos = new Button();
            btnTres = new Button();
            btnSumar = new Button();
            btnCero = new Button();
            btnCLR = new Button();
            btnIgual = new Button();
            btnRestar = new Button();
            txtBoxPrincipal = new TextBox();
            txtBoxSaved = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(btnSiete, 0, 0);
            tableLayoutPanel1.Controls.Add(btnOcho, 1, 0);
            tableLayoutPanel1.Controls.Add(btnNueve, 2, 0);
            tableLayoutPanel1.Controls.Add(btnDividir, 3, 0);
            tableLayoutPanel1.Controls.Add(btnMultiplicar, 3, 1);
            tableLayoutPanel1.Controls.Add(btnSeis, 2, 1);
            tableLayoutPanel1.Controls.Add(btnCinco, 1, 1);
            tableLayoutPanel1.Controls.Add(btnCuatro, 0, 1);
            tableLayoutPanel1.Controls.Add(btnUno, 0, 2);
            tableLayoutPanel1.Controls.Add(btnDos, 1, 2);
            tableLayoutPanel1.Controls.Add(btnTres, 2, 2);
            tableLayoutPanel1.Controls.Add(btnSumar, 3, 2);
            tableLayoutPanel1.Controls.Add(btnCero, 0, 3);
            tableLayoutPanel1.Controls.Add(btnCLR, 1, 3);
            tableLayoutPanel1.Controls.Add(btnIgual, 2, 3);
            tableLayoutPanel1.Controls.Add(btnRestar, 3, 3);
            tableLayoutPanel1.Location = new Point(12, 72);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(258, 289);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSiete
            // 
            btnSiete.Anchor = AnchorStyles.None;
            btnSiete.BackColor = Color.White;
            btnSiete.FlatAppearance.BorderColor = Color.Black;
            btnSiete.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnSiete.Location = new Point(7, 4);
            btnSiete.Name = "btnSiete";
            btnSiete.Size = new Size(50, 64);
            btnSiete.TabIndex = 0;
            btnSiete.Text = "7";
            btnSiete.UseVisualStyleBackColor = false;
            btnSiete.Click += btnSiete_Click;
            // 
            // btnOcho
            // 
            btnOcho.Anchor = AnchorStyles.None;
            btnOcho.BackColor = Color.White;
            btnOcho.FlatAppearance.BorderColor = Color.Black;
            btnOcho.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnOcho.Location = new Point(71, 4);
            btnOcho.Name = "btnOcho";
            btnOcho.Size = new Size(50, 64);
            btnOcho.TabIndex = 1;
            btnOcho.Text = "8";
            btnOcho.UseVisualStyleBackColor = false;
            btnOcho.Click += btnOcho_Click;
            // 
            // btnNueve
            // 
            btnNueve.Anchor = AnchorStyles.None;
            btnNueve.BackColor = Color.White;
            btnNueve.FlatAppearance.BorderColor = Color.Black;
            btnNueve.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnNueve.Location = new Point(135, 4);
            btnNueve.Name = "btnNueve";
            btnNueve.Size = new Size(50, 64);
            btnNueve.TabIndex = 2;
            btnNueve.Text = "9";
            btnNueve.UseVisualStyleBackColor = false;
            btnNueve.Click += btnNueve_Click;
            // 
            // btnDividir
            // 
            btnDividir.Anchor = AnchorStyles.None;
            btnDividir.BackColor = Color.Gray;
            btnDividir.FlatAppearance.BorderColor = Color.Black;
            btnDividir.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnDividir.Location = new Point(200, 4);
            btnDividir.Name = "btnDividir";
            btnDividir.Size = new Size(50, 64);
            btnDividir.TabIndex = 3;
            btnDividir.Text = "/";
            btnDividir.UseVisualStyleBackColor = false;
            btnDividir.Click += btnDividir_Click;
            // 
            // btnMultiplicar
            // 
            btnMultiplicar.Anchor = AnchorStyles.None;
            btnMultiplicar.BackColor = Color.Gray;
            btnMultiplicar.FlatAppearance.BorderColor = Color.Black;
            btnMultiplicar.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnMultiplicar.Location = new Point(200, 76);
            btnMultiplicar.Name = "btnMultiplicar";
            btnMultiplicar.Size = new Size(50, 64);
            btnMultiplicar.TabIndex = 4;
            btnMultiplicar.Text = "X";
            btnMultiplicar.UseVisualStyleBackColor = false;
            btnMultiplicar.Click += btnMultiplicar_Click;
            // 
            // btnSeis
            // 
            btnSeis.Anchor = AnchorStyles.None;
            btnSeis.BackColor = Color.White;
            btnSeis.FlatAppearance.BorderColor = Color.Black;
            btnSeis.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnSeis.Location = new Point(135, 76);
            btnSeis.Name = "btnSeis";
            btnSeis.Size = new Size(50, 64);
            btnSeis.TabIndex = 5;
            btnSeis.Text = "6";
            btnSeis.UseVisualStyleBackColor = false;
            btnSeis.Click += btnSeis_Click;
            // 
            // btnCinco
            // 
            btnCinco.Anchor = AnchorStyles.None;
            btnCinco.BackColor = Color.White;
            btnCinco.FlatAppearance.BorderColor = Color.Black;
            btnCinco.Font = new Font("Verdana", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCinco.Location = new Point(71, 76);
            btnCinco.Name = "btnCinco";
            btnCinco.Size = new Size(50, 64);
            btnCinco.TabIndex = 6;
            btnCinco.Text = "5";
            btnCinco.UseVisualStyleBackColor = false;
            btnCinco.Click += btnCinco_Click;
            // 
            // btnCuatro
            // 
            btnCuatro.Anchor = AnchorStyles.None;
            btnCuatro.BackColor = Color.White;
            btnCuatro.FlatAppearance.BorderColor = Color.Black;
            btnCuatro.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnCuatro.Location = new Point(7, 76);
            btnCuatro.Name = "btnCuatro";
            btnCuatro.Size = new Size(50, 64);
            btnCuatro.TabIndex = 7;
            btnCuatro.Text = "4";
            btnCuatro.UseVisualStyleBackColor = false;
            btnCuatro.Click += btnCuatro_Click;
            // 
            // btnUno
            // 
            btnUno.Anchor = AnchorStyles.None;
            btnUno.BackColor = Color.White;
            btnUno.FlatAppearance.BorderColor = Color.Black;
            btnUno.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnUno.Location = new Point(7, 148);
            btnUno.Name = "btnUno";
            btnUno.Size = new Size(50, 64);
            btnUno.TabIndex = 8;
            btnUno.Text = "1";
            btnUno.UseVisualStyleBackColor = false;
            btnUno.Click += btnUno_Click;
            // 
            // btnDos
            // 
            btnDos.Anchor = AnchorStyles.None;
            btnDos.BackColor = Color.White;
            btnDos.FlatAppearance.BorderColor = Color.Black;
            btnDos.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnDos.Location = new Point(71, 148);
            btnDos.Name = "btnDos";
            btnDos.Size = new Size(50, 64);
            btnDos.TabIndex = 9;
            btnDos.Text = "2";
            btnDos.UseVisualStyleBackColor = false;
            btnDos.Click += btnDos_Click;
            // 
            // btnTres
            // 
            btnTres.Anchor = AnchorStyles.None;
            btnTres.BackColor = Color.White;
            btnTres.FlatAppearance.BorderColor = Color.Black;
            btnTres.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnTres.Location = new Point(135, 148);
            btnTres.Name = "btnTres";
            btnTres.Size = new Size(50, 64);
            btnTres.TabIndex = 10;
            btnTres.Text = "3";
            btnTres.UseVisualStyleBackColor = false;
            btnTres.Click += btnTres_Click;
            // 
            // btnSumar
            // 
            btnSumar.Anchor = AnchorStyles.None;
            btnSumar.BackColor = Color.Gray;
            btnSumar.FlatAppearance.BorderColor = Color.Black;
            btnSumar.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnSumar.Location = new Point(200, 148);
            btnSumar.Name = "btnSumar";
            btnSumar.Size = new Size(50, 64);
            btnSumar.TabIndex = 11;
            btnSumar.Text = "+";
            btnSumar.UseVisualStyleBackColor = false;
            btnSumar.Click += btnSumar_Click;
            // 
            // btnCero
            // 
            btnCero.Anchor = AnchorStyles.None;
            btnCero.BackColor = Color.White;
            btnCero.FlatAppearance.BorderColor = Color.Black;
            btnCero.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnCero.Location = new Point(7, 219);
            btnCero.Name = "btnCero";
            btnCero.Size = new Size(50, 67);
            btnCero.TabIndex = 12;
            btnCero.Text = "0";
            btnCero.UseVisualStyleBackColor = false;
            btnCero.Click += btnCero_Click;
            // 
            // btnCLR
            // 
            btnCLR.Anchor = AnchorStyles.None;
            btnCLR.BackColor = Color.White;
            btnCLR.FlatAppearance.BorderColor = Color.Black;
            btnCLR.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnCLR.Location = new Point(71, 219);
            btnCLR.Name = "btnCLR";
            btnCLR.Size = new Size(50, 67);
            btnCLR.TabIndex = 13;
            btnCLR.Text = "CLR";
            btnCLR.UseVisualStyleBackColor = false;
            btnCLR.Click += btnCLR_Click;
            // 
            // btnIgual
            // 
            btnIgual.Anchor = AnchorStyles.None;
            btnIgual.BackColor = Color.Gray;
            btnIgual.FlatAppearance.BorderColor = Color.Black;
            btnIgual.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnIgual.Location = new Point(135, 219);
            btnIgual.Name = "btnIgual";
            btnIgual.Size = new Size(50, 67);
            btnIgual.TabIndex = 14;
            btnIgual.Text = "=";
            btnIgual.UseVisualStyleBackColor = false;
            btnIgual.Click += btnIgual_Click;
            // 
            // btnRestar
            // 
            btnRestar.Anchor = AnchorStyles.None;
            btnRestar.BackColor = Color.Gray;
            btnRestar.FlatAppearance.BorderColor = Color.Black;
            btnRestar.Font = new Font("Verdana", 7.8F, FontStyle.Bold);
            btnRestar.Location = new Point(200, 219);
            btnRestar.Name = "btnRestar";
            btnRestar.Size = new Size(50, 67);
            btnRestar.TabIndex = 15;
            btnRestar.Text = "-";
            btnRestar.UseVisualStyleBackColor = false;
            btnRestar.Click += btnRestar_Click;
            // 
            // txtBoxPrincipal
            // 
            txtBoxPrincipal.BackColor = Color.Gray;
            txtBoxPrincipal.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBoxPrincipal.Location = new Point(12, 38);
            txtBoxPrincipal.Name = "txtBoxPrincipal";
            txtBoxPrincipal.ReadOnly = true;
            txtBoxPrincipal.Size = new Size(258, 28);
            txtBoxPrincipal.TabIndex = 1;
            // 
            // txtBoxSaved
            // 
            txtBoxSaved.BackColor = Color.Gray;
            txtBoxSaved.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBoxSaved.Location = new Point(12, 5);
            txtBoxSaved.Name = "txtBoxSaved";
            txtBoxSaved.ReadOnly = true;
            txtBoxSaved.Size = new Size(258, 28);
            txtBoxSaved.TabIndex = 2;
            // 
            // Calculadora
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(282, 373);
            Controls.Add(txtBoxSaved);
            Controls.Add(txtBoxPrincipal);
            Controls.Add(tableLayoutPanel1);
            MaximumSize = new Size(300, 420);
            MinimumSize = new Size(300, 420);
            Name = "Calculadora";
            Text = "Calculadora";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSiete;
        private Button btnOcho;
        private Button btnNueve;
        private Button btnDividir;
        private Button btnMultiplicar;
        private Button btnSeis;
        private Button btnCinco;
        private Button btnCuatro;
        private Button btnUno;
        private Button btnDos;
        private Button btnTres;
        private Button btnSumar;
        private Button btnCero;
        private Button btnCLR;
        private Button btnIgual;
        private Button btnRestar;
        private TextBox txtBoxPrincipal;
        private TextBox txtBoxSaved;
    }
}

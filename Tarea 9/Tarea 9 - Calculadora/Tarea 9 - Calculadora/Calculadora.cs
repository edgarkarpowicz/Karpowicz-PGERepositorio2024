using Logger;

namespace Tarea_9___Calculadora
{
    public partial class Calculadora : Form
    {
        double primero, segundo;
        string operador = "";
        public Calculadora()
        {
            Logging.Instance.Log("Calculadora Inicializada");
            InitializeComponent();
        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Se presiono 0");
            txtBoxPrincipal.Text += "0";
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Se presiono 1");
            txtBoxPrincipal.Text += "1";
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Se presiono 2");
            txtBoxPrincipal.Text += "2";
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Se presiono 3");
            txtBoxPrincipal.Text += "3";
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Se presiono 4");
            txtBoxPrincipal.Text += "4";
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Se presiono 5");
            txtBoxPrincipal.Text += "5";
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Se presiono 6");
            txtBoxPrincipal.Text += "6";
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Se presiono 7");
            txtBoxPrincipal.Text += "7";
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Se presiono 8");
            txtBoxPrincipal.Text += "8";
        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Se presiono 9");
            txtBoxPrincipal.Text += "9";
        }

        private void operationVerification()
        {
            Logging.Instance.Log("Verificaci�n de si va a ser multiples Operaciones...");
            if (!(txtBoxSaved.Text == ""))
            {
                Logging.Instance.Log("Multiples Operaciones detectadas");
                btnIgual_Click(this, new EventArgs());
            }
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Divisi�n Presionada");
            if ((txtBoxSaved.Text == "" && txtBoxPrincipal.Text == "") || txtBoxPrincipal.Text == "-" || txtBoxPrincipal.Text == "")
            {
                Logging.Instance.Log("Algo en los txtBox sea el Saved o Principal esta mal");
                return;
            }

            operationVerification();

            try
            {
                primero = Convert.ToDouble(txtBoxPrincipal.Text);
                txtBoxSaved.Text = txtBoxPrincipal.Text + "/";
                txtBoxPrincipal.Text = "";
                operador = "/";
                Logging.Instance.Log($"txtBoxSaved: {txtBoxSaved.Text}");
            }
            catch (FormatException ex)
            {
                Logging.Instance.Log($"Error de Formato en Divisi�n. Casi imposible que esto aparezca: {ex.Message}");
                Console.WriteLine("Error de Formato en Divisi�n. Casi imposible que esto aparezca" + ex.Message);
                System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Error de Formato en Divisi�n");
                return;
            }
            catch (OverflowException ex)
            {
                Logging.Instance.Log($"Operaci�n Aritm�tica con Overflow en Divisi�n: {ex.Message}");
                Console.WriteLine("Operaci�n Aritm�tica con Overflow en Divisi�n" + ex.Message);
                System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Operaci�n Aritm�tica con Overflow en Divisi�n");
                return;
            }
            catch (Exception ex)
            {
                Logging.Instance.Log($"Excepci�n Gen�rica en Divisi�n: {ex.Message}");
                Console.WriteLine("Excepci�n Gen�rica en Divisi�n" + ex.Message);
                System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Excepci�n Gen�rica en Divisi�n");
                return;
            }
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Multiplicaci�n Presionada");
            if ((txtBoxSaved.Text == "" && txtBoxPrincipal.Text == "") || txtBoxPrincipal.Text == "-" || txtBoxPrincipal.Text == "")
            {
                Logging.Instance.Log("Algo en los txtBox sea el Saved o Principal esta mal");
                return;
            }

            operationVerification();

            try
            {
                primero = Convert.ToDouble(txtBoxPrincipal.Text);
                txtBoxSaved.Text = txtBoxPrincipal.Text + "*";
                txtBoxPrincipal.Text = "";
                operador = "*";
                Logging.Instance.Log($"txtBoxSaved: {txtBoxSaved.Text}");
            }
            catch (FormatException ex)
            {
                Logging.Instance.Log($"Error de Formato en Multiplicaci�n. Casi imposible que esto aparezca: {ex.Message}");
                Console.WriteLine("Error de Formato en Multiplicaci�n. Casi imposible que esto aparezca" + ex.Message);
                System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Error de Formato en Multiplicaci�n");
                return;
            }
            catch (OverflowException ex)
            {
                Logging.Instance.Log($"Operaci�n Aritm�tica con Overflow en Multiplicaci�n: {ex.Message}");
                Console.WriteLine("Operaci�n Aritm�tica con Overflow en Multiplicaci�n" + ex.Message);
                System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Operaci�n Aritm�tica con Overflow en Multiplicaci�n");
                return;
            }
            catch (Exception ex)
            {
                Logging.Instance.Log($"Excepci�n Gen�rica en Multiplicaci�n: {ex.Message}");
                Console.WriteLine("Excepci�n Gen�rica en Multiplicaci�n" + ex.Message);
                System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Excepci�n Gen�rica en Multiplicaci�n");
                return;
            }
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Suma Presionada");
            if ((txtBoxSaved.Text == "" && txtBoxPrincipal.Text == "") || txtBoxPrincipal.Text == "-" || txtBoxPrincipal.Text == "")
            {
                Logging.Instance.Log("Algo en los txtBox sea el Saved o Principal esta mal");
                return;
            }

            try
            {
                operationVerification();
                primero = Convert.ToDouble(txtBoxPrincipal.Text);
                txtBoxSaved.Text = txtBoxPrincipal.Text + "+";
                txtBoxPrincipal.Text = "";
                operador = "+";
                Logging.Instance.Log($"txtBoxSaved: {txtBoxSaved.Text}");
            }
            catch (FormatException ex)
            {
                Logging.Instance.Log($"Error de Formato en Suma. Casi imposible que esto aparezca: {ex.Message}");
                Console.WriteLine("Error de Formato en Suma. Casi imposible que esto aparezca" + ex.Message);
                System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Error de Formato en Suma");
                return;
            }
            catch (OverflowException ex)
            {
                Logging.Instance.Log($"Operaci�n Aritm�tica con Overflow en Suma: {ex.Message}");
                Console.WriteLine("Operaci�n Aritm�tica con Overflow en Suma" + ex.Message);
                System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Operaci�n Aritm�tica con Overflow en Suma");
                return;
            }
            catch (Exception ex)
            {
                Logging.Instance.Log($"Excepci�n Gen�rica en Suma: {ex.Message}");
                Console.WriteLine("Excepci�n Gen�rica en Suma" + ex.Message);
                System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Excepci�n Gen�rica en Suma");
                return;
            }
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Resta Presionada");
            if (txtBoxPrincipal.Text == "")
            {
                txtBoxPrincipal.Text += "-";
                return;
            }

            if ((txtBoxSaved.Text == "" && txtBoxPrincipal.Text == "") || txtBoxPrincipal.Text == "-")
            {
                Logging.Instance.Log("Algo en los txtBox sea el Saved o Principal esta mal");
                return;
            } 

            try
            {
                operationVerification();
                primero = Convert.ToDouble(txtBoxPrincipal.Text);
                txtBoxSaved.Text = txtBoxPrincipal.Text + "-";
                txtBoxPrincipal.Text = "";
                operador = "-";
                Logging.Instance.Log($"txtBoxSaved: {txtBoxSaved.Text}");
            }
            catch (FormatException ex)
            {
                Logging.Instance.Log($"Error de Formato en Resta. Casi imposible que esto aparezca: {ex.Message}");
                Console.WriteLine("Error de Formato en Resta. Casi imposible que esto aparezca" + ex.Message);
                System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Error de Formato en Resta");
                return;
            }
            catch (OverflowException ex)
            {
                Logging.Instance.Log($"Operaci�n Aritm�tica con Overflow en Resta: {ex.Message}");
                Console.WriteLine("Operaci�n Aritm�tica con Overflow en Resta" + ex.Message);
                System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Operaci�n Aritm�tica con Overflow en Resta");
                return;
            }
            catch (Exception ex)
            {
                Logging.Instance.Log($"Excepci�n Gen�rica en Resta: {ex.Message}");
                Console.WriteLine("Excepci�n Gen�rica en Resta" + ex.Message);
                System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Excepci�n Gen�rica en Resta");
                return;
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("Igual Presionado");
            Logging.Instance.Log("Los Datos que igual tiene son:");
            Logging.Instance.Log($"txtBoxSaved: {txtBoxSaved.Text}");
            Logging.Instance.Log($"txtBoxPrincipal: {txtBoxPrincipal.Text}");

            if (!(operador == "") && txtBoxPrincipal.Text != "")
            {
                double resultado = 0;

                try
                {
                    segundo = Convert.ToDouble(txtBoxPrincipal.Text);
                    Logging.Instance.Log($"segundo: {segundo}");
                    switch (operador)
                    {
                        case "+":
                            Logging.Instance.Log($"Suma hecha: {resultado}");
                            resultado = primero + segundo;
                            break;

                        case "-":
                            Logging.Instance.Log($"Resta hecha: {resultado}");
                            resultado = primero - segundo;
                            break;

                        case "*":
                            Logging.Instance.Log($"Multiplicaci�n hecha: {resultado}");
                            resultado = primero * segundo;
                            break;

                        case "/":
                            Logging.Instance.Log($"Divisi�n hecha: {resultado}");
                            resultado = primero / segundo;
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Logging.Instance.Log($"Error de Formato en Igualaci�n. Casi imposible que esto aparezca: {ex.Message}");
                    Console.WriteLine("Error de Formato en Igualaci�n. Casi imposible que esto aparezca" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Error de Formato en Igualaci�n");
                    return;
                }
                catch (OverflowException ex)
                {
                    Logging.Instance.Log($"Operaci�n Aritm�tica con Overflow en Igualaci�n: {ex.Message}");
                    Console.WriteLine("Operaci�n Aritm�tica con Overflow en Igualaci�n" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Operaci�n Aritm�tica con Overflow en Igualaci�n");
                    return;
                }
                catch (Exception ex)
                {
                    Logging.Instance.Log($"Excepci�n Gen�rica en Igualaci�n: {ex.Message}");
                    Console.WriteLine("Excepci�n Gen�rica en Igualaci�n" + ex.Message);
                    System.Windows.Forms.MessageBox.Show("EXCEPCI�N: Excepci�n Gen�rica en Igualaci�n");
                    return;
                }

                txtBoxPrincipal.Text = Convert.ToString(resultado);
                txtBoxSaved.Text = "";
                primero = 0;
                segundo = 0;
                operador = "";
            }
        }

        private void btnCLR_Click(object sender, EventArgs e)
        {
            Logging.Instance.Log("B�ton CLR presionado");
            txtBoxPrincipal.Text = "";
            txtBoxSaved.Text = "";
            primero = 0;
            segundo = 0;
            operador = "";
        }
    }
}

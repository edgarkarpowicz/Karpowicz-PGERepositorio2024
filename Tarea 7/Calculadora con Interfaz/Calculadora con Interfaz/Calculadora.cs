namespace Calculadora_con_Interfaz
{
    public partial class Calculadora : Form
    {
        double primero, segundo;
        string operador = "";
        public Calculadora()
        {
            InitializeComponent();
        }

        ClaseSumar sumadora = new ClaseSumar();
        ClaseRestar restadora = new ClaseRestar();
        ClaseMultiplicar multiplicadora = new ClaseMultiplicar();
        ClaseDividir dividora = new ClaseDividir();

        private void VerificarNumero()
        {
            int count = textBox_Principal.Text.Count(f => f == ',');
            if (count > 1)
            {
                throw new InvalidOperationException("Demasiadas Comas en uno de los Numeros");
            } 
        }

        private void VerificarOperadores()
        {
            int countPlus = textBox_Principal.Text.Count(f => f == '+');
            int countMinus = textBox_Principal.Text.Count(f => f == '-');
            int countMultiply = textBox_Principal.Text.Count(f => f == '*');
            int countDivision = textBox_Principal.Text.Count(f => f == '/');
            if (countPlus + 1 > 1 || countMinus + 1 > 2 || countMultiply + 1 > 1 || countDivision + 1 > 1 || (primero != 0 && operador != ""))
            {
                throw new InvalidOperationException("Demasiados Operadores, ponga los Números Negativos Primero");
            }
        }

        private void btn_punto_Click(object sender, EventArgs e)
        {
            if (!(textBox_Principal.Text.Contains(",")))
            {
                if (textBox_Principal.Text.Length < 1)
                {
                    textBox_Principal.Text += "0";
                }
                else
                {
                    textBox_Principal.Text += ",";
                }
            } else if (!(textBox_Principal.Text.EndsWith("+") || textBox_Principal.Text.EndsWith("-") || textBox_Principal.Text.EndsWith("*") || textBox_Principal.Text.EndsWith("/") || textBox_Principal.Text.EndsWith(",")))
            {
                textBox_Principal.Text += ",";
            }
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            textBox_Principal.Text = textBox_Principal.Text + "0";
        }

        private void btn_uno_Click(object sender, EventArgs e)
        {
            textBox_Principal.Text = textBox_Principal.Text + "1";
        }

        private void btn_dos_Click(object sender, EventArgs e)
        {
            textBox_Principal.Text = textBox_Principal.Text + "2";
        }

        private void btn_tres_Click(object sender, EventArgs e)
        {
            textBox_Principal.Text = textBox_Principal.Text + "3";
        }

        private void btn_cuatro_Click(object sender, EventArgs e)
        {
            textBox_Principal.Text = textBox_Principal.Text + "4";
        }

        private void btn_cinco_Click(object sender, EventArgs e)
        {
            textBox_Principal.Text = textBox_Principal.Text + "5";
        }

        private void btn_seis_Click(object sender, EventArgs e)
        {
            textBox_Principal.Text = textBox_Principal.Text + "6";
        }

        private void btn_siete_Click(object sender, EventArgs e)
        {
            textBox_Principal.Text = textBox_Principal.Text + "7";
        }

        private void btn_ocho_Click(object sender, EventArgs e)
        {
            textBox_Principal.Text = textBox_Principal.Text + "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            textBox_Principal.Text = textBox_Principal.Text + "9";
        }

        private void btn_sumar_Click(object sender, EventArgs e)
        {
            VerificarOperadores();
            int count = textBox_Principal.Text.Count(f => f == '+');
            if (textBox_Principal.Text.Length == 0 || textBox_Principal.Text.EndsWith("+") || textBox_Principal.Text.EndsWith("-") || textBox_Principal.Text.EndsWith("*") || textBox_Principal.Text.EndsWith("/") || count == 1)
            {
                return;
            }
            else
            {
                operador = "+";

                VerificarNumero();

                primero = double.Parse(textBox_Principal.Text);
                textBox_Principal.Text = textBox_Principal.Text + "+";
                // textBox_Principal.Clear();
            }
        }

        private void btn_restar_Click(object sender, EventArgs e)
        {
            VerificarOperadores();
            int count = textBox_Principal.Text.Count(f => f == '-');
            if (textBox_Principal.Text.EndsWith("+") || textBox_Principal.Text.EndsWith("-") || count > 2)
            {
                return; 
            } 
            else if (textBox_Principal.Text.Length == 0 || textBox_Principal.Text.EndsWith("*") || textBox_Principal.Text.EndsWith("/"))
            {
                textBox_Principal.Text = textBox_Principal.Text + "-";
            }
            else
            {
                operador = "-";

                VerificarNumero();

                primero = double.Parse(textBox_Principal.Text);
                textBox_Principal.Text = textBox_Principal.Text + "-";
                // textBox_Principal.Clear();
            }
        }

        private void btn_multiplicar_Click(object sender, EventArgs e)
        {
            VerificarOperadores();
            int count = textBox_Principal.Text.Count(f => f == '*');
            if (textBox_Principal.Text.Length == 0 || textBox_Principal.Text.EndsWith("+") || textBox_Principal.Text.EndsWith("-") || textBox_Principal.Text.EndsWith("*") || textBox_Principal.Text.EndsWith("/") || count == 1)
            {
                return;
            }
            else
            {
                operador = "*";

                VerificarNumero();

                primero = double.Parse(textBox_Principal.Text);
                textBox_Principal.Text = textBox_Principal.Text + "*";
                // textBox_Principal.Clear();
            }
        }

        private void btn_dividir_Click(object sender, EventArgs e)
        {
            VerificarOperadores();
            int count = textBox_Principal.Text.Count(f => f == '/');
            if (textBox_Principal.Text.Length == 0 || textBox_Principal.Text.EndsWith("+") || textBox_Principal.Text.EndsWith("-") || textBox_Principal.Text.EndsWith("*") || textBox_Principal.Text.EndsWith("/") || count == 1)
            {
                return;
            }
            else
            {
                operador = "/";

                VerificarNumero();

                primero = double.Parse(textBox_Principal.Text);
                textBox_Principal.Text = textBox_Principal.Text + "/";
                // textBox_Principal.Clear();
            }
        }

        private void btn_clr_Click(object sender, EventArgs e)
        {
            textBox_Principal.Clear();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (!(textBox_Principal.Text.Length == 0))
            {
                if (textBox_Principal.Text.Length == 1)
                {
                    textBox_Principal.Clear();
                }
                else
                {
                    textBox_Principal.Text = textBox_Principal.Text.Substring(0, textBox_Principal.Text.Length - 1);
                }
            }
        }

        private void btn_igual_Click(object sender, EventArgs e)
        {
            int primeroSize = primero.ToString().Length;
            primeroSize++;

            if (operador == "" || textBox_Principal.Text.Length == primero.ToString().Length + 1)
            {
                return;
            }

            textBox_Principal.Text = textBox_Principal.Text.Remove(0, primeroSize);

            VerificarNumero();

            segundo = double.Parse(textBox_Principal.Text);

            double Sum;
            double Res;
            double Mul;
            double Div;

            switch (operador)
            {
                case "+":
                    Sum = sumadora.Sumar((primero), (segundo));
                    textBox_Principal.Text = Sum.ToString();
                    break;

                case "-":
                    Res = restadora.Restar((primero), (segundo));
                    textBox_Principal.Text = Res.ToString();
                    break;

                case "*":
                    Mul = multiplicadora.Multiplicar((primero), (segundo));
                    textBox_Principal.Text = Mul.ToString();
                    break;

                case "/":
                    Div = dividora.Dividir((primero), (segundo));
                    textBox_Principal.Text = Div.ToString();
                    break;
            }

            operador = "";
        }
    }
}

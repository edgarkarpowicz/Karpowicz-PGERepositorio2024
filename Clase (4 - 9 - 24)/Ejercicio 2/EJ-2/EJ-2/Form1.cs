namespace EJ_2
{
    public partial class Form1 : Form
    {
        bool color = false;
        bool width = false;
        bool text = false;
        bool align = false;
        bool border = false;
        bool height = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void labelColor_Click(object sender, EventArgs e)
        {
            if (color == false)
            {
                color = true;
            }
            else
            {
                color = false;
            }
        }

        private void labelWidth_Click(object sender, EventArgs e)
        {
            if (width == false)
            {
                width = true;
            }
            else
            {
                width = false;
            }
        }

        private void labelText_Click(object sender, EventArgs e)
        {
            if (text == false)
            {
                text = true;
            }
            else
            {
                text = false;
            }
        }

        private void labelAlign_Click(object sender, EventArgs e)
        {
            if (align == false)
            {
                align = true;
            }
            else
            {
                align = false;
            }
        }

        private void labelBorder_Click(object sender, EventArgs e)
        {
            if (border == false)
            {
                border = true;
            }
            else
            {
                border = false;
            }
        }

        private void labelHeight_Click(object sender, EventArgs e)
        {
            if (height == false)
            {
                height = true;
            }
            else
            {
                height = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setColor(color);
            setWidth(width);
            setText(text);
            setAlign(align);
            setBorder(border);
            setHeight(height);
        }

        void setColor(bool color)
        {
            if (color)
            {
                button.ForeColor.Equals(Color.HotPink);
            }
        }

        void setWidth(bool width)
        {
            if (width)
            {
                button.Width.Equals(50);
            }
        }

        void setText(bool text)
        {
            if (text)
            {
                button.Text.Equals("No soy un Boton");
            }
        }

        void setAlign(bool align)
        {
            if (align)
            {
                button.TextAlign.Equals(StringAlignment.Far);
            }
        }

        void setBorder(bool border)
        {
            if (border)
            {
                button.FlatAppearance.BorderColor = Color.Red;
                button.FlatAppearance.BorderSize = 1;
            }
        }

        void setHeight(bool height)
        {
            if (height)
            {
                button.Height.Equals(50);
            }
        }
    }
}

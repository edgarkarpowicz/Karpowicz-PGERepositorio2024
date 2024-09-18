namespace EJ_2
{
    partial class Form1
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            labelColor = new Label();
            labelWidth = new Label();
            labelText = new Label();
            labelAlign = new Label();
            labelBorder = new Label();
            labelHeight = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button = new Button();
            button1 = new Button();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(labelColor);
            flowLayoutPanel1.Controls.Add(labelWidth);
            flowLayoutPanel1.Controls.Add(labelText);
            flowLayoutPanel1.Controls.Add(labelAlign);
            flowLayoutPanel1.Controls.Add(labelBorder);
            flowLayoutPanel1.Controls.Add(labelHeight);
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(569, 29);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // labelColor
            // 
            labelColor.Anchor = AnchorStyles.None;
            labelColor.AutoSize = true;
            labelColor.Font = new Font("SimSun", 12F, FontStyle.Bold);
            labelColor.ForeColor = Color.HotPink;
            labelColor.Location = new Point(3, 0);
            labelColor.Name = "labelColor";
            labelColor.Padding = new Padding(10, 0, 10, 0);
            labelColor.Size = new Size(84, 20);
            labelColor.TabIndex = 0;
            labelColor.Text = "Color";
            labelColor.TextAlign = ContentAlignment.MiddleCenter;
            labelColor.Click += labelColor_Click;
            // 
            // labelWidth
            // 
            labelWidth.Anchor = AnchorStyles.None;
            labelWidth.AutoSize = true;
            labelWidth.Font = new Font("SimSun", 12F, FontStyle.Bold);
            labelWidth.ForeColor = SystemColors.ActiveCaption;
            labelWidth.Location = new Point(93, 0);
            labelWidth.Name = "labelWidth";
            labelWidth.Padding = new Padding(10, 0, 10, 0);
            labelWidth.Size = new Size(84, 20);
            labelWidth.TabIndex = 1;
            labelWidth.Text = "Width";
            labelWidth.TextAlign = ContentAlignment.MiddleCenter;
            labelWidth.Click += labelWidth_Click;
            // 
            // labelText
            // 
            labelText.Anchor = AnchorStyles.None;
            labelText.AutoSize = true;
            labelText.Font = new Font("SimSun", 12F, FontStyle.Bold);
            labelText.ForeColor = SystemColors.MenuHighlight;
            labelText.Location = new Point(183, 0);
            labelText.Name = "labelText";
            labelText.Padding = new Padding(10, 0, 10, 0);
            labelText.Size = new Size(73, 20);
            labelText.TabIndex = 2;
            labelText.Text = "Text";
            labelText.TextAlign = ContentAlignment.MiddleCenter;
            labelText.Click += labelText_Click;
            // 
            // labelAlign
            // 
            labelAlign.Anchor = AnchorStyles.None;
            labelAlign.AutoSize = true;
            labelAlign.Font = new Font("SimSun", 12F, FontStyle.Bold);
            labelAlign.ForeColor = Color.Yellow;
            labelAlign.Location = new Point(262, 0);
            labelAlign.Name = "labelAlign";
            labelAlign.Padding = new Padding(10, 0, 10, 0);
            labelAlign.Size = new Size(84, 20);
            labelAlign.TabIndex = 3;
            labelAlign.Text = "Align";
            labelAlign.TextAlign = ContentAlignment.MiddleCenter;
            labelAlign.Click += labelAlign_Click;
            // 
            // labelBorder
            // 
            labelBorder.Anchor = AnchorStyles.None;
            labelBorder.AutoSize = true;
            labelBorder.Font = new Font("SimSun", 12F, FontStyle.Bold);
            labelBorder.ForeColor = Color.DimGray;
            labelBorder.Location = new Point(352, 0);
            labelBorder.Name = "labelBorder";
            labelBorder.Padding = new Padding(10, 0, 10, 0);
            labelBorder.Size = new Size(95, 20);
            labelBorder.TabIndex = 4;
            labelBorder.Text = "Border";
            labelBorder.TextAlign = ContentAlignment.MiddleCenter;
            labelBorder.Click += labelBorder_Click;
            // 
            // labelHeight
            // 
            labelHeight.Anchor = AnchorStyles.None;
            labelHeight.AutoSize = true;
            labelHeight.Font = new Font("SimSun", 12F, FontStyle.Bold);
            labelHeight.ForeColor = Color.Gold;
            labelHeight.Location = new Point(453, 0);
            labelHeight.Name = "labelHeight";
            labelHeight.Padding = new Padding(10, 0, 10, 0);
            labelHeight.Size = new Size(95, 20);
            labelHeight.TabIndex = 5;
            labelHeight.Text = "Height";
            labelHeight.TextAlign = ContentAlignment.MiddleCenter;
            labelHeight.Click += labelHeight_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(button);
            flowLayoutPanel2.Controls.Add(button1);
            flowLayoutPanel2.Location = new Point(12, 50);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(569, 125);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // button
            // 
            button.Font = new Font("SimSun", 19.8000011F, FontStyle.Bold | FontStyle.Italic);
            button.Location = new Point(3, 3);
            button.Name = "button";
            button.Size = new Size(175, 115);
            button.TabIndex = 0;
            button.Text = "Boton";
            button.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Right;
            button1.Font = new Font("SimSun", 19.8000011F, FontStyle.Bold | FontStyle.Italic);
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(184, 3);
            button1.Name = "button1";
            button1.Size = new Size(380, 115);
            button1.TabIndex = 1;
            button1.Text = "Asignar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 187);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label labelColor;
        private Label labelWidth;
        private Label labelText;
        private Label labelAlign;
        private Label labelBorder;
        private Label labelHeight;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button;
        private Button button1;
    }
}

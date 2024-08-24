namespace Physics_project_9_class
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            button1 = new Button();
            label1 = new Label();
            UniformMotionLabel = new Label();
            label3 = new Label();
            UniformCircularMotionLabel = new Label();
            EquidistantMotionLabel = new Label();
            ElectricalResistivityLabel = new Label();
            UniformMotionMaskedTextBox = new MaskedTextBox();
            UniformCircularMotionMaskedTextBox = new MaskedTextBox();
            EquidistantMotionMaskedTextBox = new MaskedTextBox();
            ElectricalResistivityMaskedTextBox = new MaskedTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.BackColor = Color.FromArgb(54, 169, 250);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Calibri", 24F);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(40, 361);
            button1.Name = "button1";
            button1.Size = new Size(680, 118);
            button1.TabIndex = 0;
            button1.Text = "Старт";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(54, 169, 250);
            label1.Font = new Font("Calibri", 24F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(197, 40);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(394, 39);
            label1.TabIndex = 2;
            label1.Text = "Выберите количество задач";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UniformMotionLabel
            // 
            UniformMotionLabel.Anchor = AnchorStyles.None;
            UniformMotionLabel.BackColor = Color.FromArgb(54, 169, 250);
            UniformMotionLabel.Font = new Font("Calibri", 18F);
            UniformMotionLabel.ForeColor = Color.Black;
            UniformMotionLabel.Location = new Point(40, 120);
            UniformMotionLabel.Name = "UniformMotionLabel";
            UniformMotionLabel.Size = new Size(430, 30);
            UniformMotionLabel.TabIndex = 3;
            UniformMotionLabel.Text = "Равномерное движение";
            UniformMotionLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 0;
            // 
            // UniformCircularMotionLabel
            // 
            UniformCircularMotionLabel.Anchor = AnchorStyles.None;
            UniformCircularMotionLabel.BackColor = Color.FromArgb(54, 169, 250);
            UniformCircularMotionLabel.Font = new Font("Calibri", 18F);
            UniformCircularMotionLabel.ForeColor = Color.Black;
            UniformCircularMotionLabel.Location = new Point(40, 180);
            UniformCircularMotionLabel.Name = "UniformCircularMotionLabel";
            UniformCircularMotionLabel.Size = new Size(430, 30);
            UniformCircularMotionLabel.TabIndex = 5;
            UniformCircularMotionLabel.Text = "Равномерное движение по окружности\r\n\r\n\r\n";
            UniformCircularMotionLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EquidistantMotionLabel
            // 
            EquidistantMotionLabel.Anchor = AnchorStyles.None;
            EquidistantMotionLabel.BackColor = Color.FromArgb(54, 169, 250);
            EquidistantMotionLabel.Font = new Font("Calibri", 18F);
            EquidistantMotionLabel.ForeColor = Color.Black;
            EquidistantMotionLabel.Location = new Point(40, 240);
            EquidistantMotionLabel.Name = "EquidistantMotionLabel";
            EquidistantMotionLabel.Size = new Size(430, 30);
            EquidistantMotionLabel.TabIndex = 7;
            EquidistantMotionLabel.Text = "Равноускоренное движение\r\n";
            EquidistantMotionLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ElectricalResistivityLabel
            // 
            ElectricalResistivityLabel.Anchor = AnchorStyles.None;
            ElectricalResistivityLabel.BackColor = Color.FromArgb(54, 169, 250);
            ElectricalResistivityLabel.Font = new Font("Calibri", 18F);
            ElectricalResistivityLabel.ForeColor = Color.Black;
            ElectricalResistivityLabel.Location = new Point(40, 300);
            ElectricalResistivityLabel.Name = "ElectricalResistivityLabel";
            ElectricalResistivityLabel.Size = new Size(430, 30);
            ElectricalResistivityLabel.TabIndex = 9;
            ElectricalResistivityLabel.Text = "Удельное электрическое сопротивление\r\n";
            ElectricalResistivityLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // UniformMotionMaskedTextBox
            // 
            UniformMotionMaskedTextBox.Anchor = AnchorStyles.None;
            UniformMotionMaskedTextBox.BackColor = Color.White;
            UniformMotionMaskedTextBox.Location = new Point(547, 127);
            UniformMotionMaskedTextBox.Mask = "00000";
            UniformMotionMaskedTextBox.Name = "UniformMotionMaskedTextBox";
            UniformMotionMaskedTextBox.Size = new Size(173, 23);
            UniformMotionMaskedTextBox.TabIndex = 10;
            UniformMotionMaskedTextBox.ValidatingType = typeof(int);
            // 
            // UniformCircularMotionMaskedTextBox
            // 
            UniformCircularMotionMaskedTextBox.Anchor = AnchorStyles.None;
            UniformCircularMotionMaskedTextBox.BackColor = Color.White;
            UniformCircularMotionMaskedTextBox.Location = new Point(547, 187);
            UniformCircularMotionMaskedTextBox.Mask = "00000";
            UniformCircularMotionMaskedTextBox.Name = "UniformCircularMotionMaskedTextBox";
            UniformCircularMotionMaskedTextBox.Size = new Size(173, 23);
            UniformCircularMotionMaskedTextBox.TabIndex = 11;
            UniformCircularMotionMaskedTextBox.ValidatingType = typeof(int);
            // 
            // EquidistantMotionMaskedTextBox
            // 
            EquidistantMotionMaskedTextBox.Anchor = AnchorStyles.None;
            EquidistantMotionMaskedTextBox.BackColor = Color.White;
            EquidistantMotionMaskedTextBox.Location = new Point(547, 247);
            EquidistantMotionMaskedTextBox.Mask = "00000";
            EquidistantMotionMaskedTextBox.Name = "EquidistantMotionMaskedTextBox";
            EquidistantMotionMaskedTextBox.Size = new Size(173, 23);
            EquidistantMotionMaskedTextBox.TabIndex = 12;
            EquidistantMotionMaskedTextBox.ValidatingType = typeof(int);
            // 
            // ElectricalResistivityMaskedTextBox
            // 
            ElectricalResistivityMaskedTextBox.Anchor = AnchorStyles.None;
            ElectricalResistivityMaskedTextBox.BackColor = Color.White;
            ElectricalResistivityMaskedTextBox.Location = new Point(547, 307);
            ElectricalResistivityMaskedTextBox.Mask = "00000";
            ElectricalResistivityMaskedTextBox.Name = "ElectricalResistivityMaskedTextBox";
            ElectricalResistivityMaskedTextBox.Size = new Size(173, 23);
            ElectricalResistivityMaskedTextBox.TabIndex = 13;
            ElectricalResistivityMaskedTextBox.ValidatingType = typeof(int);
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 244);
            ClientSize = new Size(772, 501);
            Controls.Add(ElectricalResistivityMaskedTextBox);
            Controls.Add(EquidistantMotionMaskedTextBox);
            Controls.Add(UniformCircularMotionMaskedTextBox);
            Controls.Add(UniformMotionMaskedTextBox);
            Controls.Add(ElectricalResistivityLabel);
            Controls.Add(EquidistantMotionLabel);
            Controls.Add(UniformCircularMotionLabel);
            Controls.Add(label3);
            Controls.Add(UniformMotionLabel);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "";
            Text = "Генератор задач по физике";
            FormClosing += Form2_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e) // Реализует выход из приложения, если закрыть форму Form2 вручную
        {
            Application.Exit();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label UniformMotionLabel;
        private Label label3;
        private Label UniformCircularMotionLabel;
        private Label EquidistantMotionLabel;
        private Label ElectricalResistivityLabel;
        private MaskedTextBox UniformMotionMaskedTextBox;
        private MaskedTextBox UniformCircularMotionMaskedTextBox;
        private MaskedTextBox EquidistantMotionMaskedTextBox;
        private MaskedTextBox ElectricalResistivityMaskedTextBox;
    }
}
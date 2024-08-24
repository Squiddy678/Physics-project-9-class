namespace Physics_project_9_class
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            fileSystemWatcher1 = new FileSystemWatcher();
            folderBrowserDialog1 = new FolderBrowserDialog();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.BackColor = Color.FromArgb(54, 169, 250);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Calibri", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(219, 290);
            button1.Name = "button1";
            button1.Size = new Size(350, 160);
            button1.TabIndex = 0;
            button1.Text = "Открыть";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.BackColor = Color.FromArgb(54, 169, 250);
            label1.Font = new Font("Calibri", 36F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(105, 60);
            label1.Name = "label1";
            label1.Size = new Size(578, 68);
            label1.TabIndex = 1;
            label1.Text = "Генератор задач по физике";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.BackColor = Color.FromArgb(54, 169, 250);
            label2.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(197, 200);
            label2.Name = "label2";
            label2.Size = new Size(394, 30);
            label2.TabIndex = 2;
            label2.Text = "Выберите путь для папки с задачами";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 244);
            ClientSize = new Size(772, 501);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Генератор задач по физике";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e) // Реализует выход из приложения, если закрыть форму Form1 вручную
        {
            Application.Exit();
        }

        #endregion

        private FileSystemWatcher fileSystemWatcher1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button1;
        private Label label1;
        private Label label2;
    }
}

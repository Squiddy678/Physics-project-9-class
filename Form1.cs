using System.Windows.Forms;

namespace Physics_project_9_class
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Блок для выбора пути для папки с задачами
            while (Program.mainFolder == null)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) // Если папка выбрана
                {
                    Program.mainFolder = $"{folderBrowserDialog1.SelectedPath}\\Задачи по физике";
                }
                else
                {
                    MessageBox.Show("Выберите путь для папки с задачами!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            Form2 form2 = new Form2(); // Создание объекта формы Form2
            form2.Show(); // Form2 открывается
            Hide(); // Текущая форма скрывается
        }
    }
}

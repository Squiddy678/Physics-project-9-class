namespace Physics_project_9_class
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try // Обработка исключения FormatException
            {
                // Переменные номера задачи, вводимого в текстовое поле
                int UniformMotionNumberOfTasks;
                int UniformCircularMotionNumberOfTasks;
                int EquidistantMotionNumberOfTasks;
                int ElectricalResistivityNumberOfTasks;

                string indent = "-----------------------------------------------------------------------------------------------------------------------";

                //  Блок для создания папок с задачами, если текстовые поля не пустые
                if (!string.IsNullOrEmpty(UniformMotionMaskedTextBox.Text) || 
                    !string.IsNullOrEmpty(UniformCircularMotionMaskedTextBox.Text) || 
                    !string.IsNullOrEmpty(EquidistantMotionMaskedTextBox.Text) || 
                    !string.IsNullOrEmpty(ElectricalResistivityMaskedTextBox.Text))
                {
                    Program.CreateFolderIfNotExists(Program.mainFolder);
                    Program.CreateTextFileOfLogsIfNotExists(Program.logFilePath);
                    StreamWriter writerOfTextFileOfLogs = new StreamWriter(Program.logFilePath, true); // Объект класса StreamWriter.
                                                                                                                // Реализует запись логов о сгенерированных задачах в созданный текстовый файл.
                                                                                                                // Параметр true нужен для добавления текста в конец файла, а false - для перезаписи.

                    writerOfTextFileOfLogs.WriteLine(DateTime.Now);
                    writerOfTextFileOfLogs.WriteLine(indent);
                    writerOfTextFileOfLogs.WriteLine(Program.mainFolder);
                    writerOfTextFileOfLogs.WriteLine(indent);

                    // Если текстовые поля не пусты
                    if (!string.IsNullOrEmpty(UniformMotionMaskedTextBox.Text))
                    {
                        UniformMotionNumberOfTasks = Convert.ToInt32(UniformMotionMaskedTextBox.Text);
                        Program.CreateFolderIfNotExists(UniformMotion.folder);
                        UniformMotion task1 = new UniformMotion(UniformMotionNumberOfTasks);
                        writerOfTextFileOfLogs.WriteLine($"Равномерное движение - {UniformMotionNumberOfTasks}");
                        writerOfTextFileOfLogs.WriteLine(indent);
                    }
                    if (!string.IsNullOrEmpty(UniformCircularMotionMaskedTextBox.Text))
                    {
                        UniformCircularMotionNumberOfTasks = Convert.ToInt32(UniformCircularMotionMaskedTextBox.Text);
                        Program.CreateFolderIfNotExists(UniformCircularMotion.folder);
                        UniformCircularMotion task2 = new UniformCircularMotion(UniformCircularMotionNumberOfTasks);
                        writerOfTextFileOfLogs.WriteLine($"Равномерное движение по окружности - {UniformCircularMotionNumberOfTasks}");
                        writerOfTextFileOfLogs.WriteLine(indent);
                    }
                    if (!string.IsNullOrEmpty(EquidistantMotionMaskedTextBox.Text))
                    {
                        EquidistantMotionNumberOfTasks = Convert.ToInt32(EquidistantMotionMaskedTextBox.Text);
                        Program.CreateFolderIfNotExists(EquidistantMotion.folder);
                        EquidistantMotion task3 = new EquidistantMotion(EquidistantMotionNumberOfTasks);
                        writerOfTextFileOfLogs.WriteLine($"Равноускоренное движение - {EquidistantMotionNumberOfTasks}");
                        writerOfTextFileOfLogs.WriteLine(indent);
                    }
                    if (!string.IsNullOrEmpty(ElectricalResistivityMaskedTextBox.Text))
                    {
                        ElectricalResistivityNumberOfTasks = Convert.ToInt32(ElectricalResistivityMaskedTextBox.Text);
                        Program.CreateFolderIfNotExists(ElectricalResistivity.folder);
                        ElectricalResistivity task4 = new ElectricalResistivity(ElectricalResistivityNumberOfTasks);
                        writerOfTextFileOfLogs.WriteLine($"Удельное электрическое сопротивление - {ElectricalResistivityNumberOfTasks}");
                        writerOfTextFileOfLogs.WriteLine(indent);
                    }
                    MessageBox.Show("Задачи успешно созданы в указанной вами папке!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    writerOfTextFileOfLogs.WriteLine();
                    writerOfTextFileOfLogs.WriteLine();
                    writerOfTextFileOfLogs.Close();
                }
                else
                {
                    MessageBox.Show("Введите количество задач!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Возникло исключение FormatException!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Введите корректные значения для задач", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit(); // Выход из приложения
            }
            Application.Exit(); // Выход из приложения
        }
    }
}

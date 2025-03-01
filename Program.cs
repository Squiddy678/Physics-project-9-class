using System.Text;

namespace Physics_project_9_class
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        public static string? mainFolder; // ���� � ������� �����
        public readonly static string logFilePath = "..\\..\\..\\Logs.txt"; // ���� � ���������� ����� � ������
        public static Random random = new Random(); // ������ ������ Random
        public static int counter = 0; // ������������ ��� ��������� �����
        public static void CreateFolderIfNotExists(string path) // ����� ��� �������� ����� 
        {
            try // ��������� ���������� FileNotFoundException
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("�������� ���������� FileNotFoundException!", "���������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("���������� ������� ������ �����", "���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit(); // ����� �� ����������
            }
        }
        public static void CreateTextFileOfLogsIfNotExists(string path) // ����� ��� �������� ���������� ����� � ������ 
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close(); // ������� ����� ��������� ���� ��� ����� � ����� ��� ��������� �� ��������� ��������������� ����������
            }
        }
            
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1()); // ������ ��������� � ����� Form1
        }
    }
    class UniformMotion // ����������� �������� 
    {
        private readonly static string topic = "����������� ��������"; // ���� ������
        public readonly static string folder = $"{Program.mainFolder}\\{topic}"; // �������� ����� � �������� � �������� �� ���
        private readonly static string pathOfTasks = $"{folder}\\������.txt"; // ���� � ���������� ����� � ��������
        private readonly static string pathOfAnswers = $"{folder}\\������.txt"; // ���� � ���������� ����� � ��������

        //StreamWriter streamWriter = File.CreateText(path);
        private readonly StreamWriter tasks = new StreamWriter(pathOfTasks, false); // ������ ������ StreamWriter. ��������� ������ ������� ����� � ��������� ����
        private readonly StreamWriter answers = new StreamWriter(pathOfAnswers, false); // ������ ������ StreamWriter. ��������� ������ ������� �� ������ � ��������� ����

        // ���� ���������� � �������
        private double S;
        private double v;
        private double t;

        public UniformMotion(int numberOfTasks) // ����������� � ������� ����������� ���������� ����� � ����� ��� ������ ������
        {
            tasks.WriteLine("������ ������. ��������� ����� �� �������!");
            tasks.WriteLine($"����: {topic}");
            tasks.WriteLine();
            for (int i = 0; i < numberOfTasks; i++)
            {
                Program.counter = i + 1;
                tasks.Write($"{Program.counter})  ");
                answers.Write($"{Program.counter})  ");
                Calculation();
                tasks.WriteLine();
                answers.WriteLine();
            }
            tasks.Close();
            answers.Close();
        }
        private void Calculation() // ������� ����� � ������� �������� ���������� ����������� ���������� � ��� ��� ������������ ������ � ����� � ���
        {
            int rand = Program.random.Next(3); // ��������� ����� ����� � �������� ��� ������������ ����������� ����������
            switch (rand)
            {
                case 0:
                    v = Program.random.Next(10, 150);
                    t = Program.random.Next(1, 10);
                    S = v * t;
                    tasks.WriteLine($"������� ������� ���������� ���� S �� ���������� v [{v} ��/�] �� ����� t [{t} �].");
                    tasks.WriteLine($"���������� S. ����� ����� � ��.");
                    tasks.WriteLine("S = vt");
                    answers.WriteLine($"�����: {S} ��.");
                    break;
                case 1:
                    S = Program.random.Next(10, 200);
                    t = Program.random.Next(1, 10);
                    v = Math.Round(S / t, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"������� ������� ���������� ���� S [{S} ��] �� ���������� v �� ����� t [{t} �].");
                    tasks.WriteLine($"���������� v. ����� ����� � ��/�.");
                    tasks.WriteLine("v = S / t");
                    answers.WriteLine($"�����: {v} ��/�.");
                    break;
                case 2:
                    S = Program.random.Next(10, 200);
                    v = Program.random.Next(10, 150);
                    t = Math.Round(S / v, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"������� ������� ���������� ���� S [{S} ��] �� ���������� v [{v} ��/�] �� ����� t.");
                    tasks.WriteLine($"���������� t. ����� ����� � �.");
                    tasks.WriteLine("t = S / v");
                    answers.WriteLine($"�����: {t} �.");
                    break;
            }
        }
    }
    class EquidistantMotion // ��������������� ��������
    {
        private readonly static string topic = "��������������� ��������"; // ���� ������
        public readonly static string folder = $"{Program.mainFolder}\\��������������� ��������"; // �������� ����� � �������� � �������� �� ���
        private readonly static string pathOfTasks = $"{folder}\\������.txt"; // ���� � ���������� ����� � ��������
        private readonly static string pathOfAnswers = $"{folder}\\������.txt"; // ���� � ���������� ����� � ��������

        private readonly StreamWriter tasks = new StreamWriter(pathOfTasks, false); // ������ ������ StreamWriter. ��������� ������ ������� ����� � ��������� ����
        private readonly StreamWriter answers = new StreamWriter(pathOfAnswers, false); // ������ ������ StreamWriter. ��������� ������ ������� �� ������ � ��������� ����

        // ���� ���������� � �������
        private double S;
        private double v0;
        private double a;
        private double t;
        private static double QuadraticEquation(double a, double b, double c) // �����, �������� ���������� ��������� ����� ������������
        {
            double D = Math.Round((Math.Pow(b, 2) - 4 * a * c), 1, MidpointRounding.AwayFromZero);
            double x1 = Math.Round((-b - Math.Round(Math.Sqrt(D), 1, MidpointRounding.AwayFromZero)) / (2 * a), 1, MidpointRounding.AwayFromZero);
            double x2 = Math.Round((-b + Math.Round(Math.Sqrt(D), 1, MidpointRounding.AwayFromZero)) / (2 * a), 1, MidpointRounding.AwayFromZero); // ������ �������������.
            return x1;
        }

        public EquidistantMotion(int numberOfTasks) // ����������� � ������� ����������� ���������� ����� � ����� ��� ������ ������
        {
            tasks.WriteLine("������ ������. ��������� ����� �� �������!");
            tasks.WriteLine($"����: {topic}.");
            tasks.WriteLine();
            for (int i = 0; i < numberOfTasks; i++)
            {
                Program.counter = i + 1;
                tasks.Write($"{Program.counter})  ");
                answers.Write($"{Program.counter})  ");
                Calculation();
                tasks.WriteLine();
                answers.WriteLine();
            }
            tasks.Close();
            answers.Close();
        }
        private void Calculation() // ������� ����� � ������� �������� ���������� ����������� ���������� � ��� ��� ������������ ������ � ����� � ���
        {
            int rand = Program.random.Next(4); // ��������� ����� ����� � �������� ��� ������������ ����������� ����������
            switch (rand)
            {
                case 0:
                    v0 = Program.random.Next(10, 100);
                    a = Math.Round(Program.random.NextDouble() * (3 - 0.5) + 0.5, 1, MidpointRounding.AwayFromZero);
                    t = Program.random.Next(3, 10);
                    S = v0 * t + a * Math.Pow(t, 2) / 2;
                    tasks.WriteLine($"���������� ������ ���� S � ������� t [{t} c] � ���������� a [{a} �/�^2], ���� ��������� �������� v0 [{v0} �/�].");
                    tasks.WriteLine("���������� S. ����� ����� � �.");
                    tasks.WriteLine("S = v0t + at^2 / 2");
                    answers.WriteLine($"�����: {S} �.");
                    break;
                case 1:
                    S = Program.random.Next(80, 200);
                    a = Math.Round(Program.random.NextDouble() * (3 - 0.5) + 0.5, 1, MidpointRounding.AwayFromZero);
                    t = Program.random.Next(3, 10);
                    v0 = Math.Round((S - a * Math.Pow(t, 2) / 2) / t, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"���������� ������ ���� S[{S} �] � ������� t [{t} c] � ���������� a [{a} �/�^2], ���� ��������� �������� v0.");
                    tasks.WriteLine($"���������� v0. ����� ����� � �/�.");
                    tasks.WriteLine("v0 = (S - a * t^2 / 2) / t");
                    answers.WriteLine($"�����: {v0} �/�.");
                    break;
                case 2:
                    S = Program.random.Next(80, 200);
                    v0 = Program.random.Next(10, 100);
                    t = Program.random.Next(3, 10);
                    a = Math.Round((S - v0 * t) / (Math.Pow(t, 2) / 2), 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"���������� ������ ���� S[{S} �] � ���������� a, ���� ��������� �������� v0 [{v0} �/�].");
                    tasks.WriteLine($"���������� a. ����� ����� � �/�^2.");
                    tasks.WriteLine("a = (S - v0 * t) / (t^2 / 2)");
                    answers.WriteLine($"�����: {a} �/�^2.");
                    break;
                case 3:
                    S = Program.random.Next(80, 200);
                    v0 = Program.random.Next(10, 100);
                    a = Math.Round(Program.random.NextDouble() * (3 - 0.5) + 0.5, 1, MidpointRounding.AwayFromZero);
                    t = QuadraticEquation(-a / 2, -v0, S);
                    tasks.WriteLine($"���������� ������ ���� S[{S} �] � ������� t � ���������� a [{a} �/�^2], ���� ��������� �������� v0 [{v0} �/�].");
                    tasks.WriteLine($"���������� t. ����� ����� � c.");
                    tasks.WriteLine("t = (-at^2 - v0t + S = 0)");
                    answers.WriteLine($"�����: {t} c.");
                    break;
            }
        }
    }
    class UniformCircularMotion // ����������� �������� �� ����������
    {
        private readonly static string topic = "����������� �������� �� ����������"; // ���� ������
        public readonly static string folder = $"{Program.mainFolder}\\{topic}"; // �������� ����� � �������� � �������� �� ���
        private readonly static string pathOfTasks = $"{folder}\\������.txt"; // ���� � ���������� ����� � ��������
        private readonly static string pathOfAnswers = $"{folder}\\������.txt"; // ���� � ���������� ����� � ��������

        private readonly StreamWriter tasks = new StreamWriter(pathOfTasks, false); // ������ ������ StreamWriter. ��������� ������ ������� ����� � ��������� ����
        private readonly StreamWriter answers = new StreamWriter(pathOfAnswers, false); // ������ ������ StreamWriter. ��������� ������ ������� �� ������ � ��������� ����

        // ���� ���������� � �������
        private double v;
        private double w;
        private double D;
        private double v_nu;
        private const double pi = Math.PI;

        public UniformCircularMotion(int numberOfTasks) // ����������� � ������� ����������� ���������� ����� � ����� ��� ������ ������
        {
            tasks.WriteLine("������ ������. ��������� ����� �� �������! �� �������� ��������� ��� �������� � ��!");
            tasks.WriteLine($"����: {topic}.");
            tasks.WriteLine();
            for (int i = 0; i < numberOfTasks; i++)
            {
                Program.counter = i + 1;
                tasks.Write($"{Program.counter})  ");
                answers.Write($"{Program.counter})  ");
                Calculation();
                tasks.WriteLine();
                answers.WriteLine();
            }
            tasks.Close();
            answers.Close();
        }
        private void Calculation() // ������� ����� � ������� �������� ���������� ����������� ���������� � ��� ��� ������������ ������ � ����� � ���
        {
            int rand = Program.random.Next(4); // ��������� ����� ����� � �������� ��� ������������ ����������� ����������
            switch (rand)
            {
                case 0:
                    D = Math.Round(Program.random.NextDouble() * (1 - 0.5) + 0.5, 1, MidpointRounding.AwayFromZero);
                    v_nu = Program.random.Next(200, 600);
                    w = 2 * pi * (v_nu / 60);
                    v = Math.Round(w * (D / 2), 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"���������� �������� �� ��������� v. ��� ������ ��������� D[{D} �] ������ v_nu[{v_nu} ��/���] �������� � ������.");
                    tasks.WriteLine("���������� v. ����� ����� � �/c.");
                    tasks.WriteLine("v = wR");
                    answers.WriteLine($"�����: {v} �/c.");
                    break;
                case 1:
                    D = Math.Round(Program.random.NextDouble() * (1 - 0.5) + 0.5, 1, MidpointRounding.AwayFromZero);
                    v_nu = Program.random.Next(200, 600);
                    v = Program.random.Next(15, 60);
                    w = Math.Round(v / (D / 2), 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"���������� �������� �� ��������� v[{v} �/c]. ��� ������ ��������� D[{D} �] ������ v_nu[{v_nu} ��/���] �������� � ������.");
                    tasks.WriteLine("���������� w. ����� ����� � ���/�.");
                    tasks.WriteLine("w = v/R");
                    answers.WriteLine($"�����: {w} ���/�");
                    break;
                case 2:
                    v_nu = Program.random.Next(200, 450);
                    v = Program.random.Next(30, 50);
                    w = 2 * pi * (v_nu / 60);
                    D = Math.Round((v / w) / 2, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"���������� �������� �� ��������� v[{v} �/c]. ��� ������ ��������� D ������ v_nu[{v_nu} ��/���] �������� � ������.");
                    tasks.WriteLine("���������� D. ����� ����� � �.");
                    tasks.WriteLine("D = (v / w) / 2");
                    answers.WriteLine($"�����: {D} �");
                    break;
                case 3:
                    D = Math.Round(Program.random.NextDouble() * (1 - 0.7) + 0.7, 1, MidpointRounding.AwayFromZero);
                    v = Program.random.Next(15, 35);
                    w = 2 * pi * (v_nu / 60);
                    v_nu = Math.Round((v / (3.14 * D)) * 60, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"���������� �������� �� ��������� v[{v} �/c]. ��� ������ ��������� D[{D} �] ������ v_nu �������� � ������.");
                    tasks.WriteLine("���������� v_nu. ����� ����� � ��/���.");
                    tasks.WriteLine("v_nu = (v / (3.14 * D)) * 60");
                    answers.WriteLine($"�����: {v_nu} ��/���");
                    break;
            }
        }
    }
    class ElectricalResistivity // �������� ������������� �������������
    {
        private readonly static string topic = "�������� ������������� �������������"; // ���� ������
        public readonly static string folder = $"{Program.mainFolder}\\{topic}"; // �������� ����� � �������� � �������� �� ���
        private readonly static string pathOfTasks = $"{folder}\\������.txt"; // ���� � ���������� ����� � ��������
        private readonly static string pathOfAnswers = $"{folder}\\������.txt"; // ���� � ���������� ����� � ��������

        private readonly StreamWriter tasks = new StreamWriter(pathOfTasks, false); // ������ ������ StreamWriter. ��������� ������ ������� ����� � ��������� ����
        private readonly StreamWriter answers = new StreamWriter(pathOfAnswers, false); // ������ ������ StreamWriter. ��������� ������ ������� �� ������ � ��������� ����

        // ���� ���������� � �������
        private double R;
        private double U;
        private double I;
        private const double p = 0.098;
        private double l;
        private double S;

        public ElectricalResistivity(int numberOfTasks) // ����������� � ������� ����������� ���������� ����� � ����� ��� ������ ������
        {
            tasks.WriteLine("������ ������. ��������� ����� �� �������! �� �������� ��������� ��� �������� � ��!");
            tasks.WriteLine($"����: {topic}.");
            tasks.WriteLine();
            for (int i = 0; i < numberOfTasks; i++)
            {
                Program.counter = i + 1;
                tasks.Write($"{Program.counter})  ");
                answers.Write($"{Program.counter})  ");
                Calculation();
                tasks.WriteLine();
                answers.WriteLine();
            }
            tasks.Close();
            answers.Close();
        }
        private void Calculation() // ������� ����� � ������� �������� ���������� ����������� ���������� � ��� ��� ������������ ������ � ����� � ���
        {
            int rand = Program.random.Next(5); // ��������� ����� ����� � �������� ��� ������������ ����������� ����������
            switch (rand)
            {
                case 0:
                    l = Program.random.Next(8, 15);
                    S = Program.random.Next(2, 4);
                    U = Program.random.Next(8, 20);
                    R = Math.Round((p * l) / S, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"����� �������� ��������� ������ l[{l} �] � �������� S[{S} ��^2] �������� ������������� ��� I c ����������� U[{U} ��].");
                    tasks.WriteLine($"(�������� ������������� ������ - 0,098 ��*��^2/�).");
                    tasks.WriteLine("���������� R. ����� ����� � ��.");
                    tasks.WriteLine("R = (p * l) / S");
                    answers.WriteLine($"�����: {R} ��");
                    break;
                case 1:
                    l = Program.random.Next(8, 15);
                    S = Program.random.Next(2, 4);
                    R = Math.Round((p * l) / S, 3, MidpointRounding.AwayFromZero);
                    I = Program.random.Next(20, 40);
                    U = Math.Round(((I / 1000) * R) * 1000, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"����� �������� ��������� ������ l[{l} �] � �������� S[{S} ��^2] �������� ������������� ��� I[{I} ��] c ����������� U.");
                    tasks.WriteLine($"(�������� ������������� ������ - 0,098 ��*��^2/�).");
                    tasks.WriteLine("���������� U. ����� ����� � ��.");
                    tasks.WriteLine("U = I * R");
                    answers.WriteLine($"�����: {U} ��");
                    break;
                case 2:
                    l = Program.random.Next(8, 15);
                    S = Program.random.Next(2, 4);
                    U = Program.random.Next(8, 20);
                    R = Math.Round((p * l) / S, 3, MidpointRounding.AwayFromZero);
                    I = Math.Round(((U / 1000) / R) * 1000, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"����� �������� ��������� ������ l[{l} �] � �������� S[{S} ��^2] �������� ������������� ��� I c ����������� U[{U} ��].");
                    tasks.WriteLine($"(�������� ������������� ������ - 0,098 ��*��^2/�).");
                    tasks.WriteLine("���������� I. ����� ����� � ��.");
                    tasks.WriteLine("I = U / R");
                    answers.WriteLine($"�����: {I} ��");
                    break;
                case 3:
                    S = Program.random.Next(2, 4);
                    U = Program.random.Next(8, 20);
                    I = Program.random.Next(20, 40);
                    R = Math.Round((U / 1000) / (I / 1000), 3, MidpointRounding.AwayFromZero);
                    l = Math.Round((R * S) / p, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"�� �������� ��������� ������ l � �������� S[{S} ��^2] �������� ������������� ��� I[{I} ��] c ����������� U[{U} ��].");
                    tasks.WriteLine($"(�������� ������������� ������ - 0,098 ��*��^2/�)");
                    tasks.WriteLine("���������� l. ����� ����� � �.");
                    tasks.WriteLine("l = (R * S) / p");
                    answers.WriteLine($"�����: {l} �");
                    break;
                case 4:
                    l = Program.random.Next(8, 15);
                    S = Program.random.Next(2, 4);
                    U = Program.random.Next(8, 20);
                    I = Program.random.Next(20, 40);
                    R = Math.Round((U / 1000) / (I / 1000), 3, MidpointRounding.AwayFromZero);
                    S = Math.Round((p * l) / R, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"�� �������� ��������� ������ l[{l} �] � �������� S �������� ������������� ��� I[{I} ��] c ����������� U[{U} ��].");
                    tasks.WriteLine($"(�������� ������������� ������ - 0,098 ��*��^2/�)");
                    tasks.WriteLine("���������� S. ����� ����� � ��^2.");
                    tasks.WriteLine("S = (p * l) / R");
                    answers.WriteLine($"�����: {S} ��^2");
                    break;
            }
        }
    }
}
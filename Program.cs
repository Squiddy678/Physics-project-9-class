using System.Text;

namespace Physics_project_9_class
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        public static string? mainFolder; // Путь к главной папке
        public readonly static string logFilePath = "..\\..\\..\\Logs.txt"; // Путь к текстовуму файлу с логами
        public static Random random = new Random(); // объект класса Random
        public static int counter = 0; // Используется для нумерации задач
        public static void CreateFolderIfNotExists(string path) // Метод для создания папки 
        {
            try // Обработка исключения FileNotFoundException
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Возникло исключение FileNotFoundException!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Попробуйте выбрать другую папку", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit(); // Выход из приложения
            }
        }
        public static void CreateTextFileOfLogsIfNotExists(string path) // Метод для создания текстового файла с логами 
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close(); // Создает новый текстовый файл для логов и сразу его закрывает во избежании необработанного исключения
            }
        }
            
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1()); // Запуск программы с формы Form1
        }
    }
    class UniformMotion // Равномерное движение 
    {
        private readonly static string topic = "Равномерное движение"; // Тема задачи
        public readonly static string folder = $"{Program.mainFolder}\\{topic}"; // Название папки с задачами и ответами на них
        private readonly static string pathOfTasks = $"{folder}\\Задачи.txt"; // Путь к текстовому файлу с задачами
        private readonly static string pathOfAnswers = $"{folder}\\Ответы.txt"; // Путь к текстовому файлу с ответами

        //StreamWriter streamWriter = File.CreateText(path);
        private readonly StreamWriter tasks = new StreamWriter(pathOfTasks, false); // Объект класса StreamWriter. Реализует запись условий задач в текстовый файл
        private readonly StreamWriter answers = new StreamWriter(pathOfAnswers, false); // Объект класса StreamWriter. Реализует запись ответов на задачи в текстовый файл

        // Поля переменных к задачам
        private double S;
        private double v;
        private double t;

        public UniformMotion(int numberOfTasks) // Конструктор в котором реализуется количество задач и номер для каждой задачи
        {
            tasks.WriteLine("Решите задачу. Округлите ответ до десятых!");
            tasks.WriteLine($"Тема: {topic}");
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
        private void Calculation() // Главный метод в котором рандомно выбирается неизветсная переменная и под нее составляется задача и ответ к ней
        {
            int rand = Program.random.Next(3); // Случайный выбор блока с решением под определенную неизвестную переменную
            switch (rand)
            {
                case 0:
                    v = Program.random.Next(10, 150);
                    t = Program.random.Next(1, 10);
                    S = v * t;
                    tasks.WriteLine($"Автобус проехал равномерно путь S со скроростью v [{v} км/ч] за время t [{t} ч].");
                    tasks.WriteLine($"Определите S. Ответ дайте в км.");
                    tasks.WriteLine("S = vt");
                    answers.WriteLine($"Ответ: {S} км.");
                    break;
                case 1:
                    S = Program.random.Next(10, 200);
                    t = Program.random.Next(1, 10);
                    v = Math.Round(S / t, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"Автобус проехал равномерно путь S [{S} км] со скроростью v за время t [{t} ч].");
                    tasks.WriteLine($"Определите v. Ответ дайте в км/ч.");
                    tasks.WriteLine("v = S / t");
                    answers.WriteLine($"Ответ: {v} км/ч.");
                    break;
                case 2:
                    S = Program.random.Next(10, 200);
                    v = Program.random.Next(10, 150);
                    t = Math.Round(S / v, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"Автобус проехал равномерно путь S [{S} км] со скроростью v [{v} км/ч] за время t.");
                    tasks.WriteLine($"Определите t. Ответ дайте в ч.");
                    tasks.WriteLine("t = S / v");
                    answers.WriteLine($"Ответ: {t} ч.");
                    break;
            }
        }
    }
    class EquidistantMotion // Равноускоренное движение
    {
        private readonly static string topic = "Равноускоренное движение"; // Тема задачи
        public readonly static string folder = $"{Program.mainFolder}\\Равноускоренное движение"; // Название папки с задачами и ответами на них
        private readonly static string pathOfTasks = $"{folder}\\Задачи.txt"; // Путь к текстовому файлу с задачами
        private readonly static string pathOfAnswers = $"{folder}\\Ответы.txt"; // Путь к текстовому файлу с ответами

        private readonly StreamWriter tasks = new StreamWriter(pathOfTasks, false); // Объект класса StreamWriter. Реализует запись условий задач в текстовый файл
        private readonly StreamWriter answers = new StreamWriter(pathOfAnswers, false); // Объект класса StreamWriter. Реализует запись ответов на задачи в текстовый файл

        // Поля переменных к задачам
        private double S;
        private double v0;
        private double a;
        private double t;
        private static double QuadraticEquation(double a, double b, double c) // Метод, решающий квадратное уравнение через дискриминант
        {
            double D = Math.Round((Math.Pow(b, 2) - 4 * a * c), 1, MidpointRounding.AwayFromZero);
            double x1 = Math.Round((-b - Math.Round(Math.Sqrt(D), 1, MidpointRounding.AwayFromZero)) / (2 * a), 1, MidpointRounding.AwayFromZero);
            double x2 = Math.Round((-b + Math.Round(Math.Sqrt(D), 1, MidpointRounding.AwayFromZero)) / (2 * a), 1, MidpointRounding.AwayFromZero); // всегда отрицательное.
            return x1;
        }

        public EquidistantMotion(int numberOfTasks) // Конструктор в котором реализуется количество задач и номер для каждой задачи
        {
            tasks.WriteLine("Решите задачу. Округлите ответ до десятых!");
            tasks.WriteLine($"Тема: {topic}.");
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
        private void Calculation() // Главный метод в котором рандомно выбирается неизветсная переменная и под нее составляется задача и ответ к ней
        {
            int rand = Program.random.Next(4); // Случайный выбор блока с решением под определенную неизвестную переменную
            switch (rand)
            {
                case 0:
                    v0 = Program.random.Next(10, 100);
                    a = Math.Round(Program.random.NextDouble() * (3 - 0.5) + 0.5, 1, MidpointRounding.AwayFromZero);
                    t = Program.random.Next(3, 10);
                    S = v0 * t + a * Math.Pow(t, 2) / 2;
                    tasks.WriteLine($"Автомобиль прошел путь S в течение t [{t} c] с ускорением a [{a} м/с^2], имея начальную скорость v0 [{v0} м/с].");
                    tasks.WriteLine("Определите S. Ответ дайте в м.");
                    tasks.WriteLine("S = v0t + at^2 / 2");
                    answers.WriteLine($"Ответ: {S} м.");
                    break;
                case 1:
                    S = Program.random.Next(80, 200);
                    a = Math.Round(Program.random.NextDouble() * (3 - 0.5) + 0.5, 1, MidpointRounding.AwayFromZero);
                    t = Program.random.Next(3, 10);
                    v0 = Math.Round((S - a * Math.Pow(t, 2) / 2) / t, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"Автомобиль прошел путь S[{S} м] в течение t [{t} c] с ускорением a [{a} м/с^2], имея начальную скорость v0.");
                    tasks.WriteLine($"Определите v0. Ответ дайте в м/с.");
                    tasks.WriteLine("v0 = (S - a * t^2 / 2) / t");
                    answers.WriteLine($"Ответ: {v0} м/с.");
                    break;
                case 2:
                    S = Program.random.Next(80, 200);
                    v0 = Program.random.Next(10, 100);
                    t = Program.random.Next(3, 10);
                    a = Math.Round((S - v0 * t) / (Math.Pow(t, 2) / 2), 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"Автомобиль прошел путь S[{S} м] с ускорением a, имея начальную скорость v0 [{v0} м/с].");
                    tasks.WriteLine($"Определите a. Ответ дайте в м/с^2.");
                    tasks.WriteLine("a = (S - v0 * t) / (t^2 / 2)");
                    answers.WriteLine($"Ответ: {a} м/с^2.");
                    break;
                case 3:
                    S = Program.random.Next(80, 200);
                    v0 = Program.random.Next(10, 100);
                    a = Math.Round(Program.random.NextDouble() * (3 - 0.5) + 0.5, 1, MidpointRounding.AwayFromZero);
                    t = QuadraticEquation(-a / 2, -v0, S);
                    tasks.WriteLine($"Автомобиль прошел путь S[{S} м] в течение t с ускорением a [{a} м/с^2], имея начальную скорость v0 [{v0} м/с].");
                    tasks.WriteLine($"Определите t. Ответ дайте в c.");
                    tasks.WriteLine("t = (-at^2 - v0t + S = 0)");
                    answers.WriteLine($"Ответ: {t} c.");
                    break;
            }
        }
    }
    class UniformCircularMotion // Равномерное движение по окружности
    {
        private readonly static string topic = "Равномерное движение по окружности"; // Тема задачи
        public readonly static string folder = $"{Program.mainFolder}\\{topic}"; // Название папки с задачами и ответами на них
        private readonly static string pathOfTasks = $"{folder}\\Задачи.txt"; // Путь к текстовому файлу с задачами
        private readonly static string pathOfAnswers = $"{folder}\\Ответы.txt"; // Путь к текстовому файлу с ответами

        private readonly StreamWriter tasks = new StreamWriter(pathOfTasks, false); // Объект класса StreamWriter. Реализует запись условий задач в текстовый файл
        private readonly StreamWriter answers = new StreamWriter(pathOfAnswers, false); // Объект класса StreamWriter. Реализует запись ответов на задачи в текстовый файл

        // Поля переменных к задачам
        private double v;
        private double w;
        private double D;
        private double v_nu;
        private const double pi = Math.PI;

        public UniformCircularMotion(int numberOfTasks) // Конструктор в котором реализуется количество задач и номер для каждой задачи
        {
            tasks.WriteLine("Решите задачу. Округлите ответ до десятых! Не забудьте перевести все значения в СИ!");
            tasks.WriteLine($"Тема: {topic}.");
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
        private void Calculation() // Главный метод в котором рандомно выбирается неизветсная переменная и под нее составляется задача и ответ к ней
        {
            int rand = Program.random.Next(4); // Случайный выбор блока с решением под определенную неизвестную переменную
            switch (rand)
            {
                case 0:
                    D = Math.Round(Program.random.NextDouble() * (1 - 0.5) + 0.5, 1, MidpointRounding.AwayFromZero);
                    v_nu = Program.random.Next(200, 600);
                    w = 2 * pi * (v_nu / 60);
                    v = Math.Round(w * (D / 2), 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"Автомобиль движется со скоростью v. Его колеса диаметром D[{D} м] делают v_nu[{v_nu} об/мин] оборотов в минуту.");
                    tasks.WriteLine("Определите v. Ответ дайте в м/c.");
                    tasks.WriteLine("v = wR");
                    answers.WriteLine($"Ответ: {v} м/c.");
                    break;
                case 1:
                    D = Math.Round(Program.random.NextDouble() * (1 - 0.5) + 0.5, 1, MidpointRounding.AwayFromZero);
                    v_nu = Program.random.Next(200, 600);
                    v = Program.random.Next(15, 60);
                    w = Math.Round(v / (D / 2), 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"Автомобиль движется со скоростью v[{v} м/c]. Его колеса диаметром D[{D} м] делают v_nu[{v_nu} об/мин] оборотов в минуту.");
                    tasks.WriteLine("Определите w. Ответ дайте в рад/с.");
                    tasks.WriteLine("w = v/R");
                    answers.WriteLine($"Ответ: {w} рад/с");
                    break;
                case 2:
                    v_nu = Program.random.Next(200, 450);
                    v = Program.random.Next(30, 50);
                    w = 2 * pi * (v_nu / 60);
                    D = Math.Round((v / w) / 2, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"Автомобиль движется со скоростью v[{v} м/c]. Его колеса диаметром D делают v_nu[{v_nu} об/мин] оборотов в минуту.");
                    tasks.WriteLine("Определите D. Ответ дайте в м.");
                    tasks.WriteLine("D = (v / w) / 2");
                    answers.WriteLine($"Ответ: {D} м");
                    break;
                case 3:
                    D = Math.Round(Program.random.NextDouble() * (1 - 0.7) + 0.7, 1, MidpointRounding.AwayFromZero);
                    v = Program.random.Next(15, 35);
                    w = 2 * pi * (v_nu / 60);
                    v_nu = Math.Round((v / (3.14 * D)) * 60, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"Автомобиль движется со скоростью v[{v} м/c]. Его колеса диаметром D[{D} м] делают v_nu оборотов в минуту.");
                    tasks.WriteLine("Определите v_nu. Ответ дайте в об/мин.");
                    tasks.WriteLine("v_nu = (v / (3.14 * D)) * 60");
                    answers.WriteLine($"Ответ: {v_nu} об/мин");
                    break;
            }
        }
    }
    class ElectricalResistivity // Удельное электрическое сопротивление
    {
        private readonly static string topic = "Удельное электрическое сопротивление"; // Тема задачи
        public readonly static string folder = $"{Program.mainFolder}\\{topic}"; // Название папки с задачами и ответами на них
        private readonly static string pathOfTasks = $"{folder}\\Задачи.txt"; // Путь к текстовому файлу с задачами
        private readonly static string pathOfAnswers = $"{folder}\\Ответы.txt"; // Путь к текстовому файлу с ответами

        private readonly StreamWriter tasks = new StreamWriter(pathOfTasks, false); // Объект класса StreamWriter. Реализует запись условий задач в текстовый файл
        private readonly StreamWriter answers = new StreamWriter(pathOfAnswers, false); // Объект класса StreamWriter. Реализует запись ответов на задачи в текстовый файл

        // Поля переменных к задачам
        private double R;
        private double U;
        private double I;
        private const double p = 0.098;
        private double l;
        private double S;

        public ElectricalResistivity(int numberOfTasks) // Конструктор в котором реализуется количество задач и номер для каждой задачи
        {
            tasks.WriteLine("Решите задачу. Округлите ответ до десятых! Не забудьте перевести все значения в СИ!");
            tasks.WriteLine($"Тема: {topic}.");
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
        private void Calculation() // Главный метод в котором рандомно выбирается неизветсная переменная и под нее составляется задача и ответ к ней
        {
            int rand = Program.random.Next(5); // Случайный выбор блока с решением под определенную неизвестную переменную
            switch (rand)
            {
                case 0:
                    l = Program.random.Next(8, 15);
                    S = Program.random.Next(2, 4);
                    U = Program.random.Next(8, 20);
                    R = Math.Round((p * l) / S, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"Через железный проводник длиной l[{l} м] и сечением S[{S} мм^2] проходит электрический ток I c напряжением U[{U} мВ].");
                    tasks.WriteLine($"(Удельное сопротивление железа - 0,098 Ом*мм^2/м).");
                    tasks.WriteLine("Определите R. Ответ дайте в Ом.");
                    tasks.WriteLine("R = (p * l) / S");
                    answers.WriteLine($"Ответ: {R} Ом");
                    break;
                case 1:
                    l = Program.random.Next(8, 15);
                    S = Program.random.Next(2, 4);
                    R = Math.Round((p * l) / S, 3, MidpointRounding.AwayFromZero);
                    I = Program.random.Next(20, 40);
                    U = Math.Round(((I / 1000) * R) * 1000, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"Через железный проводник длиной l[{l} м] и сечением S[{S} мм^2] проходит электрический ток I[{I} мА] c напряжением U.");
                    tasks.WriteLine($"(Удельное сопротивление железа - 0,098 Ом*мм^2/м).");
                    tasks.WriteLine("Определите U. Ответ дайте в мВ.");
                    tasks.WriteLine("U = I * R");
                    answers.WriteLine($"Ответ: {U} мВ");
                    break;
                case 2:
                    l = Program.random.Next(8, 15);
                    S = Program.random.Next(2, 4);
                    U = Program.random.Next(8, 20);
                    R = Math.Round((p * l) / S, 3, MidpointRounding.AwayFromZero);
                    I = Math.Round(((U / 1000) / R) * 1000, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"Через железный проводник длиной l[{l} м] и сечением S[{S} мм^2] проходит электрический ток I c напряжением U[{U} мВ].");
                    tasks.WriteLine($"(Удельное сопротивление железа - 0,098 Ом*мм^2/м).");
                    tasks.WriteLine("Определите I. Ответ дайте в мА.");
                    tasks.WriteLine("I = U / R");
                    answers.WriteLine($"Ответ: {I} мА");
                    break;
                case 3:
                    S = Program.random.Next(2, 4);
                    U = Program.random.Next(8, 20);
                    I = Program.random.Next(20, 40);
                    R = Math.Round((U / 1000) / (I / 1000), 3, MidpointRounding.AwayFromZero);
                    l = Math.Round((R * S) / p, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"На железный проводник длиной l и сечением S[{S} мм^2] проходит электрический ток I[{I} мА] c напряжением U[{U} мВ].");
                    tasks.WriteLine($"(Удельное сопротивление железа - 0,098 Ом*мм^2/м)");
                    tasks.WriteLine("Определите l. Ответ дайте в м.");
                    tasks.WriteLine("l = (R * S) / p");
                    answers.WriteLine($"Ответ: {l} м");
                    break;
                case 4:
                    l = Program.random.Next(8, 15);
                    S = Program.random.Next(2, 4);
                    U = Program.random.Next(8, 20);
                    I = Program.random.Next(20, 40);
                    R = Math.Round((U / 1000) / (I / 1000), 3, MidpointRounding.AwayFromZero);
                    S = Math.Round((p * l) / R, 1, MidpointRounding.AwayFromZero);
                    tasks.WriteLine($"На железный проводник длиной l[{l} м] и сечением S проходит электрический ток I[{I} мА] c напряжением U[{U} мВ].");
                    tasks.WriteLine($"(Удельное сопротивление железа - 0,098 Ом*мм^2/м)");
                    tasks.WriteLine("Определите S. Ответ дайте в мм^2.");
                    tasks.WriteLine("S = (p * l) / R");
                    answers.WriteLine($"Ответ: {S} мм^2");
                    break;
            }
        }
    }
}
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Lab_11_OOP
{
    public class MainClass
    {
        public static void Main()
        {
            string swPath = "D:\\BSTU\\Kurs_2_1\\OOP(C#)\\Lab_11\\testdrive.txt";
            using (StreamWriter sw = new StreamWriter(swPath, false)) { }

            //a
            Reflector.SborkaName(typeof(Student));
            Reflector.SborkaName(typeof(House));
            Reflector.SborkaName(typeof(University));
            Reflector.SborkaName(typeof(int));
            Reflector.SborkaName(typeof(string));
            Reflector.SborkaName(typeof(object));
            //b
            Reflector.IsPublicConstructor(typeof(Student));
            Reflector.IsPublicConstructor(typeof(House));
            Reflector.IsPublicConstructor(typeof(ExamException)); 
            Reflector.IsPublicConstructor(typeof(Exception));
            //c
            Console.WriteLine("|------------------Методы-----------------------|");
            IEnumerable<string> publicMethods = new List<string>();
            publicMethods = Reflector.GetPublicMethods(typeof(House));
            Console.WriteLine("Методы:");
            foreach (string method in publicMethods)
                Console.WriteLine($"{method}");
            //d
            Console.WriteLine("|-----------------Поля и свойства------------------------|");
            Reflector.FieldAndPropertySvoInfo(typeof(House));
            //e
            Console.WriteLine("|-----------------Интерфейсы------------------------|");
            Reflector.GetImplementedInterfaces(typeof(House));
            Reflector.GetImplementedInterfaces(typeof(Person));
            //f
            Console.WriteLine("|-----------------Интерфейсы------------------------|");
            Reflector.MethodWithParametrs(typeof(House), "Int32");
            //g

            House myHouse = new House();
            // получаем метод 
            MethodInfo? tuboMethod = typeof(House).GetMethod("forTestRefl");
            // вызываем метод 
            tuboMethod?.Invoke(myHouse, new object[] { "Hi world", 3 });

            // чтение из файла
            using (FileStream fstream = File.OpenRead("D:\\BSTU\\Kurs_2_1\\OOP(C#)\\Lab_11\\forTask1g.txt"))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                fstream.Read(buffer, 0, buffer.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(buffer);
                string[] prmtrs = textFromFile.Split();
                string fisrtParam = prmtrs[0];
                int secondParam = Convert.ToInt32(prmtrs[2]);
                Console.WriteLine($"Вызов с параметрами из файла");
                tuboMethod?.Invoke(myHouse, new object[] { fisrtParam, secondParam });
            }
            string rndStr = RandomString(6);
            Random rnd = new Random();
            int rndInt = rnd.Next(1, 100);
            Console.WriteLine($"Вызов с случайными параметрами");
            tuboMethod?.Invoke(myHouse, new object[] { rndStr, rndInt });
            //2
            DateTime intus = Reflector.Create<DateTime>(typeof(DateTime), new object[] {2022, 10, 24});
            Console.WriteLine($"DataTime: {intus}");
            Person? personTutboTest1 = Reflector.Create<Person>(typeof(Person), new object[] { "Maks" });
                Console.WriteLine($"Person: {personTutboTest1.Name}");
            Person? personTutboTest2 = Reflector.Create<Person>(typeof(Person), new object[] { 2 });
            int turboInt = Reflector.Create<int>(typeof(int), new object[] { 2 });
            string? turboString = Reflector.Create<string>(typeof(string), new object[] { "45" });



        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        
    }
}
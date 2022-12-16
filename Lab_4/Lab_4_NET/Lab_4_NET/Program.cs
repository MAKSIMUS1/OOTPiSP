using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_4_NET;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_4_NET
{
    internal class MainClass
    {
        static void Main()
        {
            Test test1 = new Test("Проверка знаний на механику", 8);
            test1.Print();

            test1.DoSomething(4);
            ITrial itrialtest = test1;
            itrialtest.DoSomething(5);

            Trial triall = new Test("Проверка знаний на физику", 3);
            triall.Print();
            object person1 = new Test("Проверка знаний на математику", 5);

            Test test123 = new Test("Проверка знаний на английский", 4);
            Trial triallll = test123;
            triallll.Print();//В данном случае переменной triallll, которая представляет тип Trial, присваивается ссылка на объект Test.

            Test test1123 = new Test("Проверка знаний на белодеда", 12);
            ITrial trial1132 = test1123;
            trial1132.Show();

            ITrial itrial575 = new Test("Проверка на что-нибудь", 20);
            Test test575 = itrial575 as Test;
            if (test575 == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                test575.ToString();
            }

            Test test100 = new Test("Проверка на знания труда", 45);
            test100.ToString();
            Exam exam100 = new Exam("Проверка на знания математики", 5, "Математика");
            exam100.ToString();

            Trial[] allClasses = new Trial[4];
            allClasses[0] = new Test("Проверка на знания printer", 56);
            allClasses[1] = new Exam("Экзамен в printer", 8, "Труд");
            allClasses[2] = new FinalExam("Финальный экзамен printer", 10, true, "Физика");
            allClasses[3] = new Question("Вопрос для printer", "2 + 2?", "4", 2);

            Console.WriteLine("-----------------------------------");

            Printer printer = new Printer();
            printer.IAmPrinting(allClasses[0]);
            printer.IAmPrinting(allClasses[1]);
            printer.IAmPrinting(allClasses[2]);
            printer.IAmPrinting(allClasses[3]);
            ////////////////////////////////////////////////////
            ////            5 Lab
            ////////////////////////////////////////////////////
            Console.WriteLine("/--------------------------------------------------------\\");
            Console.WriteLine("|------------------------5 Lab---------------------------|");

            Session.DayTime now = Session.DayTime.Evening;

            Session.PrintMessage(now);                   // Добрый вечер
            Session.PrintMessage(Session.DayTime.Afternoon);    // Добрый день
            Session.PrintMessage(Session.DayTime.Night);        // Доброй ночи
            ////
            Session session = new Session();
            Exam exam145 = new Exam("Проверка на знания", 5, "Математика");
            Exam exam146 = new Exam("Проверка на знания", 7, "Русский");
            Exam exam147 = new Exam("Проверка на знания", 9, "Физика");
            Exam exam148 = new Exam("Проверка на знания", 2, "Математика");
            session.addToSession(exam145);
            session.addToSession(exam146);
            session.addToSession(exam147);
            session.addToSession(exam148);
            session.showSession();
            Controler controler = new Controler();
            Console.WriteLine($"Кол-во нудных экзаменов: {controler.findExam(session, "Математика")}");
            session.deleteSessionExam(exam148);
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            session.showSession();
            vopros vopros = new vopros("Ладно?))))0", 5);
            vopros.Print();
            ////\///////////////////////////////////////////////
            ////            6 Lab
            ////////////////////////////////////////////////////\
            Console.WriteLine("/--------------------------------------------------------\\");
            Console.WriteLine("|------------------------6 Lab---------------------------|");

            // |--------------------Logger----------------------|

            string path = @"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_4\Lab_4_NET\Logger.txt";
            Logger logger = new Logger(path);
            try
            {
                Exam examExp1 = new Exam("Экзамен по физике", 11, "Физика");
                examExp1.Print();
            }
            catch (ExamException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.Value}");
                logger.FileLogger(ex);
            }
            try
            {
                Question questionExp = new Question("Вопрос Белодеда", null, "4", 2);
            }
            catch (QuestionException qu)
            {
                Console.WriteLine($"Ошибка: {qu.Message}");
                logger.FileLogger(qu);
            }
            try
            {
                Question questionExp = new Question("Вопрос Белодеда", "2 + 2", null, 2);
            }
            catch (QuestionException qu)
            {
                Console.WriteLine($"Ошибка: {qu.Message}");
                logger.FileLogger(qu);
            }
            try
            {
                Test testExp1 = new Test("Тест по физике", -1);
            }
            catch (ExamException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.Value}");
                logger.FileLogger(ex);
            }
            /////
            try
            {

                int x = 5;
                int y = x / 0;  // DivideByZeroException
            }
            catch (DivideByZeroException dv)
            {
                Console.WriteLine($"Исключение: {dv.Message}");
                Console.WriteLine($"Source: {dv.Source}");
                Console.WriteLine($"Метод: {dv.TargetSite}");
                Console.WriteLine($"Трассировка стека: {dv.StackTrace}");
                logger.FileLogger(dv);
            }
            try
            {
                int[] numbers = new int[4];
                numbers[7] = 9;     // IndexOutOfRangeException
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                logger.FileLogger(ex);
            }
            try
            {
                object obj = "Beloded";
                int num = (int)obj;     // InvalidCastException
                Console.WriteLine($"Результат: {num}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                logger.FileLogger(ex);
            }
            // Task 3 
            try
            {
                byte b = byte.Parse("401");
            }
            catch
            {
                Console.WriteLine("Возникла непредвиденная ошибка");
            }
            // Task 4
            try
            {
                Square("12"); // Квадрат числа 12: 144
                Square("ab"); // !Исключение

                void Square(string data)
                {
                    int x = int.Parse(data);
                    Console.WriteLine($"Квадрат числа {x}: {x * x}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                logger.FileLogger(ex);
            }
            finally
            {
                Console.WriteLine("Блок finally");
            }
            // Task 5
            try
            {
                Square("ab");
                void Square(string data)
                {
                    int x = int.Parse(data);
                    Console.WriteLine($"Квадрат числа {x}: {x * x}");
                }
            }
            catch (Exception ex) when (
                    ex is FormatException
                    || ex is ArgumentNullException
                    || ex is OverflowException)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                logger.FileLogger(ex);
            }
            //
            static void Method1()
            {
                try
                {
                    Method2();
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Catch в Method1 : {ex.Message}");
                    throw;
                }
                Console.WriteLine("Конец метода Method1");
            }
            static void Method2()
            {
                try
                {
                    int x = 8;
                    int y = x / 0;
                }
                finally
                {
                    Console.WriteLine("Блок finally в Method2");
                }
                Console.WriteLine("Конец метода Method2");
            }

            try
            {
                Method1();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Catch в Main : {ex.Message}");
                logger.FileLogger(ex);
            }
            // Task 7-8
            int index = -40;
            Debug.Assert(index > 0);
            Debugger.Break();



        }
    }
}


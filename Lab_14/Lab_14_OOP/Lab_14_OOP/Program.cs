using Lab_14_OOP;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Threading;

namespace Lab_13_OOP
{
    public class MainClass
    {
        public static void Main()
        {
            string InfoPath = @"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_14\SimpleNumbers.txt";

            using (StreamWriter writerKMO = new StreamWriter(InfoPath, false))
            {

            }
            //1
            foreach (Process process in Process.GetProcesses())
            {
                try
                {
                    Console.WriteLine("|-----------------------------------------------|");
                    Console.WriteLine($"CurrentPriority: {process.BasePriority}\nHandle: {process.Handle}\nID: {process.Id}\nName: {process.ProcessName}\nStart Time: {process.StartTime}");
                    Console.WriteLine("|-----------------------------------------------|");
                }
                catch
                {
                    Console.WriteLine("Отказано в доступе");
                }
            }
            //2
            Console.WriteLine("|-------Domen-------|");
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
            Console.WriteLine();

            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);
            try
            {
                AppDomain newD = AppDomain.CreateDomain("New");
                newD.Load("имя сборки");
                AppDomain.Unload(newD);
            }
            catch
            {
                Console.WriteLine("Устаревшее");
            }
            //Выгрузить сборки из домена нельзя, можно выгрузить весь домен

            Console.WriteLine($"|||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            // 3
            // создаем новый поток
            Thread myThread = new Thread(SimpleNumbers);
            // запускаем поток myThread
            myThread.Start();

            void SimpleNumbers()
            {
                // получаем текущий поток
                Thread currentThread = Thread.CurrentThread;

                Console.WriteLine($"Имя потока: {currentThread.Name}");
                Console.WriteLine($"Запущен ли поток: {currentThread.IsAlive}");
                Console.WriteLine($"Id потока: {currentThread.ManagedThreadId}");
                Console.WriteLine($"Приоритет потока: {currentThread.Priority}");
                Console.WriteLine($"Статус потока: {currentThread.ThreadState}");
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine($"SimpleNumbers Thread: {i}");
                    using (StreamWriter writerKMO = new StreamWriter(InfoPath, true))
                    {
                        writerKMO.WriteLine($"SimpleNumbers Thread: {i}");
                        Thread.Sleep(400);
                    }
                }
            }
            Thread.Sleep(4000);
            Console.WriteLine($"|||||||||||||||||||||||||4|||||||||||||||||||||||||||||");
            int choice = 0;
            Console.Write("Ввод: ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    AutoResetEvent waitHandler = new AutoResetEvent(true);  // объект-событие
                    Thread EvemThread = new Thread(EvenNumbers);
                    Thread OddThread = new Thread(OddNumbers);
                    EvemThread.Start();
                    OddThread.Start();
                    // Четыне
                    void EvenNumbers()
                    {
                        for (int i = 0; i < 25; i++)
                        {
                            waitHandler.WaitOne();  // ожидаем сигнала
                            if (i % 2 == 0)
                                Console.WriteLine($"EvenNumbers поток:\t{i}");
                            Thread.Sleep(100);
                            waitHandler.Set();  //  сигнализируем, что waitHandler в сигнальном состоянии
                        }
                    }
                    // Не четыне
                    void OddNumbers()
                    {
                        for (int i = 0; i < 25; i++)
                        {
                            waitHandler.WaitOne();  // ожидаем сигнала
                            if (i % 2 != 0)
                                Console.WriteLine($"OddNumbers поток:\t{i}");
                            Thread.Sleep(200);
                            waitHandler.Set();  //  сигнализируем, что waitHandler в сигнальном состоянии
                        }
                    }
                    break;
                case 1:
                    object locker = new();  // объект-заглушка
                    Thread OddThread2 = new Thread(OddNumbers2);
                    Thread EvemThread2 = new Thread(EvenNumbers2);
                    Thread OddThread3 = new Thread(OddNumbers2);
                    OddThread3.Start();
                    EvemThread2.Start();
                    EvemThread2.Join();
                    // Четыне
                    void EvenNumbers2()
                    {
                        OddThread2.Start();
                        OddThread2.Join();
                        lock (locker)
                        {
                            for (int i = 0; i < 25; i++)
                            {
                                if (i % 2 == 0)
                                    Console.WriteLine($"EvenNumbers2 поток:\t{i}");
                                Thread.Sleep(100);
                            }
                        }
                    }
                    // Не четыне
                    void OddNumbers2()
                    {
                        lock (locker)
                        {

                            for (int i = 0; i < 25; i++)
                            {
                                if (i % 2 != 0)
                                    Console.WriteLine($"OddNumbers2 поток:\t{i}");
                                Thread.Sleep(200);
                            }
                        }
                    }
                    break;
                case 2:
                    // Timer
                    int num = 0;
                    // устанавливаем метод обратного вызова
                    TimerCallback tm = new TimerCallback(Count);
                    // создаем таймер
                    Timer timer = new Timer(tm, num, 0, 2000);

                    Console.ReadLine();

                    static void Count(object obj)
                    {
                        int x = (int)obj;
                        for (int i = 1; i < 9; i++, x++)
                        {
                            Console.WriteLine($"{x * i}");
                        }
                    }
                    break;
                case 3:
                    // запускаем пять потоков
                    for (int i = 1; i < 6; i++)
                    {
                        Zritel zritel = new Zritel(i);
                    }
                    break;
            }

        }
    }
}
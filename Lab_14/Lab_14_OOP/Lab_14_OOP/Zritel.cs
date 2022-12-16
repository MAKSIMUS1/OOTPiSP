using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_14_OOP
{
    public class Zritel
    {
        // создаем семафор
        static Semaphore sem = new Semaphore(3, 3);
        Thread myThread;
        int count = 3;// счетчик чтения

        public Zritel(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = $"Зритель {i}";
            myThread.Start();
        }

        public void Read()
        {
            while (count > 0)
            {
                sem.WaitOne();  // ожидаем, когда освободиться место

                Console.WriteLine($"{Thread.CurrentThread.Name} подключается к каналу");

                Console.WriteLine($"{Thread.CurrentThread.Name} смотрит");
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} отключается от канала");

                sem.Release();  // освобождаем место

                count--;
                Thread.Sleep(500);
            }
        }
    }
}

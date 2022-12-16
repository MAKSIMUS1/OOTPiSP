using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15_OOP
{
    public class AsyncClass
    {
        public static async void BlockColl()
        {

            int x = 0;
            BlockingCollection<string> blockcoll = new BlockingCollection<string>(5);
            List<string> items = new List<string>() { "Холодильник", "Микроволновка", "Морковка", "Утюг", "Пылесос"};
            Task[] producers = new Task[5]
            {
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(500);
                        blockcoll.Add(items[0]);
                        Console.WriteLine($"Поставщик #1 привез {items[0]}");
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(550);
                        blockcoll.Add(items[1]);
                        Console.WriteLine($"Поставщик #2 привез {items[1]}");
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(600);
                        blockcoll.Add(items[2]);
                        Console.WriteLine($"Поставщик #3 привез {items[2]}");
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(650);
                        blockcoll.Add(items[3]);
                        Console.WriteLine($"Поставщик #4 привез {items[3]}");
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(700);
                        blockcoll.Add(items[4]);
                        Console.WriteLine($"Поставщик #5 привез {items[4]}");
                    }
                })
            };
            foreach (var t in producers)
                t.Start();

            Task[] consumers = new Task[10]
            {
                new Task(() =>
                {
                    while(true)
                    {
                        Console.WriteLine("Покупатель 1 взял: " + blockcoll.Take());
                        Thread.Sleep(150);
                        if(blockcoll.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Покупатель 1 ушёл.");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Console.WriteLine("Покупатель 2 взял: " + blockcoll.Take());
                        Thread.Sleep(50);
                        if(blockcoll.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Покупатель 2 ушёл.");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Console.WriteLine("Покупатель 3 взял: " + blockcoll.Take());
                        Thread.Sleep(200);
                        if(blockcoll.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Покупатель 3 ушёл.");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Console.WriteLine("Покупатель 4 взял: " + blockcoll.Take());
                        Thread.Sleep(225);
                        if(blockcoll.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Покупатель 4 ушёл.");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Console.WriteLine("Покупатель 5 взял: " + blockcoll.Take());
                        Thread.Sleep(87);
                        if(blockcoll.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Покупатель 5 ушёл.");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Console.WriteLine("Покупатель 6 взял: " + blockcoll.Take());
                        Thread.Sleep(150);
                        if(blockcoll.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Покупатель 6 ушёл.");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Console.WriteLine("Покупатель 7 взял: " + blockcoll.Take());
                        Thread.Sleep(135);
                        if(blockcoll.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Покупатель 7 ушёл.");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Console.WriteLine("Покупатель 8 взял: " + blockcoll.Take());
                        Thread.Sleep(110);
                        if(blockcoll.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Покупатель 8 ушёл.");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Console.WriteLine("Покупатель 9 взял: " + blockcoll.Take());
                        Thread.Sleep(65);
                        if(blockcoll.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Покупатель 9 ушёл.");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Console.WriteLine("Покупатель 10 взял: " + blockcoll.Take());
                        Thread.Sleep(100);
                        if(blockcoll.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Покупатель 10 ушёл.");
                            Console.ResetColor();
                            break;
                        }
                    }
                })
            };
            Thread.Sleep(700);
            foreach (var t in consumers)
                t.Start();
            Task.WaitAll(consumers);
        }
        static public async void ReadFromWebAsync()
        {
            var web = new WebClient();
            var text =
            await web.DownloadStringTaskAsync("https://msdn.microsoft.com/ru-ru/");
            Console.WriteLine(text.Length);
        }

    }
}

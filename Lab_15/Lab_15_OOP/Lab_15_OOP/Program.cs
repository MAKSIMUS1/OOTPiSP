using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Numerics;
using System.Threading.Tasks;

namespace Lab_15_OOP
{
    public class Program
    {
        static List<uint> SieveEratosthenes2()
        {
            uint n = 10000;
            List<uint> numbers = new List<uint>();
            for (var i = 2u; i < n; i++)
                numbers.Add(i);

            for (var i = 0; i < numbers.Count; i++)
                for (var j = 2u; j < n; j++)
                    numbers.Remove(numbers[i] * j);

            return numbers;
        }
        public static void Main()
        {
            // 1
            Func<List<uint>> SieveEratosthenes = () =>
            {
                uint n = 10000;
                List<uint> numbers = new List<uint>();
                //заполнение списка числами от 2 до n-1
                for (uint i = 2u; i < n; i++)
                    numbers.Add(i);

                for (int i = 0; i < numbers.Count; i++)
                    for (uint j = 2u; j < n; j++)
                        //удаляем кратные числа из списка
                        numbers.Remove(numbers[i] * j);
                return numbers;
            };

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //---------------------------------------------------------------
            Task<List<uint>> taskEratosthenes = new Task<List<uint>>(SieveEratosthenes);
            Console.WriteLine(taskEratosthenes.Status);
            taskEratosthenes.Start();
            Console.WriteLine(taskEratosthenes.Status);

            Console.WriteLine($"taskEratosthenes Id: {taskEratosthenes.Id}");
            Console.WriteLine($"taskEratosthenes is Completed: {taskEratosthenes.IsCompleted}");
            Console.WriteLine($"taskEratosthenes Status: {taskEratosthenes.Status}");
            taskEratosthenes.Wait();
            //---------------------------------------------------------------
            stopWatch.Stop();
            Console.WriteLine("RunTime " + stopWatch.Elapsed.ToString());


            Console.WriteLine("Простые числа до 10_000 «решето Эратосфена»:");
            Console.WriteLine(string.Join(", ", taskEratosthenes.Result));



            Stopwatch stopWatch2 = new Stopwatch();
            stopWatch2.Start();
            List<uint> primeNumbers2 = SieveEratosthenes2();
            stopWatch2.Stop();
            Console.WriteLine("RunTime " + stopWatch2.Elapsed.ToString());


            Console.WriteLine("Простые числа до 10_000 «решето Эратосфена»:");
            Console.WriteLine(string.Join(", ", primeNumbers2));
            // 2
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task taskWithToken = new Task(() =>
            {
                for (int i = 1; i < 10; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }


                    Console.WriteLine($"Квадрат числа {i} равен {i * i}");
                    Thread.Sleep(200);
                }
            }, token);
            try
            {
                taskWithToken.Start();
                Thread.Sleep(1000);
                cancelTokenSource.Cancel();

                taskWithToken.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Console.WriteLine("Операция прервана");
                    else
                        Console.WriteLine(e.Message);
                }
            }
            finally
            {
                cancelTokenSource.Dispose();
            }
            Console.WriteLine($"Task Status: {taskWithToken.Status}");
            // 3
            int n1 = 3, n2 = 2;
            int Sum(int a, int b) => a + b;
            int Diff(int a, int b) => a - b;
            int Multip(int a, int b) => a * b;
            Task<int>[] tasks1 = new Task<int>[3]
            {
            new Task<int>(() => Sum(n1, n2)),
            new Task<int>(() => Diff(n1, n2)),
            new Task<int>(() => Multip(n1, n2))
            };

            foreach (var t in tasks1)
                t.Start();

            Task.WaitAll(tasks1);

            Task<int> FormulaTask = new Task<int>(() => Formula(tasks1[0].Result, tasks1[1].Result, tasks1[2].Result));
            FormulaTask.Start();
            FormulaTask.Wait();
            Console.WriteLine($"Result = {FormulaTask.Result}");

            int Formula(int a, int b, int c) => a + b + c;
            // 4
            //a
            Task task1ContinueWith = new Task(() => Console.WriteLine($"Current Task: {Task.CurrentId}"));

            // задача продолжения
            Task task2ContinueWith = task1ContinueWith.ContinueWith(t =>
                Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"), TaskContinuationOptions.ExecuteSynchronously);

            Task task3ContinueWith = task2ContinueWith.ContinueWith(t =>
                Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));


            Task task4ContinueWith = task3ContinueWith.ContinueWith(t =>
                Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));
            task1ContinueWith.Start();

            task4ContinueWith.Wait();   
                                        
            //b
            Task<int> what = Task.Run(() => Enumerable.Range(1, 100000)
                .Count(n => (n % 2 == 0)));
            var awaiter = what.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int res = awaiter.GetResult();
                Console.WriteLine($"OnCompleted {res}");
            });
            //5
            int[][] nums = new int[5][];
            nums[0] = new int[1_000_000];
            nums[1] = new int[1_000_000];
            nums[2] = new int[1_000_000];
            nums[3] = new int[1_000_000];
            nums[4] = new int[1_000_000];
            Console.WriteLine("()()()()()()()()()-------------------------");

            Stopwatch stopWatch_Parallel_For = new Stopwatch();
            stopWatch_Parallel_For.Start();
            Parallel.For(0, 5, z =>
            {
                Random rnd = new Random();
                for (int y = 0; y < 1_000_000; y++)
                {
                    nums[z][y] = rnd.Next(0, 100);
                }
            });
            stopWatch_Parallel_For.Stop();
            TimeSpan ts_Parallel_For = stopWatch_Parallel_For.Elapsed;
            string elapsedTime_Parallel_For = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts_Parallel_For.Hours, ts_Parallel_For.Minutes, ts_Parallel_For.Seconds,
                ts_Parallel_For.Milliseconds / 10);
            Console.WriteLine("RunTime Parallel_For" + elapsedTime_Parallel_For);

            int[][] nums2 = new int[5][];
            nums2[0] = new int[1_000_000];
            nums2[1] = new int[1_000_000];
            nums2[2] = new int[1_000_000];
            nums2[3] = new int[1_000_000];
            nums2[4] = new int[1_000_000];

            Stopwatch stopWatch_Usual_For = new Stopwatch();
            stopWatch_Usual_For.Start();
            Random rnd2 = new Random();
            for (int y = 0; y < 1_000_000; y++)
            {
                nums2[0][y] = rnd2.Next(0, 100);
            }
            for (int y = 0; y < 1_000_000; y++)
            {
                nums2[1][y] = rnd2.Next(0, 100);
            }
            for (int y = 0; y < 1_000_000; y++)
            {
                nums2[2][y] = rnd2.Next(0, 100);
            }
            for (int y = 0; y < 1_000_000; y++)
            {
                nums2[3][y] = rnd2.Next(0, 100);
            }
            for (int y = 0; y < 1_000_000; y++)
            {
                nums2[4][y] = rnd2.Next(0, 100);
            }
            stopWatch_Usual_For.Stop();
            TimeSpan ts_Usual_For = stopWatch_Usual_For.Elapsed;
            string elapsedTime_Usual_For = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts_Usual_For.Hours, ts_Usual_For.Minutes, ts_Usual_For.Seconds,
                ts_Usual_For.Milliseconds / 10);
            Console.WriteLine("RunTime Usual_For" + elapsedTime_Usual_For);

            ParallelLoopResult result = Parallel.ForEach<int>(
                new List<int>() { 1, 3, 5, 8, 15 },
                Factorial
            );
            if (!result.IsCompleted)
                Console.WriteLine("Выполнение цикла завершено на итерации {0}", result.LowestBreakIteration);

            void Factorial(int n)
            {
                BigInteger factorial = new BigInteger(1);
                for (int i = 1; i <= n; i++)
                    factorial *= i;

                Console.WriteLine($"Факториал {n}: {factorial}");
            }
            ////6
            //Parallel.Invoke(
            //    () => Console.WriteLine($"Запрос 1. Длина: {new WebClient().DownloadString("https://msdn.microsoft.com/ru-ru/").Length}"),
            //    () => Console.WriteLine($"Запрос 2. Длина: {new WebClient().DownloadString("https://vk.com/maksimus1132").Length}"),
            //    () => Console.WriteLine($"Запрос 3. Длина: {new WebClient().DownloadString("http://www.go.by").Length}")
            //    );
            //7
            AsyncClass.BlockColl();
            // 8
            //AsyncClass.ReadFromWebAsync();
        }

    }
}
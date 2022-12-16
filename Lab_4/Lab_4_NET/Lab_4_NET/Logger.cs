using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_4_NET
{
    internal class Logger
    {
        string loggerPath;
        internal Logger(string path)
        {
            loggerPath = path;
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine("-----Протокол----- \r\nВыполнено: " + DateTime.UtcNow.ToString());
            }
        }
        internal async void FileLogger(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter(loggerPath, true))
            {

                await sw.WriteLineAsync("|----------------------------------------------------|");
                await sw.WriteLineAsync($"Исключение: {ex.Message}");
                await sw.WriteLineAsync($"Source: {ex.Source}");
                await sw.WriteLineAsync($"Метод: {ex.TargetSite}");
                await sw.WriteLineAsync($"Трассировка стека: {ex.StackTrace}");
                await sw.WriteLineAsync("|----------------------------------------------------|");
            }
        }
        internal void ConsoleLogger()
        {
            Console.WriteLine("ConsoleLogger");
        }
    }
}

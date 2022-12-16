using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_OOP
{
    public class KMOFileInfo
    {
        public static void AboutFile(string path)
        {
            KMOLog.LOG("|-------FileInfo-------|");
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Полный путь: {path}");
                Console.WriteLine($"Имя файла: {Path.GetFileNameWithoutExtension(path)}");
                Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Размер: {fileInfo.Length}");
                Console.WriteLine($"Расширение: {fileInfo.Extension}");
                Console.WriteLine($"Полный путь 2: {fileInfo.DirectoryName}");
                Console.WriteLine($"Полный путь 3: {fileInfo.Directory}");

                KMOLog.LOG($"Полный путь: {path}");
                KMOLog.LOG($"Имя файла: {Path.GetFileNameWithoutExtension(path)}");
                KMOLog.LOG($"Время создания: {fileInfo.CreationTime}");
                KMOLog.LOG($"Размер: {fileInfo.Length}");
                KMOLog.LOG($"Расширение: {fileInfo.Extension}");
                KMOLog.LOG($"Полный путь 2: {fileInfo.DirectoryName}");
                KMOLog.LOG($"Полный путь 3: {fileInfo.Directory}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_OOP
{
    public class KMODirInfo
    {
        public static void AboutDir(string dirName)
        {
            KMOLog.LOG("|-------DirInfo-------|");
            DirectoryInfo directory = new DirectoryInfo(dirName);

            if (directory.Exists)
            {
                Console.WriteLine("Подкаталоги:");
                KMOLog.LOG("Подкаталоги:");
                DirectoryInfo[] dirs = directory.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    Console.WriteLine(dir.FullName);
                    KMOLog.LOG(dir.FullName);
                }
                Console.WriteLine($"Количество поддиректориев: {dirs.Length}");
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                KMOLog.LOG($"Количество поддиректориев: {dirs.Length}");
                KMOLog.LOG("\n");
                KMOLog.LOG("Файлы:");
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    Console.WriteLine(file.FullName);
                    KMOLog.LOG(file.FullName);
                }
                Console.WriteLine($"Количество файлов: {files.Length}");
                Console.WriteLine($"Дата создания директория: {Directory.GetCreationTime(dirName)}");
                Console.WriteLine($"Родительский каталог: {Directory.GetParent(dirName)}");
                KMOLog.LOG($"Количество файлов: {files.Length}");
                KMOLog.LOG($"Дата создания директория: {Directory.GetCreationTime(dirName)}");
                KMOLog.LOG($"Родительский каталог: {Directory.GetParent(dirName)}");
            }
        }
    }
}

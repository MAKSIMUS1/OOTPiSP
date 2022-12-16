using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_12_OOP
{
    public class KMOFileManager
    {
        public static void FileManagment()
        {
            string path = @"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12\KMOInspect";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
                dirInfo.Create();

            string dirInfoPath = @"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12\KMOInspect\KMOdirinfo.txt";
            FileInfo KMOdirinfo = new FileInfo(dirInfoPath);

            using (StreamWriter writerKMO = new StreamWriter(dirInfoPath, false))
            {
                string dirName = "D:\\";
                if (Directory.Exists(dirName))
                {
                    writerKMO.WriteLine("Подкаталоги");
                    string[] dirs = Directory.GetDirectories(dirName);
                    foreach (string s in dirs)
                        writerKMO.WriteLine(s);
                    writerKMO.WriteLine();
                    writerKMO.WriteLine("Файлы:");
                    string[] files = Directory.GetFiles(dirName);
                    foreach (string s in files)
                        writerKMO.WriteLine(s);
                }
            }

            string newdirInfoPath = @"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12\KMOInspect\KMOdirinfoCOPY.txt";
            FileInfo fileInf = new FileInfo(dirInfoPath);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newdirInfoPath, true);
            }
            if (KMOdirinfo.Exists)
                KMOdirinfo.Delete();
        }
        public static void XXXFiles(string dirPath, string exten)
        {
            string path = @"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12\KMOFiles";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
                dirInfo.Create();


            DirectoryInfo directory = new DirectoryInfo(dirPath);

            if (directory.Exists)
            {
                Console.WriteLine("Файлы:");
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    if(file.Extension == exten)
                    {
                        file.CopyTo($"{path}\\{file.Name}", true);
                    }
                }
            }
            string newPath = @"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12\KMOInspect\KMOFiles";
            if (dirInfo.Exists && !Directory.Exists(newPath))
            {
                dirInfo.MoveTo(newPath);
            }

        }
        public static void XXXFilesZIP()
        {
            string sourceFolder = @"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12\KMOInspect\KMOFiles"; // исходная папка
            string zipFile = @"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12\KMOInspect\KMOFiles.zip"; // сжатый файл
            string targetFolder = @"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12\Lab_12_OOP"; // папка, куда распаковывается файл
            
            FileInfo zipFileInfo = new FileInfo(zipFile);
            if (!zipFileInfo.Exists)
            {
                try
                {
                    ZipFile.CreateFromDirectory(sourceFolder, zipFile);
                    Console.WriteLine($"Папка {sourceFolder} архивирована в файл {zipFile}");
                    ZipFile.ExtractToDirectory(zipFile, targetFolder);
                }
                catch(Exception ex)
                { 
                    Console.WriteLine($"Message: {ex.Message}"); 
                }
            }

            Console.WriteLine($"Файл {zipFile} распакован в папку {targetFolder}");
        }
    }
}

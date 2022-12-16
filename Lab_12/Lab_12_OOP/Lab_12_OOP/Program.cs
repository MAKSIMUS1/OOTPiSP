using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Lab_12_OOP
{
    public class MainClass
    {
        public static void Main()
        {
            KMODiskInfo.AboutDisk();

            KMOFileInfo.AboutFile("D:\\for_12_oop.txt");
            Console.WriteLine("-------------------------------------");
            KMOFileInfo.AboutFile(@"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_11\testdrive.txt");

            Console.WriteLine("---------------Dir----------------");
            KMODirInfo.AboutDir(@"C:\Program Files");
            Console.WriteLine("-------------------------------------");
            KMODirInfo.AboutDir(@"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12");


            KMOFileManager.FileManagment();
            KMOFileManager.XXXFiles(@"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12\dirWithExtensions", ".txt");
            KMOFileManager.XXXFilesZIP();

            //

            Console.WriteLine("Выберите нужную информацию:\n1 - DiskInfo\n2 - FileInfo\n3 - DirInfo\n4 - Посчитаь кол-во записей");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    using (StreamReader reader = new StreamReader(@"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12\KMOlogfile.txt"))
                    {
                        Console.WriteLine("|-------DiskInfo-------|");
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                            if (line == "|-------DiskInfo-------|")
                            {
                                while (line != "|-------FileInfo-------|")
                                {
                                    line = reader.ReadLine();
                                    Console.WriteLine(line);
                                }
                                break;
                            }
                    }
                    break;
                case 2:
                    using (StreamReader reader = new StreamReader(@"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12\KMOlogfile.txt"))
                    {
                        Console.WriteLine("|-------FileInfo-------|");
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                            if (line == "|-------FileInfo-------|")
                            {
                                while (line != "|-------DirInfo-------|")
                                {
                                    line = reader.ReadLine();
                                    Console.WriteLine(line);
                                }
                                break;
                            }
                    }
                    break;
                case 3:
                    using (StreamReader reader = new StreamReader(@"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12\KMOlogfile.txt"))
                    {
                        Console.WriteLine("|-------DirInfo-------|");
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                            if (line == "|-------DirInfo-------|")
                            {
                                while ((line = reader.ReadLine()) != null)
                                    Console.WriteLine(line);
                                break;
                            }
                    }
                    break;
                case 4:
                    using (StreamReader reader = new StreamReader(@"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12\KMOlogfile.txt"))
                    {
                        string? line;
                        int k = 0;
                        while ((line = reader.ReadLine()) != null)
                            k++;
                        Console.WriteLine($"Количество записей: {k}");
                    }
                    break;
                default:
                    Console.WriteLine("Неверный вариант. До связи");
                    break;
            }
        }
    }
}
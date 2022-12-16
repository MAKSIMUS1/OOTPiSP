using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_OOP
{
    public class KMODiskInfo
    {
        public static void AboutDisk()
        {
            KMOLog.LOG("|-------DiskInfo-------|");
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");

                KMOLog.LOG($"Название: {drive.Name}");
                KMOLog.LOG($"Тип: {drive.DriveType}");

                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка диска: {drive.VolumeLabel}");
                    Console.WriteLine($"Файловой системе : {drive.DriveFormat}");

                    KMOLog.LOG($"Объем диска: {drive.TotalSize}");
                    KMOLog.LOG($"Свободное пространство: {drive.TotalFreeSpace}");
                    KMOLog.LOG($"Метка диска: {drive.VolumeLabel}");
                    KMOLog.LOG($"Файловой системе : {drive.DriveFormat}");
                }
                Console.WriteLine();
            }
        }
    }
}

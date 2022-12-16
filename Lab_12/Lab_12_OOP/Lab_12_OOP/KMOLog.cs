using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_OOP
{
    public class KMOLog
    {

        static string logPath = @"D:\BSTU\Kurs_2_1\OOP(C#)\Lab_12\KMOlogfile.txt";
        static KMOLog()
        {
            using (StreamWriter writerKMO = new StreamWriter(logPath, false))
                writerKMO.WriteLine(DateTime.Now);
        }
        public static void LOG(string str)
        {
            using (StreamWriter writerKMO = new StreamWriter(logPath, true))
                writerKMO.WriteLine(str);
        }
            
    }
}

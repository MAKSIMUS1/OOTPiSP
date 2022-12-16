using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_NET
{
    internal partial class FinalExam
    {

        public override string? ToString()
        {
            Console.WriteLine($"Допуск: {admission}");
            Console.WriteLine($"Оценка: {Grade}");
            return Goal;
        }
    }
}

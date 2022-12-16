using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_NET
{
    internal class ExamException : Exception
    {
        internal int Value { get; set; }
        internal ExamException(string message, int val) : base(message)
        {
            Value = val;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_NET
{
    internal class ExamException : Exception
    {
        internal int Value { get; set; }
        internal ExamException(string message, int val) : base(message)
        {
            Value = val;
        }
    }
    internal class TestException : Exception
    {
        internal int Value { get; set; }
        internal TestException(string message, int val) : base(message)
        {
            Value = val;
        }
    }
    internal class QuestionException : NullReferenceException
    {
        internal QuestionException(string message) : base(message)
        {

        }
    }
}

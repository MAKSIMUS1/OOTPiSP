using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_NET
{
    internal class Printer
    {
        internal void IAmPrinting(Trial trial)
        {
            if(trial is Test test)
            {
                test.ToString();
            }
            if (trial is Exam exam)
            {
                exam.ToString();
            }
            if (trial is FinalExam finalexam)
            {
                finalexam.ToString();
            }
            if(trial is Question question)
            {
                question.ToString();
            }
        }
    }
}

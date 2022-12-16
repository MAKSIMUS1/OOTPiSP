using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_NET
{
    internal partial class FinalExam : Exam
    {
        internal bool admission;
        internal FinalExam(string goal, int number, bool admission, string predmet) : base(goal, number, predmet)
        {
            this.admission = admission;
        }
    }
}

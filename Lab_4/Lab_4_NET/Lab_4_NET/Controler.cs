using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Lab_4_NET
{
    internal class Controler
    {

        internal int findExam(Session session, string predmet)
        {
            int kolvo = 0;
            foreach (Exam exammm in session)
            {
                if (exammm.Predmet == predmet)
                {
                    kolvo++;
                }
            }
            return kolvo;
        }
    }
}

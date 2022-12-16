using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_NET
{
    internal class Session : IEnumerable
    {
        List<Exam> session = new List<Exam>();
        internal List<Exam> Sessions
        {
            get { return session; }
            set { session = value; }
        }

        public IEnumerator GetEnumerator() => session.GetEnumerator();
        internal void addToSession(Exam exam)
        {
            session.Add(exam);
        }
        internal void deleteSessionExam(Exam exam)
        {
            session.Remove(exam);
        }
        internal void showSession()
        {
            foreach (var exammm in session)
            {

                Console.WriteLine("|---------------------------------------|");
                exammm.Print();
                Console.WriteLine("|---------------------------------------|");
            }
        }

        internal static void PrintMessage(DayTime dayTime)
        {
            switch (dayTime)
            {
                case DayTime.Morning:
                    Console.WriteLine("Доброе утро");
                    break;
                case DayTime.Afternoon:
                    Console.WriteLine("Добрый день");
                    break;
                case DayTime.Evening:
                    Console.WriteLine("Добрый вечер");
                    break;
                case DayTime.Night:
                    Console.WriteLine("Доброй ночи");
                    break;
            }
        }
        internal enum DayTime
        {
            Morning,
            Afternoon,
            Evening,
            Night
        }
    }

    struct vopros
    {
        public string? nazv;
        public int? number;
        public vopros(string nazv, int number)
        {
            this.number = number;
            this.nazv = nazv;
        }
        public void Print()
        {
            Console.WriteLine($"Название: {nazv}  Номер: {number}");
        }
    }
}

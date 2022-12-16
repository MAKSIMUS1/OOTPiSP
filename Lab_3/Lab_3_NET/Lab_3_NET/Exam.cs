using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_NET
{
    internal class Exam
    {
        int grade;
        internal int Grade
        {
            get { return grade; }
            set
            {
                if (value < 0 || value > 10)
                    throw new ExamException("Оценка должна быть от 0 до 10", value);
                else
                    grade = value;
                    
            }
        }
        string predmet;
        public string Predmet
        {
            get { return predmet; }
            set { predmet = value; }
        }
        internal Exam(int number, string predmet)
        {
            this.predmet = predmet;
            Grade = number;
        }
        public override string? ToString()
        {
            Console.WriteLine($"Оценка: {grade}");
            return predmet;
        }
    }
    internal class ExamInProcess<T> where T : Exam
    {
        public void ExamGo(T exam)
        {
            Console.WriteLine($"Идёт экзамен по: {exam.Predmet}");
        }
    }
}

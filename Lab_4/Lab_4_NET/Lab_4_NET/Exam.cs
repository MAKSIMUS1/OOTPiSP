using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_NET
{
    internal class Exam : Trial
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

        internal Exam(string goal, int number, string predmet) : base(goal)
        {
            this.predmet = predmet;
            Grade = number;
        }

        internal override bool DoSomething(int value)
        {
            return true;
        }
        internal override void Print()
        {
            Console.WriteLine($"Сложность: {Difficulty}");
            Console.WriteLine($"Оценка: {grade}");
            Console.WriteLine($"Предмет: {predmet}");
        }

        public override string? ToString()
        {
            Console.WriteLine($"Сложность: {Difficulty}");
            Console.WriteLine($"Оценка: {grade}");
            return Goal;
        }
    }
}

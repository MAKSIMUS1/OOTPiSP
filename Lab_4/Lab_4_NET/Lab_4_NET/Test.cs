using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_NET
{
    internal class Test : Trial, ITrial
    {
        int numberOfQuestions;
        internal int NumberOfQuestions
        {
            get { return numberOfQuestions; }
            set
            {
                if (value < 0)
                    throw new ExamException("Минимальное кол-во вопросов: 1", value);
                else
                    numberOfQuestions = value;

            }
        }
        internal Test(string goal, int number) : base(goal)
        {
            NumberOfQuestions = number;
        }
        internal override bool DoSomething(int value)
        {
            Console.WriteLine($"internal override bool DoSomething(int value): {value}");
            return true;
        }
        bool ITrial.DoSomething(int a)
        {
            Console.WriteLine($"bool ITrial.DoSomething(int a): {a}");
            return a == 10;
        }

        void ITrial.Show()
        {
            Console.WriteLine($"Сложность: {Difficulty}");
            Console.WriteLine($"Кол-во вопросов: {numberOfQuestions}");
        }

        internal void Show()
        {
            Console.WriteLine($"Сложность: {Difficulty}");
            Console.WriteLine($"Кол-во вопросов: {numberOfQuestions}");
        }
        internal override void Print()
        {
            Console.WriteLine($"Сложность: {Difficulty}");
            Console.WriteLine($"Кол-во вопросов: {numberOfQuestions}");
        }

        public override string? ToString()
        {
            Console.WriteLine($"Цель: {Goal}\nКол-во вопросов: {numberOfQuestions}");
            return Goal;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab_13_OOP
{
    [Serializable]
    public class Test : Trial
    {
        int numberOfQuestions;
        [JsonIgnore]
        public int NumberOfQuestions
        {
            get { return numberOfQuestions; }
            set { numberOfQuestions = value; }
        }
        public Test(string goal, int number) : base(goal)
        {
            NumberOfQuestions = number;
        }
        public Test() : base()
        {

        }
        public override bool DoSomething(int value)
        {
            Console.WriteLine($"public override bool DoSomething(int value): {value}");
            return true;
        }

        public void Show()
        {
            Console.WriteLine($"Сложность: {Difficulty}");
            Console.WriteLine($"Кол-во вопросов: {numberOfQuestions}");
        }
        public override void Print()
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

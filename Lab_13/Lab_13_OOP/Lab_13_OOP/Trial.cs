using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13_OOP
{
    [Serializable]
    public abstract class Trial
    {
        string? goal;
        public string? Goal
        {
            get { return goal; }
            set { goal = value; }
        }

        int difficulty;
        public int Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }
        public Trial(string goal)
        {
            Goal = goal;
            var random = new Random();
            difficulty = random.Next(1, 100);
        }
        public Trial()
        {

        }

        public abstract bool DoSomething(int number);
        public abstract void Print();

        ////////////////////////////////////////////////////////////
        public override string? ToString()
        {
            Console.WriteLine($"Goal: {Goal}\nDifficulty: {Difficulty}");
            return goal;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Trial trial)
                return difficulty == trial.difficulty;
            return false;
        }
        public override int GetHashCode() => goal.GetHashCode();
    }
}

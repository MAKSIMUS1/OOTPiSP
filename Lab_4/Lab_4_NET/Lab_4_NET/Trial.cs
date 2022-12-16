using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_NET
{
    internal abstract class Trial
    {
        string? goal;
        internal string? Goal 
        {
            get { return goal; }
            set { goal = value; }
        }

        int difficulty;
        internal int Difficulty
        {
            get { return difficulty; }
            set { difficulty = value;  }
        }
        internal Trial(string goal)
        {
            this.goal = goal;
            var random = new Random();
            difficulty = random.Next(1, 100);
        }

        internal abstract bool DoSomething(int number);
        internal abstract void Print();

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


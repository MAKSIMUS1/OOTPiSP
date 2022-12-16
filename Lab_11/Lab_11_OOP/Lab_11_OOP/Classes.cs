using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11_OOP
{
    public class House
    {
        readonly int id;
        int apartmNumber;// Номер квартиры
        public int ApartmNumber
        {
            get { return apartmNumber; }
            set
            {
                if (value < 1)
                    Console.WriteLine("Номер квартиры не может быть отрицательным.");
                apartmNumber = value;
            }
        }
        private double area;
        public double Area
        {
            get { return area; }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Площадь не может быть отрицательной.");
                area = value;
            }
        }
        private int floor;
        public int Floor
        {
            get { return floor; }
            set
            {
                if (value < 1)
                    Console.WriteLine("Этаж не может быть отрицательным");
                floor = value;
            }
        }
        private int numberOfRooms;// Количество комнат
        public int NumberOfRooms
        {
            get { return numberOfRooms; }
            set
            {
                if (value < 1)
                    Console.WriteLine("Количество комнат не может быть отрицательным.");
                else
                    numberOfRooms = value;
            }
        }
        private string? street;
        public string? Street
        {
            get { return street; }
            set { street = value; }
        }
        private string? typeOfBuilding;
        public string? TypeOfBuilding
        {
            get { return typeOfBuilding; }
            set { typeOfBuilding = value; }
        }
        private int serviceLife;// Срок эксплуатации
        public int ServiceLife
        {
            get { return serviceLife; }
            set
            {
                if (value < 1)
                    Console.WriteLine("Срок эксплуатации не может быть отрицательным.");
                serviceLife = value;
            }
        }
        const int standartServiceLife = 85;
        static int numberOfObjects = 0;
        public static void showInfo(House house)
        {
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("|         \t Информация о House       ");
            Console.WriteLine($"| ID: {house.id}");
            Console.WriteLine($"| Номер квартиры: {house.apartmNumber}");
            Console.WriteLine($"| Площадь: {house.area}(m\u00b2)");
            Console.WriteLine($"| Этаж: {house.floor}");
            Console.WriteLine($"| Количество комнат: {house.numberOfRooms}");
            Console.WriteLine($"| Улица: {house.street}");
            Console.WriteLine($"| Тип здания: {house.typeOfBuilding}");
            Console.WriteLine($"| Срок эксплуатации: {house.serviceLife}");
            Console.WriteLine("_________________________________________________");
        }

        public void forTestRefl(string ok, int ladno)
        {
            Console.WriteLine("_________________________________________________");
            Console.WriteLine($"ok(string): {ok}, ladno(int): {ladno}");
            Console.WriteLine("_________________________________________________");
        }
        public House()
        {
            id = 483_647;
            apartmNumber = 302;
            area = 2.5;
            floor = 3;
            numberOfRooms = 1;
            street = "Ул.Бобруйская";
            typeOfBuilding = "Общежитие";
            serviceLife = 100;
            numberOfObjects++;
        }



        public House(int y, double a, int b, string? str)
        {
            Random rnd = new Random();
            id = rnd.Next(100_000, 999_999); ;
            apartmNumber = y;
            area = a;
            floor = y;
            numberOfRooms = b;
            street = str;
            typeOfBuilding = "Неизвестно";
            serviceLife = standartServiceLife;
            numberOfObjects++;
        }


        public House(int apartmNumber = 0, double area = 0, int floor = 0, int numberOfRooms = 0,
            string? street = "Неизвестно", string? typeOfBuilding = "Неизвестно", int serviceLife = standartServiceLife)
        {
            Random rnd = new Random();
            id = rnd.Next(100_000, 999_999);
            this.apartmNumber = apartmNumber;
            this.area = area;
            this.floor = floor;
            this.numberOfRooms = numberOfRooms;
            this.street = street;
            this.typeOfBuilding = typeOfBuilding;
            this.serviceLife = serviceLife;
            numberOfObjects++;
        }


        private House(int b)
        {

        }

        static House()
        {
            Console.WriteLine("Статический конструктор");
        }


    }



    public class Student
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public Student(string name, string company)
        {
            Name = name;
            Company = company;
        }
    }






    public class University
    {
        public string Title { get; set; }
        public string Language { get; set; }

        public University(string title, string language)
        {
            Title = title;
            Language = language;
        }
    }





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
            set { difficulty = value; }
        }
        internal Trial(string goal)
        {
            this.goal = goal;
            var random = new Random();
            difficulty = random.Next(1, 100);
        }


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


        public override string? ToString()
        {
            Console.WriteLine($"Сложность: {Difficulty}");
            Console.WriteLine($"Оценка: {grade}");
            return Goal;
        }
    }
    public class ExamException : Exception
    {
        internal int Value { get; set; }
        internal ExamException(string message, int val) : base(message)
        {
            Value = val;
        }
    }

    public class Person : IEater, IMovable
    {
        public string Name { get; }
        public Person(string name) => Name = name;
        public void Eat() => Console.WriteLine($"{Name} eats");

        public void Move() => Console.WriteLine($"{Name} moves");
    }
    interface IEater
    {
        void Eat();
    }
    interface IMovable
    {
        void Move();
    }
}

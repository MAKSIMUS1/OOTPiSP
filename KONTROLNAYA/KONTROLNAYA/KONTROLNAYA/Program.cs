using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KONTROLNAYA;

namespace KONTR
{

    public class Person
    {
        private string? name;
        public string? Name { get { return name; } set { name = value; } }
        private int age;
        public int Age { get { return age; } set 
            {
                if (value < 0)
                    throw new PersonExeption("Возраст должен быть больше 0", value);
                age = value; 
            } 
        }
        public Person(string? Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public static bool CheckIsAdulthood(int provAge)
        {
            if (provAge >= 18)
                return true;
            return false;
        }
        public override string? ToString()
        {
            Console.WriteLine($"Имя: {Name}\nВозраст: {Age}");
            return null;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Person person)
                return Age == person.Age;
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
    public class MainClass
    {
        static void Main()
        {
            string? str1;
            string? str2;
            str1 = Console.ReadLine();
            str2 = Console.ReadLine();
            str1 = str1.ToLower();
            str2 = str2.ToLower();
            Console.WriteLine($"Строка 1: {str1}\nСтрока 2: {str2}");
            if (str1 == str2)
                Console.WriteLine("Равны");
            else
                Console.WriteLine("Не равны");

            short a_1 = 10;
            int b_1 = a_1;
            long c_1 = b_1;
            long d_1 = a_1;

            double x_2 = 1234.7;
            int a_2 = (int)x_2;
            uint ua_2 = (uint)x_2;

            Person person1 = new Person("Никита", 14);
            Person person2 = new Person("Вова", 25);

            try
            {
                Person person3 = new Person("Вова", -55);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            person1.ToString();
            person2.ToString();

            Console.WriteLine($"Достиг ли совершенолетия: {person1}");

            Square square = new Square();
            ICount square2 = new Square();
            Console.WriteLine(square.CountSides());
            Console.WriteLine(square2.CountSide());

            Person.CheckIsAdulthood(45);
        }
    }
}
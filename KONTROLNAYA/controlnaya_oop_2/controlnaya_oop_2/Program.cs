//Кр по ООП
//3 задания
//Темы:
//
//Обобщенные классы
//Делегаты
//События
//LINQ
//Ограничения
//Исключения
//Коллекции

using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Lab_CONTR2_OOP
{

    public class FirstHashSet<T> where T : struct
    {
        public HashSet<T> turbohashset;
    }
    public class Button
    {
        public void Click(int ok)
        {
            Console.WriteLine($"Нажата кнопка.");
        }
    }
    public class Program
    {
        public delegate void Comp(int x);
        public static event Comp? TurnOnEd;
        public static void Main()
        {
            FirstHashSet<int> megaHashSet = new FirstHashSet<int>();
            megaHashSet.turbohashset = new HashSet<int>();
            _ = megaHashSet.turbohashset.Add(0);
            _ = megaHashSet.turbohashset.Add(2);
            _ = megaHashSet.turbohashset.Add(3);
            _ = megaHashSet.turbohashset.Add(3);

            _ = megaHashSet.turbohashset.Add(4);
            _ = megaHashSet.turbohashset.Add(5);
            _ = megaHashSet.turbohashset.Add(6);
            _ = megaHashSet.turbohashset.Add(8);
            _ = megaHashSet.turbohashset.Add(7);
            _ = megaHashSet.turbohashset.Add(35);
            foreach (int ladno in megaHashSet.turbohashset)
                Console.WriteLine(ladno);

            //LINQ
            IEnumerable<int> nujnauyeZifr = megaHashSet.turbohashset.Where(x => x > 5);

            int sum = 0;
            foreach (int elem in nujnauyeZifr)
                sum += elem;
            Console.WriteLine($"Сумма элементов: {sum}");

            //3
            Button button1 = new Button();
            Button button2 = new Button();
            TurnOnEd += button1.Click;
            TurnOnEd += button2.Click;

            TurnOnEd(1);
        }
    }
}
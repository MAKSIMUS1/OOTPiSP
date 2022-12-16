using System;
using System.Security.Principal;
using static Lab_8_NET.Boss;

namespace Lab_8_NET
{

    public class MainClass
    {
        public delegate void TurnOn(int x);
        public static event TurnOn? TurnOnEd;
        public static void Main()
        {
            Boss boss1 = new(999_999_999, "Микроволновка");
            Boss boss2 = new(220, "Человек");
            Boss boss3 = new(4000, "Танк");
            Boss boss4 = new(1750, "Полутанк");
            Boss boss5 = new(0, "Белодед");


            boss2.upgradeMes += DisplayMessage;
            boss2.LevelUp(40);
            boss2.LevelDown(10);
            boss2.LevelDown(1000);
            boss5.LevelUp(25);
            boss2.LevelUp(220);


            TurnOnEd += boss1.ElectricShock;
            TurnOnEd += boss2.ElectricShock;
            TurnOnEd += boss3.ElectricShock;
            TurnOnEd += boss4.ElectricShock;
            TurnOnEd += boss5.ElectricShock;
            Console.Write("Введите напряение: ");
            int shok = Convert.ToInt32(Console.ReadLine());
            TurnOnEd(shok);

            void DisplayMessage(string message) => Console.WriteLine(message);


            string str1 = "oKK !tESt 1,Q NoW tHi,S SLiTnO";

            Console.WriteLine(str1);
            Func<string, string> convertStr = StringProcessing.RemovingPunctuationMarks;
            str1 = convertStr(str1);
            Console.WriteLine(str1);
            convertStr += StringProcessing.RemovingExtraSpaces;
            str1 = convertStr(str1);
            Console.WriteLine(str1);
            convertStr += StringProcessing.ReplacingWithLowerLetters;
            str1 = convertStr(str1);
            Console.WriteLine(str1);
            convertStr += StringProcessing.ReplacingWithCapitalLetters;
            str1 = convertStr(str1);
            Console.WriteLine(str1);

            Predicate<string> provQ = StringProcessing.IfStringHasQ;
            Console.WriteLine($"В строке есть \'Q\': {provQ(str1)}");

        }
    }
}
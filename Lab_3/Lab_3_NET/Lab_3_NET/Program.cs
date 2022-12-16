using Lab_3_NET;
using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Xml.Linq;

namespace Lab_3
{
    class MainClass
    {
        static void Main()
        {
            CollectionType<int> collectionInt = new(50);
            collectionInt.add(100);
            collectionInt.add(new int[] { 20, 875, 55, 69});
            collectionInt.show(collectionInt);
            collectionInt.delete(100);
            collectionInt.show(collectionInt);

            CollectionType<string> collectionString = new("Один");
            collectionString.add("Второй");
            collectionString.add(new string[] { "Два", "Три", "Четыре" });
            collectionString.show(collectionString);
            collectionString.delete("Три");
            collectionString.show(collectionString);

            CollectionType<Exam> collectionExam = new(new Exam(7, "Физика"));
            collectionExam.add(new Exam[] { new Exam(2, "Белодед"), new Exam(8, "Русский"), new Exam(9, "Математика") });
            collectionExam.show(collectionExam);
            try
            {
                collectionString.add("Пять");
                collectionInt.add(-5);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Обработка закончена");
            }
            collectionInt.SaveToFile(collectionInt);
            CollectionType<string> collectionString2 = new("2");
            Console.WriteLine("|-------------------------------|");
            collectionString2.ReadFromFile(collectionString2);
            collectionString2.show(collectionString2);
            ExamInProcess<Exam> examInProcces = new();
            examInProcces.ExamGo(collectionExam[1]);
        }
    }
}
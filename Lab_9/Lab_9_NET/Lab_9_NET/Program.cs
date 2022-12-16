using Lab_9_NET;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab_8_NET
{

    public class MainClass
    {
        public static void Main()
        {
            Software software1 = new Software("Прикладное", 30);
            Software software2 = new Software("Прикладное", 25);
            Software software3 = new Software("Прикладное", 40);
            Software software4 = new Software("Системное", 100);
            Software software5 = new Software("Прикладное", 5);

            MyCollection<Software> myCollection = new();
            myCollection.Add(software1);
            myCollection.Add(software2);
            myCollection.Add(software3);
            myCollection.Add(software4);
            myCollection.Add(software5);

            myCollection.Print(0);
            myCollection.Print(1);
            myCollection.Print(2);
            myCollection.Print(3);
            myCollection.Print(4);

            Console.WriteLine($"Кол-во элементов: {myCollection.Count}");

            myCollection.Remove(software2);
            Console.WriteLine($"Кол-во элементов: {myCollection.Count}");

            myCollection.Print(0);
            myCollection.Print(1);
            myCollection.Print(2);
            myCollection.Print(3);
            try
            {
                myCollection.Print(99);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
            // Task 2
            SortedList<int, string> intSortedList = new SortedList<int, string>();
            intSortedList.Add(2, "Белодед");
            intSortedList.Add(999_999, "Микроволновка");
            intSortedList.Add(78, "Помидор");
            intSortedList.Add(16, "Танк");
            Console.WriteLine($"IndexOfKey(6): {intSortedList.IndexOfKey(6)}");
            Console.WriteLine($"IndexOfKey(16): {intSortedList.IndexOfKey(78)}");

            Console.Write("Введите ключ для поиска: ");
            int key = Convert.ToInt32(Console.ReadLine());
            if (intSortedList.ContainsKey(key))
            {
                Console.WriteLine("\t-KEY-\t-VALUE-");
                Console.WriteLine($"\t {key}\t {intSortedList[key]}");
            }
            else
            {
                Console.WriteLine("Данных с таким ключом нет.");
            }
            intSortedList.Remove(16);
            intSortedList.RemoveAt(intSortedList.IndexOfKey(78));
            Console.Write("Введите ключ для поиска: ");
            key = Convert.ToInt32(Console.ReadLine());
            if (intSortedList.ContainsKey(key))
            {
                Console.WriteLine("\t-KEY-\t-VALUE-");
                Console.WriteLine($"\t {key}\t {intSortedList[key]}");
            }
            else
            {
                Console.WriteLine("Данных с таким ключом нет.");
            }
            Console.WriteLine($"Кол-во элементов: {intSortedList.Count}");


            List<int> intList = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            intList.Add(88);
            intList.AddRange(new int[] { 48, 66, 79 });
            intList.AddRange(new List<int>(new int[] { 33, 43, 99}));
            intList.Insert(0, 656);
            intList.InsertRange(1, new int[] { 777, 432});  
            intList.InsertRange(5, new List<int>(new int[] { 12, 555 }));
            foreach (int item in intList)
                Console.WriteLine($"|---------- \t{item}");
            Console.WriteLine($"\n|---------- Task3 ----------|");
            // Task 3
            ObservableCollection<Software> softwares = new ObservableCollection<Software>();
            softwares.Add(software1);
            softwares.Add(software2);
            softwares.Add(software3);
            softwares.Add(software4);
            softwares.Add(software5);

            // подписываемся на событие изменения коллекции
            softwares.CollectionChanged += softwares_CollectionChanged;

            softwares.Add(new Software("ПО1ТЕСТ", 45));  // добавляем новый элемент

            softwares.RemoveAt(1);                 // удаляем элемент
            softwares[0] = new Software("ПО2ТЕСТ", 33);   // заменяем элемент
            
            Console.WriteLine("\nСписок ПО:");
            foreach (var software in softwares)
            {
                software.Print();
            }
            // обработчик изменения коллекции
            void softwares_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add: // если добавление
                        if (e.NewItems?[0] is Software newSoftware)
                            Console.WriteLine($"Добавлено новое ПО: \"{newSoftware.TypeOfSoftware}\"");
                        break;
                    case NotifyCollectionChangedAction.Remove: // если удаление
                        if (e.OldItems?[0] is Software oldSoftware)
                            Console.WriteLine($"Удалено ПО: \"{oldSoftware.TypeOfSoftware}\"");
                        break;
                    case NotifyCollectionChangedAction.Replace: // если замена
                        if ((e.NewItems?[0] is Software replacingSoftware) &&
                            (e.OldItems?[0] is Software replacedSoftware))
                            Console.WriteLine($"ПО \"{replacedSoftware.TypeOfSoftware}\" заменено на ПО \"{replacingSoftware.TypeOfSoftware}\"");
                        break;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_NET
{
    public class CollectionType<T> : ICollectionType<T>
    {
        public List<T> elements = new List<T>();
        public CollectionType(T value)
        {
            elements.Add(value);
        }
        public void add(T x)
        {
            if(x is int xInt)
                if (xInt < 0)
                    throw new ExamException("Значение должно быть больше 0", xInt);
            elements.Add(x);
        }
        public void add(T[] arr)
        {
            elements.AddRange(arr);
        }
        public void delete(T x)
        {
            elements.Remove(x);
        }
        public void show(CollectionType<T> collectionType)
        {
            Console.WriteLine("Элементы множества: ");
            foreach (var number in collectionType.elements)
                Console.WriteLine(number);
        }
        public void find(T x)
        {
            throw new NotImplementedException();
        }
        internal void ReadFromFile(CollectionType<T> collectionType)
        {
            using (StreamReader sw = new StreamReader("D:\\BSTU\\Kurs_2_1\\OOP(C#)\\Lab_7\\test.txt"))
            {
                string? line;
                while ((line = sw.ReadLine()) != null)
                {
                    if(line is T t)
                        collectionType.add(t);
                }
            }
        }
        internal void SaveToFile(CollectionType<T> collectionType)
        {
            using (StreamWriter sw = new StreamWriter("D:\\BSTU\\Kurs_2_1\\OOP(C#)\\Lab_7\\test.txt", true))
            {
                foreach (var number in collectionType.elements)
                    sw.WriteLine(number);
            }
        }

        public static bool operator <=(CollectionType<T> CollectionType1, CollectionType<T> CollectionType2)
        {
            return CollectionType1.elements.Count <= CollectionType2.elements.Count;
        }
        public static bool operator >=(CollectionType<T> CollectionType1, CollectionType<T> CollectionType2)
        {
            return CollectionType1.elements.Count >= CollectionType2.elements.Count;
        }
        public static T operator %(CollectionType<T> CollectionType1, int position)
        {
                return CollectionType1.elements[position];
        }
        public static implicit operator int(CollectionType<T> CollectionType)
        {
            return CollectionType.elements.Count;
        }


        public T this[int index]
        {
            get
            {
                return elements[index];
            }
            set
            {
                elements[index] = value;
            }
        }
    }
}

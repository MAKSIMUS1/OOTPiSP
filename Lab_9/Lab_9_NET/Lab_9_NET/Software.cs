using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9_NET
{
    public class Software
    {
        private string? typeOfSoftware;
        public string? TypeOfSoftware { get { return typeOfSoftware; } set { typeOfSoftware = value; } }
        private int price;
        public int Price { get { return price; } set { price = value; } }

        public Software(string TypeOfSoftware, int Price)
        {
            this.TypeOfSoftware = TypeOfSoftware;
            this.Price = Price;
        }
        public Software(string TypeOfSoftware)
        {
            this.TypeOfSoftware = TypeOfSoftware;
            Price = 0;
        }
        public void Print()
        {
            Console.WriteLine($"Тип ПО: {this.TypeOfSoftware}");
            Console.WriteLine($"Цена: {this.Price}");
        }
    }
}

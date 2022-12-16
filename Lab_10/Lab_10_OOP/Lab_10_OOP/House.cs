using System;
using System.Xml.Linq;


namespace Lab_10_OOP
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
    }
}
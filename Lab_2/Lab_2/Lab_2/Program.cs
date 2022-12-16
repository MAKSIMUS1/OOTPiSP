using System;
using System.Xml.Linq;


namespace Lab_2
{
    class House
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
        double area;
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
        int floor;
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
        int numberOfRooms;// Количество комнат
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
        string? street;
        public string? Street
        {
            get { return street; }
            set { street = value; }
        }
        string? typeOfBuilding;
        public string? TypeOfBuilding
        {
            get { return typeOfBuilding; }
            set { typeOfBuilding = value; }
        }
        int serviceLife;// Срок эксплуатации
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
            street = "Ул.Бобруйская, д.25";
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
        public static void calcBuildingAge(int age)
        {
            if (age > 100)
                Console.WriteLine("Нужен ремонт");
            else
                Console.WriteLine("Ремонт не нужен");
        }
        public static void Increment(ref int n)
        {
            n++;
        }
        public static void Sum(int x, int y, out int result)
        {
            result = x + y;
        }

        public override string? ToString()
        {
            if (string.IsNullOrEmpty(typeOfBuilding))
                return base.ToString();
            return typeOfBuilding;
        }
        public override bool Equals(object? obj)
        {
            if (obj is House house) 
                return typeOfBuilding == house.typeOfBuilding;
            return false;
        }
        public override int GetHashCode() => typeOfBuilding.GetHashCode();
    }
    partial class Cottage
    {

    }
    partial class Cottage
    {

    }
    class MainClass
    {
        static void Main()
        {
            //Activator.CreateInstance(typeof(House), true);

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            House kopeyka = new House();
            kopeyka.Area = 4.25;
            House house1 = new House(24, 25.54, 2, 3, "ул.Парковая, д.42", "Квартира", 120);
            House.showInfo(kopeyka);
            House.showInfo(house1);
            House house2 = new House();
            Console.Write("Введите количество комнат: ");
            house2.NumberOfRooms = Convert.ToInt32(Console.ReadLine());
            House.showInfo(house2);
            Console.WriteLine(house1.ToString());
            Console.WriteLine(house1.GetHashCode());

            Console.WriteLine(kopeyka.Equals(house2));
            Console.WriteLine(house1.Equals(house2));


            House[] city = new House[5];
            city[0] = new House(78, 23.4, 7, 2, "Ул.Минская, д.13", "Квартира", 60 );
            city[1] = new House(51, 15.89, 5, 2, "Ул.Новосельская, д.15", "Частный дом", 120);
            city[2] = new House(216, 30, 2, 3, "Ул.Ленинская, д.76", "Частный дом", 135);
            city[3] = new House(93, 29.5, 9, 3, "Ул.Желтовского, д.8", "Квартира");
            city[4] = new House(168, 8.25, 1, 1, "Ул.Военная, д.55", "Общежитие", 110);

            House.showInfo(city[0]);
            House.showInfo(city[1]);
            House.showInfo(city[2]);
            House.showInfo(city[3]);
            House.showInfo(city[4]);
            Console.WriteLine("-----------Задание a-----------------");
            Console.Write("Введите число комнат: ");
            int setNumberOfRooms = Convert.ToInt32(Console.ReadLine());
            int j = 1;
            for (int i = 0; i < city.Length; i++)
                if (city[i].NumberOfRooms == setNumberOfRooms)
                {
                    Console.WriteLine($"{j}){city[i].TypeOfBuilding} по адресу {city[i].Street} имеет заданное число комнат.");
                    j++;
                }
            if (j == 1)
                Console.WriteLine("Нет домов с заданным числом комнат");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("\n\n-----------Задание b-----------------");
            Console.Write("Введите число комнат: ");
            int setNumberOfRooms2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите минимальный этаж: ");
            int minFloor = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите максимальный этаж: ");
            int maxFloor = Convert.ToInt32(Console.ReadLine());
            int j2 = 1;
            for (int i = 0; i < city.Length; i++)
                if ((city[i].NumberOfRooms == setNumberOfRooms) && (city[i].Floor >= minFloor && city[i].Floor <= maxFloor))
                {
                    Console.WriteLine($"{j2}){city[i].TypeOfBuilding} по адресу {city[i].Street} имеет заданное число комнат и {city[i].Floor} этаж.");
                    j2++;
                }
            if (j2 == 1)
                Console.WriteLine("Нет домов заданными условиями.");
            Console.WriteLine("-------------------------------------");


            var anonimHouse = new { id = 777_687, apartmNumber = 34 };
            Console.WriteLine(anonimHouse.id);

            House.calcBuildingAge(kopeyka.ServiceLife);
            int number1 = 12;
            Console.WriteLine($"Число до метода Increment: {number1}");
            House.Increment(ref number1);
            Console.WriteLine($"Число после метода Increment: {number1}");

            int number2;
            House.Sum(10, 15, out number2);
            Console.WriteLine(number2);
        }
    }
}
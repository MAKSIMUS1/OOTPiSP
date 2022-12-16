using System;
using System.Text;

namespace Lab_10_OOP
{
    public class MainClass
    {
        public static void Main()
        {
            // Task 1
            string[] month = {  "January", "February", "March", "April", "May", "June", "July", 
                                "August", "September", "October", "November", "December" };

            Console.WriteLine("|------------- == n -------------|");
            int n = 5;
            IEnumerable<string> selectedMonthByN = from m in month
                                   where m.Length == n
                                   select m;

            foreach (string selMonth in selectedMonthByN)
                Console.WriteLine(selMonth);

            Console.WriteLine("|------------- n >= 4 и сожержит \"u\" -------------|");
            IEnumerable<string> selectedMonthSummerWinter = month.Where(m => m.Length >= 4 && m.ToLower().Contains('u'));
            foreach (string selMonth in selectedMonthSummerWinter)
                Console.WriteLine(selMonth);

            Console.WriteLine("|------------- Winter And Summer -------------|");
            string[] winterAndSummerMonth = { "June", "July", "August", "December", "January", "February" };
            IEnumerable<string> resultMonth = month.Intersect(winterAndSummerMonth);
            foreach (string selMonth in resultMonth)
                Console.WriteLine(selMonth);

            Console.WriteLine("|------------- Alfavit sort -------------|");
            IEnumerable<string> alfavSortMonth = from i in month
                                 orderby i ascending
                                 select i;
            foreach (string selMonth in alfavSortMonth)
                Console.WriteLine(selMonth);

            // Task 2-3

            List<House> houses = new List<House>();
            houses.Add(new House(78, 23.4, 7, 2, "Ул.Минская", "Квартира", 60));          // 1
            houses.Add(new House(51, 15.89, 5, 2, "Ул.Новосельская", "Частный дом", 120));// 2
            houses.Add(new House(216, 30, 2, 3, "Ул.Ленинская", "Частный дом", 135));     // 3
            houses.Add(new House(93, 29.5, 9, 3, "Ул.Желтовского", "Квартира"));          // 4
            houses.Add(new House(168, 8.25, 1, 1, "Ул.Военная", "Общежитие", 120));       // 5
            houses.Add(new House(99, 8.25, 1, 1, "Ул.Бобруйская", "Общежитие", 170));       // 6
            houses.Add(new House(168, 8.25, 1, 2, "Ул.Военная", "Общежитие", 190));       // 7
            houses.Add(new House(168, 8.25, 5, 2, "Ул.Бобруйская", "Общежитие", 122));       // 8
            houses.Add(new House(168, 8.25, 1, 1, "Ул.Белорусская", "Общежитие", 100));       // 9
            houses.Add(new House(168, 8.25, 6, 3, "Ул.Пинская", "Общежитие", 105));       // 10
            houses.Add(new House(168, 8.25, 1, 1, "Ул.Бобруйская", "Общежитие", 115));       // 11
            houses.Add(new House(168, 8.25, 7, 4, "Ул.Новосельская", "Общежитие", 123));       // 12
            houses.Add(new House(168, 8.25, 1, 2, "Ул.Бобруйская", "Общежитие", 117));       // 13
            houses.Add(new House(168, 8.25, 4, 1, "Ул.Военная", "Общежитие", 133));       // 14
            houses.Add(new House(168, 8.25, 3, 2, "Ул.Бобруйская", "Общежитие", 123));       // 15
            houses.Add(new House(168, 8.25, 1, 1, "Ул.Бобруйская", "Общежитие", 123));       // 16
            houses.Add(new House(168, 8.25, 5, 2, "Ул.Бобруйская", "Общежитие", 123));       // 17
            houses.Add(new House(168, 8.25, 6, 1, "Ул.Бобруйская", "Общежитие", 123));       // 18
            houses.Add(new House(168, 8.25, 9, 3, "Ул.Грузинская", "Общежитие", 123));       // 19
            houses.Add(new House(168, 8.25, 11, 2, "Ул.Бобруйская", "Общежитие", 123));       // 20


            Console.WriteLine("|------------- Список квартир, имеющих заданное число комнат -------------|");
            IEnumerable<House> selectedHousesWithRooms = from hs in houses
                                 where hs.NumberOfRooms == 2
                                 select hs;
            foreach (House home in selectedHousesWithRooms)
                House.showInfo(home);

            Console.WriteLine("|------------- Пять первых квартир на заданной улице заданного дома -------------|");

            string streetName = "Ул.Бобруйская";
            IEnumerable<House> fiveFirstHouses = from hs in houses
                                                 where hs.Street == streetName
                                                 select hs;

            IEnumerable<House> fiveFiveLastHouses = fiveFirstHouses.Take(5);


            foreach (House home in fiveFiveLastHouses)
                House.showInfo(home);

            Console.WriteLine("|------------- Количество квартир на определенной улице -------------|");
            int countOfSortHouses = (from kv in houses 
                          where kv.Street == "Ул.Бобруйская" 
                          select kv).Count();
            Console.WriteLine(countOfSortHouses);

            Console.WriteLine("|------------- Список квартир, имеющих заданное число комнат и расположенных на этаже, " +
                "который находится в заданном промежутке -------------|");
            IEnumerable<House> housesWithRoomsAndFloor = houses.Where(hs => hs.NumberOfRooms == 1 && (hs.Floor > 2 && hs.Floor < 9));
            foreach (House home in housesWithRoomsAndFloor)
                House.showInfo(home);


            // Task 4
            IEnumerable<IGrouping<string, House>> unicListLINQ = from uniHome in houses
                                                                 where uniHome.NumberOfRooms > 1 
                                                                 orderby uniHome.Street ascending
                                                                 group uniHome by uniHome.Street;
            
            foreach (var streetHome in unicListLINQ)
            {
                Console.WriteLine(streetHome.Key);
                foreach (var Home in streetHome)
                    Console.WriteLine(Home.NumberOfRooms);
                Console.WriteLine();
            }

            bool allHasMore50Years = houses.All(hs => hs.ServiceLife > 50);
            Console.WriteLine(allHasMore50Years);

            IEnumerable<House> takeGroup = houses.Take(2);
            foreach (House home in takeGroup)
                House.showInfo(home);

            IEnumerable<string> streets = (from hs in houses
                                           select hs.Street).Distinct();
            Console.WriteLine("|------------------------------------------|");
            foreach (string stree in streets)
                Console.WriteLine(stree);
            // Task 5
            Student[] students =
            {
                new Student("Лёха", "БГТУ"), new Student("Саша", "БГУ"),
                new Student("Вася", "БНТУ"), new Student("Ваня", "БГУ"),
            };

            University[] universitys =
            {
                new University("БГУ", "Python"),
                new University("БГТУ", "C#"),
                new University("БНТУ", "Java")
            };
            var employees = from p in students
                            join c in universitys on p.Company equals c.Title
                            select new { Name = p.Name, Company = c.Title, Language = c.Language };

            foreach (var emp in employees)
                Console.WriteLine($"{emp.Name} - {emp.Company} ({emp.Language})");

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

    }
}
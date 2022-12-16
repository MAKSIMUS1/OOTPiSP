using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System;
using System.Text.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace Lab_13_OOP
{
    public class MainClass
    {
        public static void Main()
        {

            // a(Binary)
            Test test = new Test("Тест по физике", 5);

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("test.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, test);

                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("test.bin", FileMode.OpenOrCreate))
            {
                Test newtest = (Test)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Цель: {newtest.Goal} --- Кол-во вопросов: {newtest.NumberOfQuestions}");
            }

            // b(SOAP)
            Test soapTest = new Test("Тест по английскому", 9);
            Test soapTest2 = new Test("Тест по русскому", 15);
            Test[] tests = new Test[] { soapTest, soapTest2 };

            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fs = new FileStream("soapTest.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fs, tests);

                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("soapTest.soap", FileMode.OpenOrCreate))
            {
                try
                {
                    Test[] soapNewTests = (Test[])soapFormatter.Deserialize(fs);


                    Console.WriteLine("Объект десериализован");
                    foreach (Test p in soapNewTests)
                    {
                        Console.WriteLine($"Цель: {p.Goal} --- Кол-во вопросов: {p.NumberOfQuestions}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Message: {ex.Message}");
                }
            }

            // c(JSON)
            Test JSON_Test = new("Test po matematike", 17);
            string json = JsonSerializer.Serialize(JSON_Test);
            Console.WriteLine(json);
            Test? restoredTest = JsonSerializer.Deserialize<Test>(json);
            Console.WriteLine(restoredTest?.Goal);


            // d(XML)
            Test XML_test = new Test("Test KSiS", 55);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Test));

            using (FileStream fs = new FileStream("XML_test.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, XML_test);

                Console.WriteLine("Object has been serialized");
            }
            using (FileStream fs = new FileStream("XML_test.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    Test? XML_des_test = xmlSerializer.Deserialize(fs) as Test;
                    Console.WriteLine($"Goal: {XML_des_test?.Goal}  NubmerOFQuestions: {XML_des_test?.NumberOfQuestions}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Message: {ex.Message}");
                }
            }

            Test testForCustom = new Test("Test for Custom", 43);

            CustomSerializer.AllSerializer<Test>(testForCustom);

            // 3
            Test[] testsForSelect = new Test[]
            {
                new Test("Тест по русскому", 24),
                new Test("Тест по английскому", 48),
                new Test("Тест по физике", 21),
                new Test("Тест по математике", 78),
                new Test("Тест по Белодеду", 99),
                new Test("Тест по Пацей", 41),
            };

            XmlSerializer formatterForSelect = new XmlSerializer(typeof(Test[]));
            using (FileStream fs = new FileStream("testForSelect.xml", FileMode.OpenOrCreate))
            {
                formatterForSelect.Serialize(fs, testsForSelect);
            }
            using (FileStream fs = new FileStream("testForSelect.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    Test[]? newpeople = formatterForSelect.Deserialize(fs) as Test[];
                    if (newpeople != null)
                    {
                        foreach (Test person in newpeople)
                        {
                            person.ToString();
                        }
                    }
                }
                catch { Console.WriteLine(""); }
            }
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load("testForSelect.xml");
            }
            catch { Console.WriteLine("Ошибка загрузки"); }
            XmlElement? xRoot = xDoc.DocumentElement;

            XmlNodeList? nodes = xRoot?.SelectNodes("*");
            if (nodes is not null)
            {
                foreach (XmlNode node in nodes)
                    Console.WriteLine(node.OuterXml);
            }
            XmlDocument xDoc2 = new XmlDocument();
            try
            {
                xDoc2.Load("testForSelect.xml");
            }
            catch { Console.WriteLine("Ошибка загрузки"); }
            XmlElement? xRoot2 = xDoc2.DocumentElement;

            XmlNodeList? nodes2 = xRoot2?.SelectNodes("//Goal");
            if (nodes is not null)
            {
                foreach (XmlNode node2 in nodes2)
                    Console.WriteLine(node2.OuterXml);
            }
            // 4 
            XDocument xdoc = new XDocument();
            XElement beloded = new XElement("Prepod");
            XAttribute belodedNameAttr = new XAttribute("name", "Beloded");
            XElement belodedUniversityElem = new XElement("university", "BSTU");
            XElement belodedAgeElem = new XElement("age", 999);
            beloded.Add(belodedNameAttr);
            beloded.Add(belodedUniversityElem);
            beloded.Add(belodedAgeElem);

            XElement shiman = new XElement("Prepod");
            XAttribute shimanNameAttr = new XAttribute("name", "Shiman");
            XElement shimanUniversityElem = new XElement("university", "BSTU");
            XElement shimanAgeElem = new XElement("age", 35);
            shiman.Add(shimanNameAttr);
            shiman.Add(shimanUniversityElem);
            shiman.Add(shimanAgeElem);
            XElement people = new XElement("people");
            people.Add(beloded);
            people.Add(shiman);
            xdoc.Add(people);
            xdoc.Save("belodedAndShiman.xml");

            Console.WriteLine("Data saved");

            Console.WriteLine("\n\n");
            XDocument xdocLINQ = XDocument.Load("belodedAndShiman.xml");
            XElement? prepods = xdocLINQ.Element("people");
            if (prepods is not null)
            {

                foreach (XElement prepod in prepods.Elements("Prepod"))
                {
                    XAttribute? name = prepod.Attribute("name");
                    XElement? university = prepod.Element("university");
                    XElement? age = prepod.Element("age");

                    Console.WriteLine($"Prepod: {name?.Value}");
                    Console.WriteLine($"Company: {university?.Value}");
                    Console.WriteLine($"Age: {age?.Value}");

                    Console.WriteLine();
                }
            }
        }
    }
}
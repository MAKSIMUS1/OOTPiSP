using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_13_OOP
{
    public static class CustomSerializer
    {
        public static void AllSerializer<T>(object? obj)
        {
            Console.WriteLine("|----------CustomSerializer----------|");
            // Binary
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("CustomSerializertest.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
                Console.WriteLine("Объект сериализован в CustomSerializer");
            }
            using (FileStream fs = new FileStream("CustomSerializertest.bin", FileMode.OpenOrCreate))
            {
                T newtest = (T)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован в CustomSerializer");
                newtest.ToString();
            }

            // SOAP
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fs = new FileStream("CustomSerializersoapTest.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fs, obj);
                Console.WriteLine("Объект сериализован в CustomSerializer");
            }
            using (FileStream fs = new FileStream("CustomSerializersoapTest.soap", FileMode.OpenOrCreate))
            {
                try
                {
                    T soapNewTests = (T)soapFormatter.Deserialize(fs);

                    Console.WriteLine("Объект десериализован в CustomSerializer");
                    soapNewTests.ToString();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Message: {ex.Message}");
                }
            }

            // JSON
            string json = JsonSerializer.Serialize(obj);
            Console.WriteLine(json);
            T? restoredTest = JsonSerializer.Deserialize<T>(json);
            restoredTest.ToString();

            // XML
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream("CustomSerializerXML_test.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, obj);
                Console.WriteLine("Object has been serialized in CustomSerializer");
            }
            using (FileStream fs = new FileStream("CustomSerializerXML_test.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    Test? XML_des_test = xmlSerializer.Deserialize(fs) as Test;
                    XML_des_test.ToString();
                }
                catch { }
            }

            Console.WriteLine("|------------------------------------|");
        }
    }
}

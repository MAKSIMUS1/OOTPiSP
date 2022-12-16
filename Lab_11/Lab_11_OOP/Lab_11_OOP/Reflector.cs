using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11_OOP
{
    public static class Reflector
    {
        //
        private static string swPath = "D:\\BSTU\\Kurs_2_1\\OOP(C#)\\Lab_11\\testdrive.txt";
        public static void SborkaName(Type typus)
        {
            Console.WriteLine($"{typus.Assembly}");
            using (StreamWriter sw = new StreamWriter(swPath, true))
            {
                sw.WriteLine($"{typus.Assembly}");
            }
        }
        //b
        public static void IsPublicConstructor(Type typus)
        {
            Console.WriteLine("Конструкторы:");
            foreach (ConstructorInfo ctor in typus.GetConstructors(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                string modificator = "";

                if (ctor.IsPublic)
                    modificator += "public";
                else if (ctor.IsPrivate)
                    modificator += "private";
                else if (ctor.IsAssembly)
                    modificator += "internal";
                else if (ctor.IsFamily)
                    modificator += "protected";
                else if (ctor.IsFamilyAndAssembly)
                    modificator += "private protected";
                else if (ctor.IsFamilyOrAssembly)
                    modificator += "protected internal";

                Console.Write($"{modificator} {typus.Name}(");

                using (StreamWriter sw = new StreamWriter(swPath, true))
                {
                    sw.Write($"{modificator} {typus.Name}(");

                    ParameterInfo[] parameters = ctor.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        var param = parameters[i];
                        sw.Write($"{param.ParameterType.Name} {param.Name}");
                        Console.Write($"{param.ParameterType.Name} {param.Name}");
                        if (i < parameters.Length - 1)
                        {
                            sw.Write(", ");
                            Console.Write(", ");
                        }
                    }
                    Console.WriteLine(")");
                }
            }
        }
        //c
        public static IEnumerable<string> GetPublicMethods(Type typus)
        {
            List<string> methods = new List<string>();
            foreach (MethodInfo method in typus.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static))
            {
                using (StreamWriter sw = new StreamWriter(swPath, true))
                    sw.WriteLine($"{method}");
                methods.Add(method.ReturnType.Name + " " + method.Name);
            }
            return methods;
        }
        //d
        public static IEnumerable<string> FieldAndPropertySvoInfo(Type typus)
        {
            using (StreamWriter sw = new StreamWriter(swPath, true))
                sw.WriteLine("Поля:");
            Console.WriteLine("Поля:");
            foreach (FieldInfo field in typus.GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                string modificator = "";

                if (field.IsPublic)
                    modificator += "public ";
                else if (field.IsPrivate)
                    modificator += "private ";
                else if (field.IsAssembly)
                    modificator += "internal ";
                else if (field.IsFamily)
                    modificator += "protected ";
                else if (field.IsFamilyAndAssembly)
                    modificator += "private protected ";
                else if (field.IsFamilyOrAssembly)
                    modificator += "protected internal ";

                if (field.IsStatic) modificator += "static ";

                using (StreamWriter sw = new StreamWriter(swPath, true))
                    sw.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
                Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
            }
            Console.WriteLine("Свойства:");
            using (StreamWriter sw = new StreamWriter(swPath, true))
                sw.WriteLine("Свойства:");
            foreach (PropertyInfo prop in typus.GetProperties(
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                using (StreamWriter sw = new StreamWriter(swPath, true))
                    sw.Write($"{prop.PropertyType} {prop.Name} {{");
                Console.Write($"{prop.PropertyType} {prop.Name} {{");

                if (prop.CanRead)
                {
                    Console.Write("get;");
                    using (StreamWriter sw = new StreamWriter(swPath, true))
                        sw.Write("get;");
                }
                if (prop.CanWrite)
                { 
                    Console.Write("set;");
                    using (StreamWriter sw = new StreamWriter(swPath, true))
                        sw.Write("set;");
                }
                using (StreamWriter sw = new StreamWriter(swPath, true))
                    sw.WriteLine("}");
                Console.WriteLine("}");
            }
            return new List<string>();
        }
        //e
        public static IEnumerable<string> GetImplementedInterfaces(Type typus)
        {
            Console.WriteLine("Реализованные интерфейсы:");
            foreach (Type i in typus.GetInterfaces())
            {
                using (StreamWriter sw = new StreamWriter(swPath, true))
                    sw.WriteLine(i.Name);
                Console.WriteLine(i.Name);
            }
            return new List<string>();
        }

        //f
        public static void MethodWithParametrs(Type typus, string parametr_name)
        {
            foreach (MethodInfo method in typus.GetMethods())
            {
                ParameterInfo[] parameters = method.GetParameters();
                bool prov = false;
                for (int i = 0; i < parameters.Length; i++)
                    if (parameters[i].ParameterType.Name == parametr_name)
                        prov = true;
                if (prov)
                {
                    using (StreamWriter sw = new StreamWriter(swPath, true))
                        sw.Write($"{method.ReturnType.Name} {method.Name} (");
                    Console.Write($"{method.ReturnType.Name} {method.Name} (");
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        ParameterInfo param = parameters[i];
                        string modificator = "";
                        if (param.IsIn) modificator = "in";
                        else if (param.IsOut) modificator = "out";

                        using (StreamWriter sw = new StreamWriter(swPath, true))
                            sw.Write($"{param.ParameterType.Name} {modificator} {param.Name}");
                        Console.Write($"{param.ParameterType.Name} {modificator} {param.Name}");
                        if (param.HasDefaultValue)
                        {
                            using (StreamWriter sw = new StreamWriter(swPath, true))
                                sw.Write($"={param.DefaultValue}");
                            Console.Write($"={param.DefaultValue}");
                        }
                        if (i < parameters.Length - 1)
                        {
                            using (StreamWriter sw = new StreamWriter(swPath, true))
                                sw.Write(", ");
                            Console.Write(", ");
                        }
                    }
                    using (StreamWriter sw = new StreamWriter(swPath, true))
                        sw.WriteLine(")");
                    Console.WriteLine(")");
                }
            }
        }
        //2

        public static T? Create<T>(Type typus, object[] argsv)
        {
            try
            {
                object? obj = Activator.CreateInstance(typus, 0, null, argsv, null);
                return (T?)obj;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default(T);
        }
    }
}

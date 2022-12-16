using System.Text;

class Lab1
{
    static void Main()
    {
      
        // Types
        Console.Write("string: ");
        string? string_value = Console.ReadLine(); //Знак вопроса ? указывает, что переменная также может хранить значение null, то есть по сути не иметь никакого значения.

        Console.Write("int: ");
        int int_value = Convert.ToInt32(Console.ReadLine());

        Console.Write("double: ");
        double double_value = Convert.ToDouble(Console.ReadLine());

        Console.Write("decimal: ");
        decimal decimal_value = Convert.ToDecimal(Console.ReadLine());

        Console.Write("bool: ");
        bool bool_value = Convert.ToBoolean(Console.ReadLine());

        Console.Write("byte: ");
        byte byte_value = Convert.ToByte(Console.ReadLine());

        Console.Write("sbyte: ");
        sbyte sbyte_value = Convert.ToSByte(Console.ReadLine());

        Console.Write("float: ");
        float float_value = Convert.ToSingle(Console.ReadLine());

        Console.Write("uint: ");
        uint uint_value = Convert.ToUInt32(Console.ReadLine());

        Console.Write("nint: ");
        nint nint_value = Convert.ToSByte(Console.ReadLine());

        Console.Write("long: ");
        long long_value = Convert.ToInt64(Console.ReadLine());

        Console.Write("ulong: ");
        ulong ulong_value = Convert.ToUInt64(Console.ReadLine());

        Console.Write("short: ");
        short short_value = Convert.ToInt16(Console.ReadLine());

        Console.Write("ushort: ");
        ushort ushort_value = Convert.ToUInt16(Console.ReadLine());

        Console.Write("char: ");
        char char_value = Convert.ToChar(Console.Read());
        Console.WriteLine("\n----------------------------------------------------------------------------\n");
        Console.WriteLine($"string: {string_value}\nint: {int_value}\ndouble: {double_value}\ndecimal: {decimal_value}\n" +
            $"bool: {bool_value}\nbyte: {byte_value}\nsbyte: {sbyte_value}\nfloat: {float_value}\nuint: {uint_value}" +
            $"nint: {nint_value}\nlong: {long_value}\nulong: {ulong_value}\nshort: {short_value}\nushort: {ushort_value}\nchar: {char_value}");

        short a_1 = 10;
        int b_1 = a_1;
        long c_1 = b_1;
        long d_1 = a_1;
        float e_1 = 123.4f;
        double f_1 = e_1;

        double x_2 = 1234.7;
        int a_2 = (int)x_2;
        uint ua_2 = (uint)x_2;
        short b_2 = (short)x_2;
        ushort ub_2 = (ushort)x_2;
        long c_2 = (long)x_2;

        // c
        int ii = 123;
        object o = ii;
        Console.ReadLine();
        o = 123;
        ii = (int)o;
        // d
        var i_ = 3;

        // f
        var _value = 9;
        //_value = 2.5;

        //Строки
        string line_1 = "hello";
        string line_2 = "ok";
        Console.WriteLine(String.Compare(line_2, line_1));

        string string1 = "This sentence has five words.";
        string string2 = "this";
        string string3 = string1 + string2;
        Console.WriteLine(string3);

        string s6 = "string_copy";
        string s7 = string.Copy(s6);
        Console.WriteLine(s7);

        string s15 = "hello world";
        string s16 = s15.Substring(6);
        string s17 = s15.Substring(7, 3);
        Console.WriteLine(s16);
        Console.WriteLine(s17);

        string s14 = "Эта строка, которая будет разделена на подстроки с использованием двух разделителей";
        string[] res = s14.Split(new char[] { ' ', ',' });
        foreach (string s in res)
        {
            Console.WriteLine(s);
        }

        string s10 = "Hello ";
        string s11 = s10.Insert(6, "world");
        Console.WriteLine(s11);

        string sentence = "This sentence has five words.";
        string word2 = sentence.Remove(sentence.IndexOf(" "), 9);
        Console.WriteLine("После удаления нужной подстроки: " + word2);


        string s2 = "";
        string s3 = null;

        Console.WriteLine("String s2 {0}.", Test(s2));
        Console.WriteLine("String s3 {0}.", Test(s3));

        String Test(string s)
        {
            if (String.IsNullOrEmpty(s))
                return "is null or empty";
            else
                return String.Format("(\"{0}\") is neither null nor empty", s);
        }


        StringBuilder sb = new StringBuilder("Hello Patzey");
        sb.Remove(3, 1);
        sb.Append("!");
        sb.Insert(0, "insert ");
        // Arrays

        int[,] matrix = { { 1, 2 }, { 3, 4 } };
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }


        string[] string_array = new string[3];
        string_array[0] = "hello1";
        string_array[1] = "hello2";
        string_array[2] = "hello3";
        Console.WriteLine("Длина массива: {0}", string_array.GetLength(0));
        for (int i = 0; i < string_array.GetLength(0); i++)
            Console.WriteLine(string_array[i]);

        double[][] arr = new double[3][] { new double[2], new double[3], new double[4] };
        for (int i = 0; i < arr.Length; i++)
            for (int j = 0; j < arr[i].Length; j++)
            {
                Console.Write($"arr[{i}][{j}] = ");
                arr[i][j] = Convert.ToDouble(Console.ReadLine());
            }
        for (int i = 0; i < arr.Length; i++)
            Console.WriteLine(string.Join(" ", arr[i]));

        //Создайте неявно типизированные переменные для хранения массива и строки
        var array = new int[0];
        var str = "";


        // Кортежи
        (int, string, char, string, ulong) tuple = (32, "Tom", 'f', "Bob", 12345);

        Console.WriteLine(tuple);
        Console.WriteLine(tuple.Item1);
        Console.WriteLine(tuple.Item2);
        Console.WriteLine(tuple.Item3);
        Console.WriteLine(tuple.Item4);

        (string, int, double) QueryCityData = ("City", 64, 12.12);

        (string city1, int population1, double area1) = QueryCityData;

        var (city2, population2, area2) = QueryCityData;

        string city3 = "Raleigh";
        int population3 = 458880;
        double area3 = 144.8;

        (city3, population3, area3) = QueryCityData;


        var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);


        static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
        {
            int population1 = 0, population2 = 0;
            double area = 0;

            if (name == "New York City")
            {
                area = 468.48;
                if (year1 == 1960)
                {
                    population1 = 7781984;
                }
                if (year2 == 2010)
                {
                    population2 = 8175133;
                }
                return (name, area, year1, population1, year2, population2);
            }

            return ("", 0, 0, 0, 0, 0);
        }

        (int a, byte b) left = (5, 10);
        (long a, int b) right = (5, 10);
        Console.WriteLine(left == right);  // output: True
        Console.WriteLine(left != right);  // output: False

        var t1 = (A: 5, B: 10);
        var t2 = (B: 5, A: 10);
        Console.WriteLine(t1 == t2);  // output: True
        Console.WriteLine(t1 != t2);  // output: False

        //////////////////////////////////////////////////////////////////////////// 5  
        ///
        int[] arr_int = new int[] { 1, 5, -8, 23, -700, 17, 442, 15, -1024 };
        string word_for_func = "ertyuiolkjhgf";
        (int, int, int, char) turple_2 = Func(arr_int, word_for_func);
        static (int, int, int, char) Func(int[] arr, string word)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
                if (arr[i] > max)
                    max = arr[i];
                sum += arr[i];
            }
            return (min, max, sum, word[0]);
        }

        Console.WriteLine("min: " + turple_2.Item1);
        Console.WriteLine("max: " + turple_2.Item2);
        Console.WriteLine("sum: " + turple_2.Item3);
        Console.WriteLine("first letter: " + turple_2.Item4);

        //////////////////////////////////////////////////////////////////////////// 6 
        ///

        void check_func()
        {
            try
            {
                checked
                {
                    int check_value = int.MaxValue;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка в checked");
            }
        }
        void uncheck_func()
        {
            try
            {
                unchecked
                {
                    int uncheck_value = int.MaxValue;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка в unchecked");
            }

        }

        Console.WriteLine("Вызов функции с checked: ");
        check_func();
        Console.WriteLine("Вызов функции с unchecked: ");
        uncheck_func();




        Console.WriteLine("остановкуа: ");

    }
}
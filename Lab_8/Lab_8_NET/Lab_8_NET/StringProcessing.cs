using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_NET
{
    public class StringProcessing
    {
        public static string RemovingPunctuationMarks(string str)
        { 
            str = str.Replace(",", "");
            str = str.Replace(".", "");
            str = str.Replace("?", "");
            str = str.Replace("!", "");
            return str;
        }
        public static bool IfStringHasQ(string str)
        {
            for (int i = 0; i < str.Length; i++)
                if (str[i] == 'Q')
                    return true;
            return false;
        }
        public static string ReplacingWithCapitalLetters(string str)
        {
            str = str.ToUpper();
            return str;
        }
        public static string ReplacingWithLowerLetters(string str)
        {
            str = str.ToLower();
            return str;
        }
        public static string RemovingExtraSpaces(string str)
        {
            str = str.Replace(" ", "");
            return str;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONTROLNAYA
{
    public class PersonExeption : Exception
    {
        public int Value { get; set; }
        public PersonExeption(string message, int val) : base(message)
        {
            Value = val;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_19_20_OOP
{
    public interface ITelephoneExchange
    {
        ITelephoneExchange Clone();
        void GetInfo();
    }
}

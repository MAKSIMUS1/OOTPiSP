using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONTROLNAYA
{
    public class Square : Figure, ICount
    {

        bool ICount.CountSide()
        {
            return true;
        }
    }
}

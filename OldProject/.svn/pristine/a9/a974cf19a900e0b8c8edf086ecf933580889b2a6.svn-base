using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeDiesAtTheEnd.ExtentionMethods
{
    public static class ExtentionMethods
    {
        public static int Round(this double dub)
        {
            int result;
            string doubleNumber = dub.ToString();
            string decimalNumber = doubleNumber.Substring(doubleNumber.IndexOf("."), 2);
            double decimalDouble = double.Parse(decimalNumber);
            double math = decimalDouble * 10;
            if (math >= 5) result = (int)(dub) + 1;
            else result=(int)dub;
            return result;
        }
    }
}

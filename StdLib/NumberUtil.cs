using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StdLib
{

        public class NumberUtil
        {
            public static String ConvertToNumberFormat(Object o, string format)
            {
                Decimal d;
                if (Decimal.TryParse(StringUtil.ConvertToString(o), out d))
                {
                    return d.ToString(format);
                }

                return "";
            }
            public static Decimal ConvertToNumber(Object o)
            {
                Decimal d;
                Decimal.TryParse(StringUtil.ConvertToString(o), out d);
                return d;
            }

            public static Decimal ConvertToNumber(String s)
            {
                Decimal d;
                Decimal.TryParse(s, out d);
                return d;
            }

            public static int ConvertToInt(String s)
            {
                int i;

                int.TryParse(s, out i);
                return i;
            }
          
            public static long ConvertToLong(String s)
            {
                long i;
                long.TryParse(s, out i);
                return i;

            }
        }

     
}
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StdLib
{

        public class DateUtil
        {
            public static DateTime? ConverToDatetime(String strDate)
            {
                DateTime d;
                if(DateTime.TryParse(StringUtil.ConvertToString(strDate), out d)) return d;

                return null; 
            }

           
        }

     
}
 

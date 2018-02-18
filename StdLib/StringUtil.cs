using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StdLib
{

        public class StringUtil
        {
            public static bool IsNullOrEmpty(String s)
            {
                return String.IsNullOrEmpty(s);
            }

            public static String Trim(String s)
            {
                if (StringUtil.IsNullOrEmpty(s))
                    return "";

                return s.Trim();
            }
            public static bool ConvertToBoolean(String s)
            {
                if (StringUtil.IsNullOrEmpty(s))
                    return false;

                String v = StringUtil.Trim(s).ToUpper();

                if (v.Equals("Y") || v.Equals("TRUE") || v.Equals("1")) return true;
                else return false;

            }




            public static bool ConvertToBooleanForABAP(String s)
            {
                if (StringUtil.IsNullOrEmpty(s))
                    return false;

                String v = StringUtil.Trim(s).ToUpper();

                if (v.Equals("Y") || v.Equals("TRUE") || v.Equals("1") || v.Equals("X")) return true;
                else return false;

            }
            public static bool ConvertToBoolean(Object o)
            {
                if (o != null)
                {
                    String s = o.ToString();
                    return ConvertToBoolean(s);
                }
                else { return false; }
            }

            public static String ConvertToString(Object o)
            {
                if (o != null)
                {
                    String s = o.ToString();
                    return s;
                }
                else { return ""; }
            }
            public static String RemoveLeadingZero(String s)
            {
                if (s.StartsWith("0"))
                {
                    return RemoveLeadingZero(s.Substring(1));
                }
                else
                {
                    return s;
                }
            }
            public static String ConvertToX(bool o)
            {
                if (o)
                {
                    return "X";
                }
                else { return ""; }
            }
        }

     
}
 

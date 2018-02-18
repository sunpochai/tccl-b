using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StdLib
{
    public class CsvUtil
    {

        
        public  static char GetSplitChar(Constanct.Csv.SPLIT split)
        { 
             if (split==Constanct.Csv.SPLIT.COMMA ) return ',';
             if (split==Constanct.Csv.SPLIT.TAB)  return '\t';
             
            return ','; 
        }
    
    }
      
     
}
 

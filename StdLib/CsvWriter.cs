using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StdLib
{
    public class CsvWriter
    {

     
        public void WriteDataTable2Csv(string dirPath, string csvName, DataTable tb, StdLib.Constanct.Csv.SPLIT split)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow row in tb.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field =>
                  string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(CsvUtil.GetSplitChar(split).ToString(), fields));
            }

            File.WriteAllText(dirPath + csvName, sb.ToString());
        }
    
    }
      
     
}
 

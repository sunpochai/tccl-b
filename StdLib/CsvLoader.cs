using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace StdLib
{
    public class CsvLoader {
        
        // not work with large file
        public  DataTable LoadExcel(string csvFilePathNam,StdLib.Constanct.Csv.SPLIT split)
        {
            string[] Lines = File.ReadAllLines(csvFilePathNam);
            string[] Fields;
            Fields = Lines[0].Split(new char[] { CsvUtil.GetSplitChar(split) });
            int Cols = Fields.GetLength(0);
            DataTable dt = new DataTable(); 
            //1st row must be column names; force lower case to ensure matching later on.
            for (int i = 0; i < Cols; i++)
                dt.Columns.Add(Fields[i].ToLower(), typeof(string));
            DataRow Row;
            for (int i = 1; i < Lines.GetLength(0); i++)
            {
                Fields = Lines[i].Split(new char[] { CsvUtil.GetSplitChar(split) });
                Row = dt.NewRow();
                if (Fields.Length >= Cols) {
                    for (int f = 0; f < Cols; f++)

                        Row[f] = Fields[f];
                    dt.Rows.Add(Row);
                }

            }

            return dt;
        }


    public  void ReadCsv(string csvFilePathNam,StdLib.Constanct.Csv.SPLIT split)
        {
          
            using (var reader = new StreamReader(csvFilePathNam))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    
                }

            }
        }
    }
      
     
}
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Json
{
    public class DataPaging<T>  
    {
        public List<T> data { get; set; }
        public MetaPaging meta { get; set; }
    }

     public class MetaPaging  {
         public int page { get; set; }
         public int pages { get; set; }
         public int perpage { get; set; }
         public int total { get; set; }
         public string sort { get; set; }
         public string field { get; set; }
     }
}
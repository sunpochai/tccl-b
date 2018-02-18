using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendRESTApi.Models
{
    public class user
    {
        public string user_name { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string fullname { get; set; }
    }

   //public class UserInfoViewModel
   // {
   //     public string UserName { get; set; }

   //     public bool HasRegistered { get; set; }

   //     public string LoginProvider { get; set; }
   // }

}
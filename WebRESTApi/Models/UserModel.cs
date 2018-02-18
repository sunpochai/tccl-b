using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRESTApi.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }

   //public class UserInfoViewModel
   // {
   //     public string UserName { get; set; }

   //     public bool HasRegistered { get; set; }

   //     public string LoginProvider { get; set; }
   // }

}
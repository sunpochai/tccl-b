using BackendRESTApi.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
 
namespace BackendRESTApi.Controllers
{

    [AllowAnonymous]  
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {   
        public user Get(string id)
        {

            user user = new user();

            user.email = "user" + "@tcc.co.th";
            user.user_name = "TCC\\User";
            user.fullname = "FullName";
            user.first_name = "FirstName" ;
            user.last_name = "LastName";

            return user;
        }
 

       
         [Route("List")]
        public List<user> List(string search)
        {

            List<user>  usersList = null;
            usersList = new List<user>();

            for (int i = 0; i <= 10; i++) {
                user usr = new user();

                usr.email = "user_" + i.ToString() + "@tcc.co.th";
                usr.user_name = "TCC\\User_" + i.ToString();
                usr.fullname = "FullName_" + i.ToString();
                usr.first_name = "FirstName_" + i.ToString(); ;
                usr.last_name = "LastName_" + i.ToString();
                usersList.Add(usr);
            }
               

            return usersList;
        } 
    }
}

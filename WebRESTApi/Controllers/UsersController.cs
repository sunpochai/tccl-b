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
using WebApi.Models.Json;
using WebRESTApi;
using WebRESTApi.Models;
namespace WebApi.Controllers
{

    [AllowAnonymous]  
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {   
        public UserModel Get(string id)
        {

            UserModel user = new UserModel();

            user.Email = "user" + "@tcc.co.th";
            user.UserName = "TCC\\User";
            user.FullName = "FullName";
            user.FirstName = "FirstName" ;
            user.LastName = "LastName";

            return user;
        }
 

       
         [Route("List")]
        public List<UserModel> List(string search)
        {

            List<UserModel>  usersList = null;
            usersList = new List<UserModel>();

            for (int i = 0; i <= 10; i++) {
                UserModel usr = new UserModel();

                usr.Email = "user_" + i.ToString() + "@tcc.co.th";
                usr.UserName = "TCC\\User_" + i.ToString();
                usr.FullName = "FullName_" + i.ToString();
                usr.FirstName = "FirstName_" + i.ToString(); ;
                usr.LastName = "LastName_" + i.ToString();
                usersList.Add(usr);
            }
               

            return usersList;
        } 
    }
}

using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;

namespace StdLib
{
    public class ActiveDirectory
    { 
        public void showUsers(string pUserName)
        {
            string uid = "tccladmin";
            string pwd = "it@tccladmin$";
            var attributeName = "samaccountname";
            var searchString = "Amornra*";
            var ent = new DirectoryEntry("LDAP://10.4.18.143");
            var mySearcher = new DirectorySearcher(ent);
            mySearcher.Filter = string.Format("(&(objectcategory=user)({0}={1}))", attributeName, searchString);
            mySearcher.SearchScope = SearchScope.Subtree;
            var userResult = mySearcher.FindAll();
            for (int i = 0; i < userResult.Count; i++)
            {
                Console.WriteLine("First Name: " + userResult[i].Properties["givenName"][0]);
                Console.WriteLine("Last Name : " + userResult[i].Properties["sn"][0]);

                Console.WriteLine("SAM account name   : " + userResult[i].Properties["samAccountName"][0]);
                Console.WriteLine("User principal name: " + userResult[0].Properties["userPrincipalName"][0]);
                Console.WriteLine("Mail: " + userResult[i].Properties["mail"][0]);
            }
        }
    }
}

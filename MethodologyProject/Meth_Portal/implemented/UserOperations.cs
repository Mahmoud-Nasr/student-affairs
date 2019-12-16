using Meth_Data.Database;
using Meth_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meth_Portal.implemented
{
   
    public class UserOperations
    {
        private readonly MethProjectEntities context;

        public UserOperations() {
            context = new MethProjectEntities();
        }

        public List<AspNetUser> GetAllUsers (){
            

            return context.AspNetUsers.ToList();

        }
        public List<AspNetRole> GetAllUsersRoles()
        {


            return context.AspNetRoles.ToList();

        }

        public string AddAspUser(AspNetUser user) {

            var result = context.AspNetUsers.Add(user);
            context.SaveChanges();
            return result.Id;

        }



    }
}
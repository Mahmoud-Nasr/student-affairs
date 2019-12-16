using Meth_Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meth_Portal.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string ProfilePic { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> DoctorID { get; set; }

        public int userType { get; set; }

        public List<AspNetRole> Role;
    }
}
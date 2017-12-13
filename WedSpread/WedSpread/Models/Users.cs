using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WedSpread.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int? RoleID { get; set; }

    }
}
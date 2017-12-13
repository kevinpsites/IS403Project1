using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WedSpread.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int? UserID { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        [ForeignKey("Roles")]
        public int? RoleID { get; set; }

    }
}
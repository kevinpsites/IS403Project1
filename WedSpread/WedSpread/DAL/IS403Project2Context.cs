using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WedSpread.Models;
using System.Data.Entity;

namespace WedSpread.DAL
{
    public class IS403Project2Context: DbContext
    {
        public IS403Project2Context(): base("IS403Project2Context")
        {
            
        }
        public DbSet<Users> User { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<Questions> Question { get; set; }
        public DbSet<Freelancers> Freelancer { get; set; }
        public DbSet<Types> Type { get; set; }

    }
}
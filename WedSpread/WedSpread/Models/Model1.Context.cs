﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WedSpread.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IS403Project2Context : DbContext
    {
        public IS403Project2Context()
            : base("name=IS403Project2Context")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Freelancer> Freelancers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}

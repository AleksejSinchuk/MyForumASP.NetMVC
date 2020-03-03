using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebForumMVC.Models
{
    public class DbForumConext:DbContext
    {
       public DbForumConext() : base("ForumDB") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Message> Messages { get; set; }

     
    }
}
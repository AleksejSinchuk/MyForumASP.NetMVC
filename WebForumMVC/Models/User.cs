using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForumMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string HashPass { get; set; }

        public DateTime LastLogin { get; set; }
    }
}
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


        public static IEnumerable<User> GetUserByEmail(string email)
        {
            DbForumConext db = new DbForumConext();
            IEnumerable<User> user = from u in db.Users
                                     where u.Email == email
                                     select u;
            return user;
        }

        public static IEnumerable<User> GetUserById(int id)
        {
            DbForumConext db = new DbForumConext();
            IEnumerable<User> user = from u in db.Users
                                     where u.Id == id
                                     select u;
            return user;
        }

        public static IEnumerable<User> AddUser(User user)
        {
            DbForumConext db = new DbForumConext();
            db.Users.Add(user);
            db.SaveChanges();

            return GetUserByEmail(user.Email);
        }
    }
    
}
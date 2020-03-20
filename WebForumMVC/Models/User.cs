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

        public static User GetUserByEmail2(string email)
        {
            DbForumConext db = new DbForumConext();
            IEnumerable<User> user2 = from u in db.Users
                        where u.Email == email
                        select u ;
            User user = new User();
            if (user2.Count() != 0)
            {
                user = user2.First();
            }
            else {
                user = null;
            } 
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
        public static User GetUserById2(int id)
        {
            DbForumConext db = new DbForumConext();
            IEnumerable<User> user = from u in db.Users
                                     where u.Id == id
                                     select u;
            User user1 = user.First();
            return user1;
        }
        public static List<string> GetLoginById(int id)
        {
            DbForumConext db = new DbForumConext();
            List<string> l = new List<string>();
            IEnumerable<User> user = GetUserById(id);
            foreach (var item in user)
            {
                l.Add(item.Login);
            }
            return l;
        }


        public static IEnumerable<User> AddUser(User user)
        {
            DbForumConext db = new DbForumConext();
            user.HashPass = Util.GetSHA_256(user.HashPass);
            db.Users.Add(user);
            db.SaveChanges();

            return GetUserByEmail(user.Email);
        }
    }
    
}
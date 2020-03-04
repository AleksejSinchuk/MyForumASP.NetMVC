using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForumMVC.Models
{
    public class Theme
    {
        public int Id { get; set; }
        public int IdUser { get; set; }

        public string ThemeName { get; set; }

        public DateTime DateTimeTheme { set; get; }

        public static IEnumerable<Theme> GetAllThemes()
        {
         DbForumConext db = new DbForumConext();
         IEnumerable<Theme> mess = from m in db.Themes
                                   select m;
         return mess;
        }


        public static IEnumerable<Theme> AddTheme(Theme theme) {
            DbForumConext db = new DbForumConext();
            db.Themes.Add(theme);
            db.SaveChanges();
            return GetAllThemes();
        }
    }
   
}

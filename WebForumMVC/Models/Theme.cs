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



        public static IEnumerable<Theme> AddTheme(Theme theme)
        {
            if (theme.ThemeName != null)
            {
                DbForumConext db = new DbForumConext();
                db.Themes.Add(theme);
                db.SaveChanges();
            }
            return GetAllThemes();
        }


        public static List<ThemesAndCountMess> ShowThemesAndCounts()
        {
            IEnumerable <Theme> tmp = Theme.GetAllThemes();

            //NE TO!!!!
            IEnumerable<Message> messages; 
            List<ThemesAndCountMess> TACM = new List<ThemesAndCountMess>();
            foreach (var item in tmp)
            {
                messages = Message.GetMessagesByIdTheme(item.Id);
                DateTime dt;
                if (messages.Count() != 0)
                {
                    Message t = messages.Last<Message>();
                  dt = t.DateTimeMsg;
                }
                else
                {
                    dt = DateTime.MinValue;
                }
                int a = Message.CountMessInTheme(item.Id);
                TACM.Add(new ThemesAndCountMess { theme = item,count=a,LastMess=dt
                });
            }
                return TACM;
        }

        public static void DellTheme(int idTheme) {
            IEnumerable<Message> mess = Message.GetMessagesByIdTheme(idTheme);
            if (mess != null)
            {
                foreach (var item in mess)
                {
                    Message.DellOneMess(item.Id);
                }
            }
            DbForumConext db = new DbForumConext();
            Theme t = db.Themes.Find(idTheme);
            db.Themes.Remove(t);
            db.SaveChanges();

        }

    }
}

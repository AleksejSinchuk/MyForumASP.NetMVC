using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForumMVC.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int IdUser { get; set; }

        public int IdTheme { get; set; }
        public string Msg { get; set; }

        public DateTime DateTimeMsg { set; get; }



        public static IEnumerable<Message> GetMessagesByIdTheme(int idTheme)
        {
            DbForumConext db = new DbForumConext();
            IEnumerable<Message> mess= from m in db.Messages
                                     where m.IdTheme == idTheme
                                     select m;
            return mess;
        }
    }
}
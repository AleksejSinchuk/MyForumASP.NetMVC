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
                                     select m ;
                                     
                                    
            return mess;
        }

        public static int CountMessInTheme(int idTheme)
        {
            IEnumerable<Message> m = GetMessagesByIdTheme(idTheme);
            int count = 0;
            if(m!=null)
            foreach (var item in m)
            {
                    count++;       
            }
            return count;
        }

        public static IEnumerable<Message> AddMess(Message m, int idTheme)
        {

            if (m.Msg != null) {
            DbForumConext db = new DbForumConext();
            db.Messages.Add(m);
            db.SaveChanges();
               
            }
        
            return GetMessagesByIdTheme(idTheme);
        }

        public static List<MessagesAndUsers> MessagesAndUsers(int idTheme) {
            List<MessagesAndUsers> list = new List<MessagesAndUsers>();
            IEnumerable<Message> m = GetMessagesByIdTheme(idTheme);
            foreach (var item in m)
            {
                list.Add(new Models.MessagesAndUsers { mess = item, userLogin =User.GetLoginById(item.IdUser)[0] }) ;
            }

            return list;
        }


    }
}
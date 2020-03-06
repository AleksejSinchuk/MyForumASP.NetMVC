using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForumMVC.Models
{
    public class ThemesAndCountMess
    {
        public Theme theme{ get; set; }
        public int count { get; set; }

        public DateTime LastMess { set; get; }
    }
}
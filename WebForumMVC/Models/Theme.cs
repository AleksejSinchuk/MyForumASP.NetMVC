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
    }
}
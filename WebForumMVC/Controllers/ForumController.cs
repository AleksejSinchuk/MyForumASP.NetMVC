using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForumMVC.Models;

namespace WebForumMVC.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum
        public ActionResult LoginForm()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CheckLogin(UserLogin u ) {
            //Проверка Логина и Пароля во входе
            return View();
        }
    }
}
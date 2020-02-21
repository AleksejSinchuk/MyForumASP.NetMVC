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


        //------------------------------------------------------------
        //Login Form
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

        //------------------------------------------------------------


        public ActionResult RegistrForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegistrGetCode(User u)
        {
            u.LastLogin = DateTime.Now;
            int a = 15;
            //Проверка Логина и Пароля во входе
            return View();
        }

    }
}
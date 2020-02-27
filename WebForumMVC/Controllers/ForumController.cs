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
            //Добавить проверку Юзера и отправку кода на имейл
            u.LastLogin = DateTime.Now;


            return View("~/Views/Forum/CodeForm.cshtml");
            
        }
        public ActionResult CodeForm()
        {
            return View();
        }

        //-------------------------------------------------------

        public ActionResult ShowThemes()
        {
            DbForumConext forum = new DbForumConext();
            ViewBag.Th = forum.Themes;
           
            return View();
        }

        [HttpGet]
        public ActionResult ShowMessInTheme(int idTheme)
        {
            return View();
        }

    }
}
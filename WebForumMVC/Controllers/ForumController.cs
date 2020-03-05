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

        DbForumConext forum = new DbForumConext();
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


            ViewBag.tmp = Theme.GetAllThemes();

               List<int> mass = new List<int>() ;
            foreach (var item in ViewBag.tmp)
            {
                ViewBag.tmp2= Message.GetMessagesByIdTheme(item.Id);
                int a = 0;
                foreach (var item2 in ViewBag.tmp2)
                {
                    a++;
                }
                mass.Add(a);
            }
            ViewBag.counts = mass;
            ViewBag.Th = Theme.GetAllThemes();
            return View();
        }

   

        [HttpPost]
        public ActionResult AddTheme(Theme theme)
        {
            theme.DateTimeTheme = DateTime.Now;
            theme.IdUser = 1;//временно поставил 1,добавить как то юзера
            Theme.AddTheme(theme);
            ViewBag.Th = Theme.GetAllThemes();
            return View("~/Views/Forum/ShowThemes.cshtml");
        }

        //-------------------------------------------------------
        [HttpGet]
        public ActionResult ShowMessInTheme(int idTheme)
        {
            ViewBag.msg = Message.GetMessagesByIdTheme(idTheme);
            ViewBag.Idthm = idTheme;


            return View();
        }

        [HttpPost]
        public ActionResult AddMessInTheme( Message m)
        {
            m.DateTimeMsg = DateTime.Now;
            m.IdUser = 1;//временно поставил 1,добавить как то юзера
            
            ViewBag.msg =Message.AddMess(m, m.IdTheme);
            return View("~/Views/Forum/ShowMessInTheme.cshtml");
        }
    }
}
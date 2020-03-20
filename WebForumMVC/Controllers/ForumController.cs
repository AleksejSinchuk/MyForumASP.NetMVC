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



    [HttpPost]
        public ActionResult CheckLogin(UserLogin u ) {
           
           User user = Models.User.GetUserByEmail2(u.Email);
            if (user != null)
            {
                if (user.HashPass == Util.GetSHA_256(u.Password))
                {
                    Session["userId"] = user.Id;
                    ViewBag.IsLogin = user;
                }
                else
                {
                    ViewBag.IsLogin = null;
                }

            }
            else
            {
                ViewBag.IsLogin = null;
            }
            ViewBag.Th = Theme.ShowThemesAndCounts();
            
            return View("~/Views/Forum/ShowThemes.cshtml");
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
            User tmp=Models.User.GetUserByEmail2(u.Email);

            if (tmp == null)
            {
                ViewBag.tmp = Models.User.AddUser(u);
                ViewBag.IsLogin = Models.User.GetUserByEmail2(u.Email);
            }
            else
            {
             ViewBag.IsLogin =tmp;
            }
            Session["userId"] = ViewBag.IsLogin.Id;
            ViewBag.Th = Theme.ShowThemesAndCounts();
            return View("~/Views/Forum/ShowThemes.cshtml");


        }

        //-------------------------------------------------------

        public ActionResult ShowThemes()
        {
            if (Session["userId"] != null)
            {
                ViewBag.user = Models.User.GetUserById2(Convert.ToInt32(Session["userId"]));
                ViewBag.IsLogin = ViewBag.user;
            }
            else
            {
                ViewBag.IsLogin = null;
            }
          

            ViewBag.Th=Theme.ShowThemesAndCounts();
            return View();
        }

   

        [HttpPost]
        public ActionResult AddTheme(Theme theme)
        {
            theme.DateTimeTheme = DateTime.Now;
            theme.IdUser = (Convert.ToInt32(Session["userId"]));//временно поставил 1,добавить как то юзера
            Theme.AddTheme(theme);
            if (Session["userId"] != null)
            {
                ViewBag.user = Models.User.GetUserById2(Convert.ToInt32(Session["userId"]));
                ViewBag.IsLogin = ViewBag.user;
            }
            else
            {
                ViewBag.IsLogin = null;
            }
            ViewBag.Th = Theme.ShowThemesAndCounts();
            return View("~/Views/Forum/ShowThemes.cshtml");
        }








        //-------------------------------------------------------
        [HttpGet]
        public ActionResult ShowMessInTheme(int idTheme)
        {

            if (Session["userId"] != null)
            {
                ViewBag.user = Models.User.GetUserById2(Convert.ToInt32(Session["userId"]));
                ViewBag.IsLogin = ViewBag.user;
            }
            else
            {
                ViewBag.IsLogin = null;
            }


            ViewBag.msg = Message.MessagesAndUsers(idTheme);
            ViewBag.Idthm = idTheme;
           
            return View();
        }

        [HttpPost]
        public ActionResult AddMessInTheme( Message m)
        {
            m.DateTimeMsg = DateTime.Now;
            m.IdUser = Convert.ToInt32(Session["userId"]);
            if (Session["userId"] != null)
            {
                ViewBag.user = Models.User.GetUserById2(Convert.ToInt32(Session["userId"]));
                ViewBag.IsLogin = ViewBag.user;
            }
            else
            {
                ViewBag.IsLogin = null;
            }
            Message.AddMess(m, m.IdTheme);
            ViewBag.msg = Message.MessagesAndUsers(m.IdTheme);
            return View("~/Views/Forum/ShowMessInTheme.cshtml");
        }

        public ActionResult Logout()
        {
            Session["userId"] = null;
            ViewBag.IsLogin = null;
            ViewBag.Th = Theme.ShowThemesAndCounts();
            return View("~/Views/Forum/ShowThemes.cshtml");
        }

        [HttpGet]
        public ActionResult DellTheme(int IdTheme)
        {
            Theme.DellTheme(IdTheme);
            ViewBag.IsLogin = Models.User.GetUserById2(Convert.ToInt32(Session["userId"]));
            ViewBag.Th = Theme.ShowThemesAndCounts();
            return View("~/Views/Forum/ShowThemes.cshtml");
        }


        [HttpGet]
        public ActionResult DellMess(int IdMess, int idTheme )
        {

            Message.DellOneMess(IdMess);
            ViewBag.IsLogin = Models.User.GetUserById2(Convert.ToInt32(Session["userId"]));
            ViewBag.msg = Message.MessagesAndUsers(idTheme);
            return View("~/Views/Forum/ShowMessInTheme.cshtml");
        }
    }
    
}
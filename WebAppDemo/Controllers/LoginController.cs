using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebAppDemo.Models;

namespace WebAppDemo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(user loginmodel, string returnURL)
        {
            if (IsUsersValid(loginmodel))
            {
                FormsAuthentication.SetAuthCookie(loginmodel.username, false);
                Session["username"] = loginmodel.username;
                return Redirect(returnURL);
            }
            else
            {
                loginmodel.response = "Wrong Username and Password";
                return View("Index", loginmodel);
            }
        }

        private bool IsUsersValid(user m)
        {
            using (WebAppDemoEntities db = new WebAppDemoEntities())
            {
                var userret = db.users.Where(x =>x.username == m.username && x.password == m.password).FirstOrDefault();
                if (userret == null)
                {
                    //m.response = "Wrong Username and Password";
                    //return View("Index", m);
                    return false;
                }
                else
                {
                    return true;
                }
            }
                //return (m.username == "admin" && m.password == "admin");
        }
    }
}
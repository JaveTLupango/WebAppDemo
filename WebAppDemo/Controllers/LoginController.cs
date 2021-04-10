using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                //loginmodel.response = "Wrong Username and Password";
                return View("Index", loginmodel);
            }
        }

        private bool IsUsersValid(user m)
        {
            using (WebAppDemoEntities1 db = new WebAppDemoEntities1())
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

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            //Request.Cookies.Clear();
            return RedirectToAction("Index", "Home");
        }

       
    }
}
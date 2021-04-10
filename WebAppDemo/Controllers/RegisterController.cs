using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebAppDemo.Models;

namespace WebAppDemo.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(user model)
        {
            using (WebAppDemoEntities1 db = new WebAppDemoEntities1())
            {
                //var userret = db.users.Where(x => x.username == model.username && x.password == model.password).FirstOrDefault();
                db.users.Add(model);
                db.SaveChanges();

                FormsAuthentication.SetAuthCookie(model.username, false);
                Session["username"] = model.username;
                return Redirect("/home/index");
            }
            return View();
        }
    }
}
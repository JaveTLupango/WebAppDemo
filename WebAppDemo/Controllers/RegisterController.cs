using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            using (WebAppDemoEntities db = new WebAppDemoEntities())
            {
                //var userret = db.users.Where(x => x.username == model.username && x.password == model.password).FirstOrDefault();
                db.users.Add(model);
                db.SaveChanges();
               
            }
            return View();
        }
    }
}
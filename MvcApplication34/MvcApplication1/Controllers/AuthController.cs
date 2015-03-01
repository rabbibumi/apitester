using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication1.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && username.ToLower() == "foo" && password == "12345")
            {
                FormsAuthentication.SetAuthCookie("foo", true);
                return RedirectToAction("SecretPage");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index"); 
        }

        [Authorize]
        public ActionResult SecretPage()
        {
            return View();
        }

        [Authorize]
        public ActionResult JsonPage()
        {
            return Json(new {foo = "bar"}, JsonRequestBehavior.AllowGet);
        }

    }
}

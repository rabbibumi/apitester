using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication34.Controllers
{
    public class AuthController : Controller
    {
        //
        // GET: /Auth/

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

        [Authorize]
        public ActionResult SecretPage()
        {
            return View();
        }

    }
}

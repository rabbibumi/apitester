using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication34.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new PeopleViewModel{People = PeopleDb.GetAll()});
        }
    }

    public class PeopleViewModel
    {
        public IEnumerable<Person> People { get; set; } 
    }
}

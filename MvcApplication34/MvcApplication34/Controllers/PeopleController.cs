using System.Collections.Generic;
using System.Web.Http;
using System.Web.ModelBinding;

namespace MvcApplication34.Controllers
{
    public class PeopleController : ApiController
    {
        public IEnumerable<Person> Get()
        {
            return PeopleDb.GetAll();
        }

        public Person Post(Person p)
        {
            PeopleDb.Add(p);
            return p;
        }
    }
}
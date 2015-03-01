using System.Collections.Generic;
using System.Linq;

namespace MvcApplication34.Controllers
{
    public static class PeopleDb
    {
        private static List<Person> _people = new List<Person>();

        static PeopleDb()
        {
            _people.AddRange(Enumerable.Range(1, 10).Select(_ => Person.CreateRandomPerson()));
        }

        public static IEnumerable<Person> GetAll()
        {
            return _people;
        }

        public static void Add(Person p)
        {
            _people.Add(p);
        }
    }
}
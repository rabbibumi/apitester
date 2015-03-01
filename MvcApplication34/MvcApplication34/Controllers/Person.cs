using System;
using System.Net;
using System.Net.Http;

namespace MvcApplication34.Controllers
{
    public class Person
    {
        private static string[] _firstNames = { "Avrumi", "Yehuda", "Yaakov Meir", "Shamai", "Srully", "Elchonon" };
        private static string[] _lastNames = { "Friedman", "Moskowitz", "Brissman", "Katz", "Loeb", "Spiegel" };

        private static Random rnd = new Random();

        public static Person CreateRandomPerson()
        {
            return new Person
                {
                    FirstName = _firstNames[rnd.Next(_firstNames.Length)],
                    LastName = _lastNames[rnd.Next(_lastNames.Length)],
                    Age = rnd.Next(20, 100)
                };
        }

        public override string ToString()
        {
            return String.Format("First Name: {0}, Last Name: {1}, Age: {2}", FirstName, LastName, Age);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
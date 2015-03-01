using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiTester
{
    public class SimpleAPI
    {
        private readonly string _baseUrl;

        public SimpleAPI(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public IEnumerable<Person> Get()
        {
            using (var webClient = new WebClient())
            {
                string result = webClient.DownloadString(_baseUrl + "/api/people");
                return JsonConvert.DeserializeObject<IEnumerable<Person>>(result);
            }
        }

        //        public void Test()
        //        {
        //            using (var webClient = new WebClient())
        //            {
        //                webClient.Headers[HttpRequestHeader.Accept] = "text/xml";
        //                string result = webClient.DownloadString(_baseUrl + "/api/people");
        //                Console.WriteLine(result);
        //            }
        //        }


        public Person Add(string firstName, string lastName, int age)
        {
            using (var webClient = new WebClient())
            {
                var p = new Person {FirstName = firstName, LastName = lastName, Age = age};
                string body = JsonConvert.SerializeObject(p);
                //string body = String.Format("firstName={0}&lastName={1}&age={2}", firstName, lastName, age);
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                string result = webClient.UploadString(_baseUrl + "/api/people", body);
                return JsonConvert.DeserializeObject<Person>(result);
            }
        }

        public void ScrapePeople()
        {
            using (var webClient = new WebClient())
            {
                string result = webClient.DownloadString(_baseUrl);
                Console.WriteLine(result);
            }
        } 


    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} - {2}", FirstName, LastName, Age);
        }
    }
}

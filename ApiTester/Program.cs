using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new SimpleAPI("http://localhost:6109");
            foreach (var person in api.Get())
            {
                Console.WriteLine(person);
            }

            //api.Test();

            Console.ReadKey(true);
        }
    }
}

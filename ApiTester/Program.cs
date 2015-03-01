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
            Console.WriteLine("Press 1 to see all, press 2 to add new");
            string result = Console.ReadLine();
            if (result != "1" && result != "2")
            {
                Console.WriteLine("Seriously?????");
                Console.ReadKey(true);
                return;
            }

            if (result == "1")
            {
                ShowAll();
            }
            else
            {
                AddNew();
            }
            //api.Test();

            Console.ReadKey(true);
        }

        private static void AddNew()
        {
            Console.WriteLine("Enter FirstName: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter LastName: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            var api = new SimpleAPI("http://localhost:6109");
            var result = api.Add(firstName, lastName, age);
            Console.WriteLine(result);
        }

        private static void ShowAll()
        {
            var api = new SimpleAPI("http://localhost:6109");
            foreach (var person in api.Get())
            {
                Console.WriteLine(person);
            }
        }
    }
}

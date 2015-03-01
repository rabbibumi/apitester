using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAutomation;
using WatiN.Core;

namespace ApiTester
{

    public class BrowserAutomater : FluentTest
    {
        public void Run()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
            I.Open("http://www.saksfifthavenue.com/main/ProductDetail.jsp?FOLDER%3C%3Efolder_id=2534374306418198&PRODUCT%3C%3Eprd_id=845524446774244&R=438146665775&P_name=AMI&N=306418198&bmUID=kLflIto");
            var smallLink =
                I.Find(
                    "#saksBody > div:nth-child(8) > div.product.main-product.grid-100.grid-parent.page-section > div.detail-column > div.configuration.sub-section > div.size.selector.component.component-3.clearfix.js-size-selector.has-select-picker > div > div.body > div > div.body > div > a:nth-child(2)");
            I.Click(smallLink);
            I.Click(smallLink);

            var addButton =
                I.Find(
                    "#saksBody > div:nth-child(8) > div.product.main-product.grid-100.grid-parent.page-section > div.detail-column > div.configuration.sub-section > div.add-to-bag.component.component-3 > div > button");
            I.Click(addButton);
            I.TakeScreenshot("output.png");
            I.Dispose();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Press 1 to see all, press 2 to add new, 3 to scrape");
            //string result = Console.ReadLine();
            //if (result != "1" && result != "2" && result != "3")
            //{
            //    Console.WriteLine("Seriously?????");
            //    Console.ReadKey(true);
            //    return;
            //}

            //if (result == "1")
            //{
            //    ShowAll();
            //}
            //else if (result == "2")
            //{
            //    AddNew();
            //}
            //else
            //{
            //    Scrape();
            //}

            //var b = new FireFox("http://www.saksfifthavenue.com/main/ProductDetail.jsp?FOLDER%3C%3Efolder_id=2534374306418198&PRODUCT%3C%3Eprd_id=845524446774244&R=438146665775&P_name=AMI&N=306418198&bmUID=kLflIto");

            //Console.ReadKey(true);

            //b.Close();

            //api.Test();
            new BrowserAutomater().Run();
            Console.ReadKey(true);
        }

        private static void Scrape()
        {
            var api = new SimpleAPI("http://localhost:6109");
            api.ScrapePeople();
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

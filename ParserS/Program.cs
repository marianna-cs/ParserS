using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace ParserS
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var i = 1;
            
            while (true)
            {
               

                using (var driver = new FirefoxDriver())
                {
                    //
                    var link = $"https://e-katalog.intercars.com.pl/#/oferta/0,{i.ToString()},Mechanizm-wycieraczek,scr_dTree/100001,102028,938385/";

                    var productLoader = new ProductLoader(link, driver);

                    var products = productLoader.LoadProductsFromLinq().ToList();

                   

                    Console.WriteLine(i);

                    i += 15;
                  
                }

                
            }
            

        }


    }
}

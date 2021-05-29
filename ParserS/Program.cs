using OpenQA.Selenium;
using System;

namespace ParserS
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            //

            while (true)
            {
                var i = 0;
                var link = "https://e-katalog.intercars.com.pl/#/oferta/0,{i.ToString()},Agregaty-chlodnicze,scr_dItems/100001,301224/";
                var productLoader = new ProductLoader(link);
                var products = productLoader.LoadProductsFromLinq();
                i += 16;
            }
            
        }
    }
}

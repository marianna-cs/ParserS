using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ParserS
{
    public class ProductLoader
    {
        private string _porductsLinq;
        private IWebDriver _driver;
        public IEnumerable<Product> Products { get; private set; }
        public ProductLoader(string porductsLinq, IWebDriver driver)
        {
            _porductsLinq = porductsLinq ?? throw new ArgumentNullException(nameof(porductsLinq));
            _driver = driver;
        }


        private void LoadLinq() 
        {
            _driver.Url = _porductsLinq;
            var lastImg = By.Id("dItems");

            

            WaitHelpers.WaitUntilElementClickable(_driver, lastImg, 40);
        }
        private IEnumerable<string> LoadProducts() 
        {
            //_driver.FindElement(By.XPath(@".//a[@class='product-btn ajax']")).GetAttribute("href")
            var productLinqs = _driver.FindElements(By.XPath(@".//a[@class='product-btn ajax']")).Select(a => a.GetAttribute("href"));



            return productLinqs;
        }
        public IEnumerable<Product> LoadProductsFromLinq() 
        {
            LoadLinq();
            var productLinqs = LoadProducts().ToList();
            var resultProductSet = new List<Product>();
            using (var driver = new FirefoxDriver()) 
            {
                foreach (var productLinq in productLinqs)
                {
                    var product = new ProductCreator(productLinq, driver).CreateProductOrNull();
                    if (product == null)
                    {
                        continue;
                    }
                    resultProductSet.Add(product);

                    var productSaver = new PicSaver(driver, new List<Product>() { product });
                    productSaver.SavePics();

                   
                }
                Products = resultProductSet;

                return resultProductSet;
            }

        }

       
       
    }
}

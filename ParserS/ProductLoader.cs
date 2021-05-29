using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserS
{
    public class ProductLoader
    {
        private string _porductsLinq;
        private IWebDriver _driver = new ChromeDriver();
        public IEnumerable<Product> Products { get; private set; }
        public ProductLoader(string porductsLinq)
        {
            _porductsLinq = porductsLinq ?? throw new ArgumentNullException(nameof(porductsLinq));
        }

        private void LoadLinq() 
        {
            _driver.Url = _porductsLinq;
            var lastImg = By.ClassName("logosy-inter-cars");
            WaitHelpers.WaitUntilElementClickable(_driver, lastImg, 40);
        }
        private IEnumerable<string> LoadProducts() 
        {
            return _driver.FindElements(By.XPath(@".//td[@class='product-image-table-thumb']/img")).Select(img => img.GetAttribute("src"));
        }
        public IEnumerable<Product> LoadProductsFromLinq() 
        {
            LoadLinq();
            var productLinqs = LoadProducts();
            var resultProductSet = new List<Product>();

            foreach (var productLinq in productLinqs)
            {
                var product = new ProductCreator(productLinq, _driver).CreateProduct();
                resultProductSet.Add(product);
            }
            Products = resultProductSet;

            return resultProductSet;

        }

       
       
    }
}

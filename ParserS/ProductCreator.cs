using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParserS
{
    public class ProductCreator
    {
        private string _productLinq;
        private IWebDriver _driver;

        public ProductCreator(string productLinq, IWebDriver driver)
        {
            _productLinq = productLinq ?? throw new ArgumentNullException(nameof(productLinq));
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        private void LoadProductPage() 
        {
            _driver.Url = _productLinq;
        }
        private string LoadBrand() 
        {
            return _driver.FindElement(By.XPath(@".//strong[@itemprop='brand']/span")).Text;
        }
        private string LoadProductIndex() 
        {
            var index = _driver.FindElement(By.XPath(@".//div[@class='productCardIndex col-xs-6 col-sm-6 col-md-6 col-lg-6']/h2")).Text;

            return index.Replace("/", "");
        }
        private IEnumerable<string> LoadProductImages() 
        {

            _driver.FindElement(By.XPath(@".//div[@class='productCardImage']")).Click();

            var pic = By.Id("picView");

            WaitHelpers.WaitUntilElementClickable(_driver, pic, 40);

            var result = new List<string>();
            result.Add(_driver.FindElement(By.XPath(@".//div[@id='picView']/img")).GetAttribute("src"));
            return result;
        }

        public Product CreateProduct() 
        {
            var product = new Product(LoadProductImages(), LoadBrand(), LoadProductIndex());

            return product;
 
        }
    }
}

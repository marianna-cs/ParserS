using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ParserS
{
    public class PicSaver
    {
        private IWebDriver _driver;
        private IEnumerable<Product> _products;
        private const string PARS_CATEGORY_NAME = @"E:\Mechanizm wycieraczek\";
        public PicSaver(IWebDriver driver, IEnumerable<Product> products)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _products = products ?? throw new ArgumentNullException(nameof(products));
        }

        public void SavePics() 
        {
            foreach (var product in _products) 
            {
                foreach (var productLinq in product.ProductImages) 
                {
                    LoadPhotoPage(productLinq);
                    //Todo: func SavePic()

                    ITakesScreenshot ssdriver = _driver as ITakesScreenshot;

                    Screenshot screenshot = ssdriver.GetScreenshot();

                    Screenshot tempImage = screenshot;

                    Directory.CreateDirectory(PARS_CATEGORY_NAME + product.Brand);

                    tempImage.SaveAsFile(PARS_CATEGORY_NAME + product.Brand + @"\" + product.ProductIndex + ".png", ScreenshotImageFormat.Png);

                }
                
            }
        }

        private void LoadPhotoPage(string photoUrl)
        {
           
            _driver.Url = photoUrl;
            _driver.Navigate();
            var pic = By.XPath((@".//img"));
            WaitHelpers.WaitUntilElementClickable(_driver, pic, 40);
        }
    }
}

using System;
using System.Collections.Generic;

namespace ParserS
{
    public class Product
    {
        
        public IEnumerable<string> ProductImages { get; }

        public string ProductIndex { get; }

        public string Brand { get; }

        public Product(IEnumerable<string> productImages, string productIndex, string brand)
        {
            ProductImages = productImages ?? throw new ArgumentNullException(nameof(productImages));
            ProductIndex = productIndex ?? throw new ArgumentNullException(nameof(productIndex));
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace checkout_kata
{
    public class Product
    {
        public string ProductSKU { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public Product()
        {

        }

        public Product(string sku, string name, decimal price)
        {
            ProductSKU = sku;
            ProductName = name;
            ProductPrice = price;
        }
    }
}

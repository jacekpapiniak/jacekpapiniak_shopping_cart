using System;
using System.Collections.Generic;
using System.Text;

namespace checkout_kata
{
    public class DealOfAWeek
    {
        public Product DealProduct { get; set; }
        public int ProductQuantity { get; set; }
        public decimal DealPrice { get; set; }

        public DealOfAWeek(Product dealProduct, int productQuantity, decimal dealPrice)
        {
            DealProduct = dealProduct;
            ProductQuantity = productQuantity;
            DealPrice = dealPrice;
        }
    }
}

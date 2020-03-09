using System;
using System.Collections.Generic;
using System.Linq;

namespace checkout_kata
{
    public class Basket
    {
        public List<Product> productsInBasket = new List<Product>();
        List<DealOfAWeek> listOfDeals = new List<DealOfAWeek>();

        public Basket()
        {
            listOfDeals = new List<DealOfAWeek>()
            {
                new DealOfAWeek(new Product("A99","Apple",50),3,130),
                new DealOfAWeek(new Product("B15","Biscuits",30),2,45),
            };
        }

        public void Scan(Product product)
        {
            productsInBasket.Add(product);
        }

        public decimal Total()
        {
            var productsSKU = productsInBasket.OrderBy(product => product.ProductSKU).Select(product => product.ProductSKU).Distinct().ToList();

            decimal total = 0.0M;

            foreach (var ProductSKU in productsSKU)
            {
                DealOfAWeek deal = listOfDeals.FirstOrDefault(dealProduct => dealProduct.DealProduct.ProductSKU == ProductSKU);

                if (deal != null)
                {
                    int noOfDealProductsInBasket = productsInBasket.Where(products => products.ProductSKU == ProductSKU).Count();
                    int restOfProductsThatAreNotInDeal = noOfDealProductsInBasket % deal.ProductQuantity;

                    if (noOfDealProductsInBasket % deal.ProductQuantity == 0)
                    {
                        total += (noOfDealProductsInBasket / deal.ProductQuantity) * deal.DealPrice;
                    }
                    else
                    {
                        total += ((noOfDealProductsInBasket / deal.ProductQuantity) * deal.DealPrice) + restOfProductsThatAreNotInDeal * deal.DealProduct.ProductPrice;
                    }
                }
                else
                {
                    var noDealproduct = productsInBasket.FirstOrDefault(basketProduct => basketProduct.ProductSKU == ProductSKU);
                    total += productsInBasket.Where(basketProduct => basketProduct.ProductSKU == ProductSKU).Count() * noDealproduct.ProductPrice;
                }
            }

            return total;
        }

        public void PrintBasket()
        {

            foreach (var product in productsInBasket)
            {
                System.Console.WriteLine(string.Format("{0} {1} {2}", product.ProductSKU, product.ProductName, product.ProductPrice));
            }
        }
    }
}

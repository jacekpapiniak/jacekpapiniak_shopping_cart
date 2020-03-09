using System;

namespace checkout_kata.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Basket");
            Basket basket = new Basket();

            Product apples = new Product("A99", "Apple", 50);
            Product biscuit = new Product("B15", "Biscuits", 30);
            Product grapes = new Product("C40", "Grapes", 25);
            Product cheery = new Product("T34", "Cheery", 99);

            basket.Scan(biscuit);
            basket.Scan(apples);
            basket.Scan(biscuit);
            basket.Scan(biscuit);

            basket.PrintBasket();
            System.Console.WriteLine("Total to pay: " + basket.Total()); ;
        }
    }
}

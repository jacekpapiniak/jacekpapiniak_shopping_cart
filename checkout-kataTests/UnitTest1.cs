using NUnit.Framework;
using checkout_kata;
using System.Linq;

namespace checkout_kataTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateProduct()
        {
            //Arrange
            var expected = new Product("A99", "An Apple", 50M);
            
            //Act
            Product product = new Product("A99", "An Apple", 50M);
            //Assert
            Assert.AreEqual(expected.ProductName,product.ProductName);
            Assert.AreEqual(expected.ProductSKU,product.ProductSKU);
            Assert.AreEqual(expected.ProductPrice,product.ProductPrice);
        }

        [Test]
        public void ScanProduct()
        {
            //Arrange
            Product product = new Product("A99", "An Apple", 50M);
            Basket basket = new Basket();
            var expected = product;
            //Act
            basket.Scan(product);
            var result = basket.productsInBasket.First();
            //Assert
            Assert.AreEqual(expected.ProductName, result.ProductName);
            Assert.AreEqual(expected.ProductSKU, result.ProductSKU);
            Assert.AreEqual(expected.ProductPrice, result.ProductPrice);
        }

        [Test]
        public void DisplayTotal_For_2Biscuits_and_OneApple()
        {
            //Arrange
            Basket basket = new Basket();

            Product apples = new Product("A99", "Apple", 50);
            Product biscuit = new Product("B15", "Biscuits", 30);
            Product grapes = new Product("C40", "Grapes", 25);
            Product cheery = new Product("T34", "Cheery", 99);
            var expected = 95M;
            //Act
            basket.Scan(biscuit);
            basket.Scan(apples);
            basket.Scan(biscuit);

            var result = basket.Total();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DisplayTotal_For_2Biscuits_and_3Apples()
        {
            //Arrange
            Basket basket = new Basket();

            Product apples = new Product("A99", "Apple", 50);
            Product biscuit = new Product("B15", "Biscuits", 30);
            Product grapes = new Product("C40", "Grapes", 25);
            Product cheery = new Product("T34", "Cheery", 99);
            var expected = 175M;
            //Act
            basket.Scan(biscuit);
            basket.Scan(apples);
            basket.Scan(biscuit);
            basket.Scan(apples);
            basket.Scan(apples);

            var result = basket.Total();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DisplayTotal_For_2Biscuits_and_3Apples_plus_OneOfOthers()
        {
            //Arrange
            Basket basket = new Basket();

            Product apples = new Product("A99", "Apple", 50);
            Product biscuit = new Product("B15", "Biscuits", 30);
            Product grapes = new Product("C40", "Grapes", 25);
            Product cheery = new Product("T34", "Cheery", 99);
            var expected = 299M;
            //Act
            basket.Scan(biscuit);
            basket.Scan(apples);
            basket.Scan(biscuit);
            basket.Scan(apples);
            basket.Scan(apples);
            basket.Scan(grapes);
            basket.Scan(cheery);

            var result = basket.Total();
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
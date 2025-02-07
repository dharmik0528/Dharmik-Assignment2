using NUnit.Framework;
using System;

namespace EcommerceApp.Tests
{
    [TestFixture]
    public class ProductTest
    {
        // Tests by Ayush Patel (ID: 8914603)

        /// <summary>
        /// Ensures the Product ID is correctly assigned at the maximum boundary value.
        /// </summary>
        [Test]
        public void Constructor_MaxBoundaryProdID_ShouldInitializeCorrectly()
        {
            var product = new Product(50000, "Gaming PC", 2999.99m, 20);
            Assert.That(product.ProdID, Is.EqualTo(50000));
        }

        /// <summary>
        /// Ensures an exception is thrown when Product ID exceeds the maximum limit.
        /// </summary>
        [Test]
        public void Constructor_AboveMaxProdID_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(50001, "OverLimit ID", 199.99m, 10));
        }

        /// <summary>
        /// Ensures an exception is thrown when Item Price is above the maximum allowed value.
        /// </summary>
        [Test]
        public void Constructor_AboveMaxItemPrice_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(600, "Luxury Smartphone", 5001m, 5));
        }

        /// <summary>
        /// Ensures StockAmount is correctly assigned when set to the maximum boundary value.
        /// </summary>
        [Test]
        public void Constructor_MaxBoundaryStockAmount_ShouldInitializeCorrectly()
        {
            var product = new Product(700, "Warehouse Storage", 3999.99m, 500000);
            Assert.That(product.StockAmount, Is.EqualTo(500000));
        }

        /// <summary>
        /// Ensures an exception is thrown when trying to increase stock by a negative amount.
        /// </summary>
        [Test]
        public void IncreaseStock_NegativeAmount_ShouldThrowException()
        {
            var product = new Product(800, "Smart Thermostat", 129.99m, 50);
            Assert.Throws<ArgumentException>(() => product.IncreaseStock(-10));
        }

        /// <summary>
        /// Ensures an exception is thrown when decreasing stock beyond available quantity.
        /// </summary>
        [Test]
        public void DecreaseStock_ExcessiveAmount_ShouldThrowException()
        {
            var product = new Product(900, "Portable Speaker", 199.99m, 10);
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(15));
        }

        // Tests by Yashwi Patel

        [Test]
        public void Product_Creation_ValidInput_ShouldCreateProduct()
        {
            var product = new Product(100, "Smartphone", 999.99m, 100);
            Assert.That(product.ProdID, Is.EqualTo(100));
            Assert.That(product.ProdName, Is.EqualTo("Smartphone"));
            Assert.That(product.ItemPrice, Is.EqualTo(999.99m));
            Assert.That(product.StockAmount, Is.EqualTo(100));
        }

        [Test]
        public void Product_InvalidProdID_ShouldThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(4, "InvalidID", 150m, 20));
        }

        [Test]
        public void Product_EmptyProductName_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Product(100, "", 300m, 50));
        }

        [Test]
        public void IncreaseStock_ValidAmount_ShouldIncreaseStock()
        {
            var product = new Product(202, "Headphones", 199.99m, 30);
            product.IncreaseStock(20);
            Assert.That(product.StockAmount, Is.EqualTo(50));
        }

        [Test]
        public void IncreaseStock_LargeValidAmount_ShouldIncreaseStockCorrectly()
        {
            var product = new Product(404, "Monitor", 299.99m, 100);
            product.IncreaseStock(100000);
            Assert.That(product.StockAmount, Is.EqualTo(100100));
        }

        [Test]
        public void DecreaseStock_ValidAmount_ShouldDecreaseStock()
        {
            var product = new Product(404, "Speaker", 299.99m, 50);
            product.DecreaseStock(25);
            Assert.That(product.StockAmount, Is.EqualTo(25));
        }

        // Tests by Dharmik

        /// <summary>
        /// Ensures that ProductID is assigned correctly at the minimum boundary value.
        /// </summary>
        [Test]
        public void Constructor_MinBoundaryProdID_ShouldInitializeCorrectly()
        {
            var product = new Product(5, "Entry Level Phone", 499.99m, 30);
            Assert.That(product.ProdID, Is.EqualTo(5));
        }

        /// <summary>
        /// Ensures an exception is thrown when price is set below the minimum allowed value.
        /// </summary>
        [Test]
        public void Constructor_BelowMinItemPrice_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(101, "Cheap Gadget", 4.99m, 10));
        }

        /// <summary>
        /// Ensures an exception is thrown when stock amount is set below the minimum allowed value.
        /// </summary>
        [Test]
        public void Constructor_BelowMinStockAmount_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(102, "Basic Charger", 10.99m, 4));
        }

        /// <summary>
        /// Ensures the stock increases correctly at the boundary value.
        /// </summary>
        [Test]
        public void IncreaseStock_BoundaryAmount_ShouldIncreaseCorrectly()
        {
            var product = new Product(203, "SSD Drive", 99.99m, 50);
            product.IncreaseStock(500000);
            Assert.That(product.StockAmount, Is.EqualTo(500050));
        }

        /// <summary>
        /// Ensures the stock decreases correctly at the boundary value.
        /// </summary>
        [Test]
        public void DecreaseStock_BoundaryAmount_ShouldDecreaseCorrectly()
        {
            var product = new Product(204, "External Hard Drive", 199.99m, 500000);
            product.DecreaseStock(500000);
            Assert.That(product.StockAmount, Is.EqualTo(0));
        }

        /// <summary>
        /// Ensures an exception is thrown when decreasing stock by a negative amount.
        /// </summary>
        [Test]
        public void DecreaseStock_NegativeAmount_ShouldThrowException()
        {
            var product = new Product(205, "Wireless Mouse", 49.99m, 30);
            Assert.Throws<ArgumentException>(() => product.DecreaseStock(-5));
        }
    }
}

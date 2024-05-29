using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ProductTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eCommerceApp;

namespace eCommerceApp.Tests
{
    [TestClass]
    public class ProductTests
    {
        // Attribute Tests
        [TestMethod]
        public void ProductID_Should_Be_Assigned_Correctly()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            var result = product.ProductID;

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ProductName_Should_Be_Assigned_Correctly()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            var result = product.ProductName;

            // Assert
            Assert.AreEqual("Test Product", result);
        }

        [TestMethod]
        public void Price_Should_Be_Assigned_Correctly()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            var result = product.Price;

            // Assert
            Assert.AreEqual(10.0m, result);
        }

        [TestMethod]
        public void Stock_Should_Be_Assigned_Correctly()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            var result = product.Stock;

            // Assert
            Assert.AreEqual(5, result);
        }

        // Stock Increase Tests
        [TestMethod]
        public void IncreaseStock_Should_Increase_Stock_By_Specified_Amount()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            product.IncreaseStock(5);

            // Assert
            Assert.AreEqual(10, product.Stock);
        }

        [TestMethod]
        public void IncreaseStock_With_Zero_Should_Not_Change_Stock()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            product.IncreaseStock(0);

            // Assert
            Assert.AreEqual(5, product.Stock);
        }

        [TestMethod]
        public void IncreaseStock_With_Negative_Should_Not_Change_Stock()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            product.IncreaseStock(-5);

            // Assert
            Assert.AreEqual(5, product.Stock);
        }

        // Stock Decrease Tests
        [TestMethod]
        public void DecreaseStock_Should_Decrease_Stock_By_Specified_Amount()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            product.DecreaseStock(3);

            // Assert
            Assert.AreEqual(2, product.Stock);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Amount to decrease exceeds stock available")]
        public void DecreaseStock_Should_Throw_Exception_When_Amount_Exceeds_Stock()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            product.DecreaseStock(6);
        }

        [TestMethod]
        public void DecreaseStock_With_Zero_Should_Not_Change_Stock()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            product.DecreaseStock(0);

            // Assert
            Assert.AreEqual(5, product.Stock);
        }

        [TestMethod]
        public void DecreaseStock_With_Negative_Should_Not_Change_Stock()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            product.DecreaseStock(-5);

            // Assert
            Assert.AreEqual(5, product.Stock);
        }
    }
}

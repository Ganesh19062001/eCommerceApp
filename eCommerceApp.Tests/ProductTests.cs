using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eCommerceApp;


namespace eCommerceApp.Tests
{
    [TestClass]
    public class ProductTests
    {
        // Constructor Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_When_ProductID_Is_Less_Than_1()
        {
            // Arrange & Act
            var product = new Product(0, "Test Product", 10.0m, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_When_ProductID_Is_Greater_Than_1000()
        {
            // Arrange & Act
            var product = new Product(1001, "Test Product", 10.0m, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_When_Price_Is_Less_Than_1()
        {
            // Arrange & Act
            var product = new Product(1, "Test Product", 0.99m, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_When_Price_Is_Greater_Than_5000()
        {
            // Arrange & Act
            var product = new Product(1, "Test Product", 5001.0m, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_When_Stock_Is_Less_Than_1()
        {
            // Arrange & Act
            var product = new Product(1, "Test Product", 10.0m, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_When_Stock_Is_Greater_Than_1000()
        {
            // Arrange & Act
            var product = new Product(1, "Test Product", 10.0m, 1001);
        }

        // Attribute Tests
        [TestMethod]
        public void Attributes_Should_Be_Assigned_Correctly()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act & Assert
            Assert.AreEqual(1, product.ProductID);
            Assert.AreEqual("Test Product", product.ProductName);
            Assert.AreEqual(10.0m, product.Price);
            Assert.AreEqual(5, product.Stock);
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
        [ExpectedException(typeof(ArgumentException))]
        public void IncreaseStock_Should_Throw_When_Amount_Is_Negative()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            product.IncreaseStock(-1);
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
        public void IncreaseStock_Should_Handle_Maximum_Boundary_Value()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 1);

            // Act
            product.IncreaseStock(999);

            // Assert
            Assert.AreEqual(1000, product.Stock);
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void DecreaseStock_Should_Throw_When_Amount_Exceeds_Stock()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            product.DecreaseStock(6);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DecreaseStock_Should_Throw_When_Amount_Is_Negative()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            product.DecreaseStock(-1);

            // Assert
            Assert.AreEqual(6, product.Stock);
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
        public void DecreaseStock_Should_Handle_Boundary_Value()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 1000);

            // Act
            product.DecreaseStock(1000);

            // Assert
            Assert.AreEqual(0, product.Stock);
        }

        [TestMethod]
        public void Constructor_Should_Assign_Correct_Values_At_Lower_Boundaries()
        {
            // Arrange
            var product = new Product(1, "Test Product", 1.0m, 1);

            // Act & Assert
            Assert.AreEqual(1, product.ProductID);
            Assert.AreEqual("Test Product", product.ProductName);
            Assert.AreEqual(1.0m, product.Price);
            Assert.AreEqual(1, product.Stock);
        }

        [TestMethod]
        public void Constructor_Should_Assign_Correct_Values_At_Upper_Boundaries()
        {
            // Arrange
            var product = new Product(1000, "Test Product", 5000.0m, 1000);

            // Act & Assert
            Assert.AreEqual(1000, product.ProductID);
            Assert.AreEqual("Test Product", product.ProductName);
            Assert.AreEqual(5000.0m, product.Price);
            Assert.AreEqual(1000, product.Stock);
        }
    }
}


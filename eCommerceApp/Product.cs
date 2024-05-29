using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eCommerceApp
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product(int productId, string productName, decimal price, int stock)
        {
            ProductID = productId;
            ProductName = productName;
            Price = price;
            Stock = stock;
        }

        public void IncreaseStock(int amount)
        {
            Stock += amount;
        }

        public void DecreaseStock(int amount)
        {
            if (amount <= Stock)
            {
                Stock -= amount;
            }
            else
            {
                throw new ArgumentException("Amount to decrease exceeds stock available");
            }
        }
    }
}


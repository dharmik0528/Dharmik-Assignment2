using System;

namespace EcommerceApp
{
    public class Product
    {
        public int ProdID { get; private set; }
        public string ProdName { get; private set; }
        public decimal ItemPrice { get; private set; }
        public int StockAmount { get; private set; }

        public Product(int prodID, string prodName, decimal itemPrice, int stockAmount)
        {
            if (prodID < 5 || prodID > 50000)
                throw new ArgumentOutOfRangeException(nameof(prodID), "Product ID must be between 5 and 50000.");
            if (itemPrice < 5 || itemPrice > 5000)
                throw new ArgumentOutOfRangeException(nameof(itemPrice), "Price must be between $5 and $5000.");
            if (stockAmount < 5 || stockAmount > 500000)
                throw new ArgumentOutOfRangeException(nameof(stockAmount), "Stock must be between 5 and 500000.");
            if (string.IsNullOrWhiteSpace(prodName))
                throw new ArgumentException("Product Name cannot be empty or whitespace.", nameof(prodName));

            ProdID = prodID;
            ProdName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        public void IncreaseStock(int amount)
        {
            if (amount < 1)
                throw new ArgumentException("Increase amount must be at least 1.");
            StockAmount += amount;
        }

        public void DecreaseStock(int amount)
        {
            if (amount < 1)
                throw new ArgumentException("Decrease amount must be at least 1.");
            if (StockAmount - amount < 0)
                throw new InvalidOperationException("Stock cannot be negative.");
            StockAmount -= amount;
        }
    }
}

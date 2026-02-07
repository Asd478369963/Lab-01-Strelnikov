using System;
using System.Collections.Generic;
using System.Linq;
namespace ShopInspection
{
    public class ProductManager
    {
        private List<string> products = new List<string>();
        private List<decimal> prices = new List<decimal>();
        public void AddProduct(string name, decimal price)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            products.Add(name);
            prices.Add(price);
        }
        public string GetMostExpensive()
        {
            if (prices.Count == 0) return "Нет товаров";
            decimal max = 0;
            string result = "";
            for (int i = 0; i < prices.Count; i++)
            {
                if (prices[i] > max)
                {
                    max = prices[i];
                    result = products[i];
                }
            }
            return result;
        }
        public decimal GetMostExpensivePrice()
        {
            return prices.Count > 0 ? prices.Max() : 0;
        }
    }
}
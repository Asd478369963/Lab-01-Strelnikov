using System.Collections.Generic;
namespace ShopInspection
{
    public class Inventory
    {
        private Dictionary<string, int> stock = new Dictionary<string, int>();
        public void AddStock(string product, int quantity)
        {
            if (stock.ContainsKey(product))
                stock[product] += quantity;
            else
                stock[product] = quantity;
        }
        public bool CheckStock(string product, int requested)
        {
            if (string.IsNullOrEmpty(product) || !stock.ContainsKey(product)) 
                return false;
            return stock[product] >= requested;
        }
    }
}
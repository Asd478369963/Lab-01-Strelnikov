using System.Collections.Generic;
public class Inventory
{
    private Dictionary<string, (int quantity, decimal price)> items;
    public Inventory()
    {
        items = new Dictionary<string, (int, decimal)>
        {
            {"Сыр", (10, 650m)},
            {"Хлеб", (20, 45.50m)},
            {"Молоко", (15, 78m)},
            {"Масло", (5, 320m)}
        };
    }
    public bool HasStock(string name, int quantity)
    {
        if (!items.ContainsKey(name)) return false;
        return items[name].quantity >= quantity;
    }
    public void ReduceStock(string name, int quantity)
    {
        if (!items.ContainsKey(name)) return;
        int newQty = items[name].quantity - quantity;
        if (newQty < 0) newQty = 0;
        items[name] = (newQty, items[name].price);
    }
}
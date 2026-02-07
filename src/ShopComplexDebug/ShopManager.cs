using System;
using System.Diagnostics;
public class ShopManager
{
    private decimal taxRate = 0.20m; 
    public decimal CalculateOrderTotal(decimal price, int quantity, decimal discountAmount)
    {
        Debug.Assert(quantity > 0, "Количество должно быть больше 0");
        decimal subtotal = price * quantity;
        if (discountAmount > subtotal)
            discountAmount = subtotal;
        decimal afterDiscount = subtotal - discountAmount;
        decimal tax = afterDiscount * taxRate;
        return afterDiscount + tax; 
    }
}
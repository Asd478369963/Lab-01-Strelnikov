using System;
public class DiscountPolicy
{
    public decimal GetDiscount(decimal subtotal, int percent)
    {
        if (percent < 0) percent = 0;
        if (percent > 50) percent = 50; 
        return subtotal * percent / 100;
    }
}
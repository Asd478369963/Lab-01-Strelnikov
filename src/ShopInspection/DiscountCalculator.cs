using System;
namespace ShopInspection
{
    public class DiscountCalculator
    {
        public decimal CalculatePrice(decimal price, int discountPercent)
        {
            if (discountPercent < 0) discountPercent = 0;
            if (discountPercent > 100) discountPercent = 100;
            decimal discount = price * discountPercent / 100;
            return price - discount;
        }
    }
}
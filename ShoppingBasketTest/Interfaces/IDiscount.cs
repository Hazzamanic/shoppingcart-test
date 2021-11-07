using ShoppingBasketTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasketTest.Interfaces
{
    public interface IDiscount
    {
        bool TryApplyDiscount(List<ShoppingBasketItem> items, out DiscountResult result);
    }
}

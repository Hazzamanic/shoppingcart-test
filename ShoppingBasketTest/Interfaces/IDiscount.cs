using ShoppingBasketTest.Models;
using System.Collections.Generic;

namespace ShoppingBasketTest.Interfaces
{
    public interface IDiscount
    {
        bool TryApplyDiscount(List<ShoppingBasketItem> items, out DiscountResult result);
    }
}

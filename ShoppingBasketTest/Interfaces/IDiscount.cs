using ShoppingBasketTest.Models;
using System.Collections.Generic;

namespace ShoppingBasketTest.Interfaces
{
    public interface IDiscount
    {
        /// <summary>
        /// Calculates the discount to apply to a list of items and what items are affected by the discount. A return value indicates whether a discount was applied or not.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        bool TryApplyDiscount(List<ShoppingBasketItem> items, out DiscountResult result);
    }
}

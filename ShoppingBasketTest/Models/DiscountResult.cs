using System.Collections.Generic;

namespace ShoppingBasketTest.Models
{
    public class DiscountResult
    {
        public DiscountResult(int amount, IEnumerable<ShoppingBasketItem> items)
        {
            Amount = amount;
            Items = items;
        }

        /// <summary>
        /// Items used in the discount
        /// </summary>
        public IEnumerable<ShoppingBasketItem> Items { get; }
        /// <summary>
        /// Discount amount
        /// </summary>
        public int Amount { get; }
    }
}

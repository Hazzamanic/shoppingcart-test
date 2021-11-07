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

        public IEnumerable<ShoppingBasketItem> Items { get; }
        public int Amount { get; }
    }
}

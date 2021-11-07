using System.Collections.Generic;

namespace ShoppingBasketTest.Models
{
    public class DiscountResult
    {
        public List<ShoppingBasketItem> Items { get; set; } = new List<ShoppingBasketItem>();
        public int Amount { get; set; }
    }
}

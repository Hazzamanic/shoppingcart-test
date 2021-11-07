using System.Collections.Generic;

namespace ShoppingBasketTest.Models
{
    public class DiscountResult
    {
        public List<int> ItemIndexes { get; set; } = new List<int>();
        public int Amount { get; set; }
    }
}

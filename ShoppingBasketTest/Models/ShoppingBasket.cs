using ShoppingBasketTest.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketTest.Models
{
    public class ShoppingBasket
    {
        private readonly IDiscountRepository _discountRepository;

        public ShoppingBasket(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public List<ShoppingBasketItem> Items { get; private set; } = new List<ShoppingBasketItem>();

        /// <summary>
        /// Add product to the shopping basket. Optionally provide a count of how many items to add
        /// </summary>
        /// <param name="product">The product to add to the basket</param>
        /// <param name="count">How many of this product should be added</param>
        public void Add(Product product, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Items.Add(new ShoppingBasketItem(product));
            }
        }

        public int Subtotal => Items.Sum(i => i.Price);
        public int Total => GetTotal();

        private int GetTotal()
        {
            var total = Subtotal - CalculateDiscount();
            if (total < 0) return 0;
            return total;
        }

        private int CalculateDiscount()
        {
            var discounts = _discountRepository.GetDiscounts();
            // clone the list
            var items = Items.ToList();
            int discountAmount = 0;
            while(true)
            {
                var discountResults = new List<DiscountResult>();
                foreach (var discount in discounts)
                {
                    // try to apply the discount
                    if(discount.TryApplyDiscount(items.ToList(), out var result))
                    {
                        discountResults.Add(result);
                    }
                }

                // if there were no discounts to apply, return the current discount
                if(!discountResults.Any())
                {
                    return discountAmount;
                }

                // find the biggest discount and apply it
                var maximumDiscount = discountResults.OrderBy(dr => dr.Amount).First();
                foreach(var item in maximumDiscount.Items)
                {
                    items.Remove(item);
                }
                discountAmount += maximumDiscount.Amount;
            }
        }
    }
}

using ShoppingBasketTest.Models;
using System.Collections.Generic;

namespace ShoppingBasketTest.Tests.Discounts
{
    public abstract class DiscountTestsBase
    {
        protected Product PRODUCT_A = new Product("a", "a", 100);
        protected Product PRODUCT_B = new Product("b", "b", 150);

        public DiscountTestsBase()
        {
        }


        protected List<ShoppingBasketItem> GetItems(Product product, int count)
        {
            var items = new List<ShoppingBasketItem>();
            for (int i = 0; i < count; i++)
            {
                items.Add(new ShoppingBasketItem(product));
            }
            return items;
        }
    }
}

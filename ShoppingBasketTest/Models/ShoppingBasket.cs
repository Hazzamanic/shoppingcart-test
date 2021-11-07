using System.Collections.Generic;

namespace ShoppingBasketTest.Models
{
    public class ShoppingBasket
    {
        public List<ShoppingBasketItem> Items { get; private set; } = new List<ShoppingBasketItem>();

        public void Add(Product product, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Items.Add(new ShoppingBasketItem(product));
            }
        }
    }
}

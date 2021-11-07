namespace ShoppingBasketTest.Models
{
    public class ShoppingBasketItem
    {
        public ShoppingBasketItem(Product product)
        {
            ProductId = product.Id;
            Name = product.Name;
            Price = product.Price;
        }

        public string ProductId { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
    }
}

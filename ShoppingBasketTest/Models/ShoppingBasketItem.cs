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

        public string ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}

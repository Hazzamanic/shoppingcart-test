using System.Collections.Generic;

namespace ShoppingBasketTest.Interfaces
{
    public interface IDiscountRepository
    {
        IEnumerable<IDiscount> GetDiscounts(); 
    }
}

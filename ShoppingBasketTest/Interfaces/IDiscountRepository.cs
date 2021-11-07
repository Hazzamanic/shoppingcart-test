using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasketTest.Interfaces
{
    public interface IDiscountRepository
    {
        IEnumerable<IDiscount> GetDiscounts(); 
    }
}

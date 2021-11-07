using ShoppingBasketTest.Interfaces;
using ShoppingBasketTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketTest.Discounts
{
    public class BuyXGetXFreeDiscount : IDiscount
    {
        private readonly int _totalItemsRequired;
        private readonly int _countForFree;
        private readonly Product _product;

        public BuyXGetXFreeDiscount(Product product, int countToQualify, int countForFree)
        {
            _totalItemsRequired = countToQualify + countForFree;
            _countForFree = countForFree;
            _product = product;
        }

        public bool TryApplyDiscount(List<ShoppingBasketItem> items, out DiscountResult result)
        {
            // get the matching items
            var matchingItems = items.Where(i => i.ProductId == _product.Id);
            // check if we have enough matching items
            if (matchingItems.Count() >= _totalItemsRequired) {

                // calculate discount amount and return the items we applied the discount to
                result = new DiscountResult(_product.Price * _countForFree, matchingItems.Take(_totalItemsRequired));
                return true;
            }

            result = null;
            return false;
        }
    }
}

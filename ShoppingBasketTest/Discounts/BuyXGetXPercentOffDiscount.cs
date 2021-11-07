using ShoppingBasketTest.Interfaces;
using ShoppingBasketTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasketTest.Discounts
{
    public class BuyXGetXPercentOffDiscount : IDiscount
    {
        private readonly Product _productToQualify;
        private readonly int _productToQualifyCount;
        private readonly Product _productForDiscount;
        private readonly int _percentage;

        public BuyXGetXPercentOffDiscount(Product productToQualify, int productToQualifyCount, Product productForDiscount, int percentage)
        {
            if (percentage < 0 || percentage > 100) throw new ArgumentOutOfRangeException("Percentage must be between 0 and 100");

            _productToQualify = productToQualify;
            _productToQualifyCount = productToQualifyCount;
            _productForDiscount = productForDiscount;
            _percentage = percentage;
        }

        public bool TryApplyDiscount(List<ShoppingBasketItem> items, out DiscountResult result)
        {
            var qualifyingProducts = items.Where(i => i.ProductId == _productToQualify.Id);
            var discountProduct = items.FirstOrDefault(i => i.ProductId == _productForDiscount.Id);

            if (qualifyingProducts.Count() >= _productToQualifyCount && discountProduct != null)
            {
                var affectedItems = qualifyingProducts.Take(_productToQualifyCount).ToList();
                affectedItems.Add(discountProduct);

                var discount = Math.Round(_productForDiscount.Price * (_percentage / 100m), 0);

                result = new DiscountResult((int)discount, affectedItems);

                return true;
            }

            result = null;
            return false;
        }
    }
}

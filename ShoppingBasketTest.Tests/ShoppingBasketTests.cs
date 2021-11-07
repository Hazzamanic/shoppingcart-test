using FluentAssertions;
using Moq;
using ShoppingBasketTest.Discounts;
using ShoppingBasketTest.Interfaces;
using ShoppingBasketTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingBasketTest.Tests
{
    public class ShoppingBasketTests
    {
        private readonly Product PRODUCT_BUTTER = new Product("butter", "butter", 80);
        private readonly Product PRODUCT_MILK = new Product("milk", "milk", 115);
        private readonly Product PRODUCT_BREAD = new Product("bread", "bread", 100);

        private readonly IDiscount DISCOUNT_TWO;

        private readonly Mock<IDiscountRepository> _discountRepository = new Mock<IDiscountRepository>();

        private readonly ShoppingBasket _sut;

        public ShoppingBasketTests()
        {
            DISCOUNT_TWO = new BuyXGetXFreeDiscount(PRODUCT_MILK, 3, 1);

            _discountRepository.Setup(dr => dr.GetDiscounts()).Returns(new List<IDiscount> { DISCOUNT_TWO });

            _sut = new ShoppingBasket(_discountRepository.Object);
            
        }

        [Theory]
        [InlineData(1, 1, 1, 295)] // no discounts
        [InlineData(2, 0, 2, 310)] // discount one applied
        [InlineData(0, 4, 0, 345)] // discount two applied
        [InlineData(2, 1, 8, 900)] // both discounts applied
        public void Basket_returns_correct_total_for_given_items(int butter, int milk, int bread, int total)
        {
            _sut.Add(PRODUCT_BUTTER, butter);
            _sut.Add(PRODUCT_MILK, milk);
            _sut.Add(PRODUCT_BREAD, bread);

            _sut.Total.Should().Be(total);
        }
    }
}

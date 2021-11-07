using FluentAssertions;
using ShoppingBasketTest.Discounts;
using ShoppingBasketTest.Interfaces;
using ShoppingBasketTest.Models;
using Xunit;

namespace ShoppingBasketTest.Tests.Discounts
{
    public class BuyXGetXFreeDiscountTests : DiscountTestsBase
    {
        private IDiscount _sut;
        private int COUNT = 4;
        private int FREE_COUNT = 2;
        private int TOTAL_REQUIRED_COUNT = 6;

        public BuyXGetXFreeDiscountTests()
        {
            _sut = new BuyXGetXFreeDiscount(PRODUCT_A, COUNT, FREE_COUNT);
        }

        [Fact]
        public void When_basket_contains_enough_products_correct_discount_applied()
        {
            var items = GetItems(PRODUCT_A, TOTAL_REQUIRED_COUNT);

            var isApplied = _sut.TryApplyDiscount(items, out var result);

            isApplied.Should().BeTrue();
            result.Amount.Should().Be(200);
        }

        [Fact]
        public void When_basket_contains_more_than_enough_products_only_required_products_returned()
        {
            var items = GetItems(PRODUCT_A, 10);

            _sut.TryApplyDiscount(items, out var result);

            result.Items.Should().HaveCount(TOTAL_REQUIRED_COUNT);
        }

        [Fact]
        public void When_basket_does_not_contain_enough_products_no_discount_applied()
        {
            var items = GetItems(PRODUCT_A, 5);

            var isApplied = _sut.TryApplyDiscount(items, out var result);

            isApplied.Should().BeFalse();
        }

        [Fact]
        public void When_basket_does_not_contain_enough_of_product_no_discount_applied()
        {
            var items = GetItems(PRODUCT_A, 5);
            items.Add(new ShoppingBasketItem(PRODUCT_B));
            items.Add(new ShoppingBasketItem(PRODUCT_B));

            var isApplied = _sut.TryApplyDiscount(items, out var result);

            isApplied.Should().BeFalse();
        }
    }
}

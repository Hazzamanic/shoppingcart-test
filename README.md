# Shopping Basket Test


## Requirements

 - .NET Core 3.1 (to run the tests)

## Build

```
dotnet build
dotnet test
```

## Comments

I kept the design simple. Shopping baskets are provided with an interface that will give them all the discounts so it can then apply arbitrary discounts to the basket. I did not build a concrete implementation but just mocked it for the tests. You can add one or more Products to a ShoppingBasket, which are stored as ShoppingBasketItems. Total is a property of ShoppingBasket.

Overall I spent about 2 hours coding this, with about 15 minutes of pacing around thinking about how I'd build it.

Things I'm not particularly happy with:

 - My implementation of the percentage discount is quite naive, and while it fits the specs it will fail if the product getting the discount is the same as the products required to achieve said discount
 - I didn't finish writing test coverage, but did try to show how I would structure and write tests
 - I'm actually not a fan of out parameters in general, but it was easier to implement than rolling the result of whether a discount was applied into the DiscountResult class.
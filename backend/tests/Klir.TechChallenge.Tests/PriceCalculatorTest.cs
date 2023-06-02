using Klir.TechChallenge.Application.Services;
using Klir.TechChallenge.Domain.AggregateModel;
using Klir.TechChallenge.Infrastructure.Repository;

namespace Klir.TechChallenge.Tests;

public class PriceCalculatorTest
{
    private readonly ICartService _cartService;

    public PriceCalculatorTest()
    {
        var productRepository = new ProductRepository();
        _cartService = new CartService(productRepository);
    }

    [Fact]
    public async void CartItemWithBuyOneGetOneFree_Quantity1_ShouldReturnWithoutPromotionPrice()
    {
        var productItem = new CartItem() { Id = 1, ProductId = 1, UnitPrice = 20, Quantity = 1 };
        var item = await _cartService.CalculateTotalPriceAsync(productItem);
        Assert.Equal(20m, item.TotalPrice);
    }
}
using Klir.TechChallenge.Application.Services;
using Klir.TechChallenge.Domain.AggregateModel;
using Klir.TechChallenge.Domain.Interfaces;
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

    [Fact]
    public async void CartItemWithBuyOneGetOneFree_Quantity2_ShouldReturnPromotionPrice1()
    {
        var productItem = new CartItem() { Id = 1, ProductId = 1, UnitPrice = 20, Quantity = 2 };
        var item = await _cartService.CalculateTotalPriceAsync(productItem);

        Assert.Equal(20m, item.TotalPrice);
    }

    [Fact]
    public async void CartItemWithBuyOneGetOneFree_Quantity3_ShouldReturnPromotionPrice2()
    {
        var productItem = new CartItem() { Id = 1, ProductId = 1, UnitPrice = 20, Quantity = 3 };
        var item = await _cartService.CalculateTotalPriceAsync(productItem);

        Assert.Equal(40m, item.TotalPrice);
    }

    [Fact]
    public async void CartItemWith3For10_Quantity1_ShouldReturnWithoutPromotionPrice1()
    {
        var productItem = new CartItem() { Id = 1, ProductId = 2, UnitPrice = 4, Quantity = 1 };
        var item = await _cartService.CalculateTotalPriceAsync(productItem);

        Assert.Equal(4m, item.TotalPrice);
    }

    [Fact]
    public async void CartItemWith3For10_Quantity1_ShouldReturnWithoutPromotionPrice2()
    {
        var productItem = new CartItem() { Id = 1, ProductId = 4, UnitPrice = 4, Quantity = 1 };
        var item = await _cartService.CalculateTotalPriceAsync(productItem);

        Assert.Equal(4m, item.TotalPrice);
    }

    [Fact]
    public async void CartItemWith3For10_Quantity3_ShouldReturnPromotionPrice3()
    {
        var productItem = new CartItem() { Id = 1, ProductId = 2, UnitPrice = 4, Quantity = 3 };
        var item = await _cartService.CalculateTotalPriceAsync(productItem);

        Assert.Equal(10m, item.TotalPrice);
    }


    [Fact]
    public async void CartItemWith3For10_Quantity3_ShouldReturnPromotionPrice4()
    {
        var productItem = new CartItem() { Id = 1, ProductId = 4, UnitPrice = 4, Quantity = 3 };
        var item = await _cartService.CalculateTotalPriceAsync(productItem);

        Assert.Equal(10m, item.TotalPrice);
    }


    [Fact]
    public async void CartItemWith3For10_Quantity4_ShouldReturnPromotionPrice4()
    {
        var productItem = new CartItem() { Id = 1, ProductId = 2, UnitPrice = 4, Quantity = 4 };
        var item = await _cartService.CalculateTotalPriceAsync(productItem);

        Assert.Equal(14m, item.TotalPrice);
    }


    [Fact]
    public async void CartItemWith3For10_Quantity4_ShouldReturnPromotionPrice5()
    {
        var productItem = new CartItem() { Id = 1, ProductId = 4, UnitPrice = 4, Quantity = 4 };
        var item = await _cartService.CalculateTotalPriceAsync(productItem);

        Assert.Equal(14m, item.TotalPrice);
    }


    [Fact]
    public async void CartItemWithNoPromotion_Quantity1_ShouldReturnQuntityProductPrice1()
    {
        var productItem = new CartItem() { Id = 1, ProductId = 3, UnitPrice = 2, Quantity = 1 };
        var item = await _cartService.CalculateTotalPriceAsync(productItem);

        Assert.Equal(2m, item.TotalPrice);
    }

    [Fact]
    public async void CartItemWithNoPromotion_Quantity4_ShouldReturnQuntityProductPrice2()
    {
        var productItem = new CartItem() { Id = 1, ProductId = 3, UnitPrice = 2, Quantity = 4 };
        var item = await _cartService.CalculateTotalPriceAsync(productItem);

        Assert.Equal(8m, item.TotalPrice);
    }
}
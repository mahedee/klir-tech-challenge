using Klir.TechChallenge.Domain.AggregateModel;
using Klir.TechChallenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Application.Services
{
    public class CartService : ICartService
    {
        IProductRepository _productRepository;
        public CartService(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }

        public async Task<CartItem> CalculateTotalPriceAsync(CartItem cartItem)
        {
            CartItem _cartItem = cartItem;
            _cartItem.TotalPrice = cartItem.UnitPrice * cartItem.Quantity;

            // Get product's promotion details
            ProductPromotion productPromotion = await _productRepository.GetProductPromotion(cartItem.ProductId);

            // Apply logic here for product promotion



            return _cartItem;
        }
    }
}

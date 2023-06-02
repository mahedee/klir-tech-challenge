using Klir.TechChallenge.Domain.AggregateModel;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Infrastructure.Repository;
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
            Product product = _productRepository.GetProduct(_cartItem.ProductId);
            _cartItem.UnitPrice = product.Price;
            _cartItem.TotalPrice = _cartItem.UnitPrice * _cartItem.Quantity;

            // Get product's promotion details
            ProductPromotion productPromotion = await _productRepository.GetProductPromotion(_cartItem.ProductId);

            // Apply logic here for product promotion


            if (productPromotion != null)
            {
                // Apply Promotion
                IPromotion promotion = PromotionFactory.GetPromotion((PromotionType)productPromotion.PromotionId);
                _cartItem = promotion.Apply(_cartItem);
            }

            return _cartItem;
        }
    }
}

using Klir.TechChallenge.Domain.AggregateModel;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Infrastructure.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return FakeContext.Products.ToList();
        }

        public async Task<ProductPromotion> GetProductPromotion(int productId)
        {
            return FakeContext.ProductPromotions.FirstOrDefault(p => p.ProductId == productId);
        }

        public string GetPromotionTitle(int promotionId)
        {
            string promotionTitle = FakeContext.Promotions.FirstOrDefault(p => p.Id == promotionId).PromotionTitle;
            return promotionTitle;
        }
    }
}

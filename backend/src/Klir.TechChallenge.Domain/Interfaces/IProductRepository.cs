using Klir.TechChallenge.Domain.AggregateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductPromotion> GetProductPromotion(int productId);
        Task<IEnumerable<Product>> GetAllAsync();
        string GetPromotionTitle(int promotionId);
        Product GetProduct(int productId);
    }
}

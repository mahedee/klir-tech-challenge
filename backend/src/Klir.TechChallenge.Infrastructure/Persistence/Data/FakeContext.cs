using Klir.TechChallenge.Domain.AggregateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Infrastructure.Persistence.Data
{
    public static class FakeContext
    {
        public static IEnumerable<ProductPromotion> ProductPromotions
        {
            get
            {
                var items = new List<ProductPromotion>();

                items.Add(new ProductPromotion() { Id = 1, ProductId = 1, PromotionId = 1 });
                items.Add(new ProductPromotion() { Id = 2, ProductId = 2, PromotionId = 2 });
                items.Add(new ProductPromotion() { Id = 3, ProductId = 4, PromotionId = 2 });

                return items;
            }
        }

    }
}

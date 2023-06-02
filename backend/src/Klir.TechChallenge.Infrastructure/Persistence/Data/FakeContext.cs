using Klir.TechChallenge.Domain.AggregateModel;
using Klir.TechChallenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Infrastructure.Persistence.Data
{
    public static class FakeContext
    {
        public static IEnumerable<Product> Products
        {
            get
            {
                var items = new List<Product>();

                items.Add(new Product() { Id = 1, Name = "Product A", Price = 20m });
                items.Add(new Product() {Id= 2, Name = "Product B", Price = 4m });
                items.Add(new Product() { Id = 3, Name = "Product C", Price = 2m });
                items.Add(new Product() { Id = 4, Name = "Product D", Price = 4m });
                return items;
            }
        }

        public static IEnumerable<Promotion> Promotions
        {
            get
            {
                var items = new List<Promotion>();
                //items.Add(new Promotion() { Id = 0, PromotionType = PromotionType.None});
                items.Add(new Promotion() { Id = 1, PromotionType = PromotionType.ByOneGetOneFree, PromotionTitle = "Buy 1 Get 1 Free" });
                items.Add(new Promotion() { Id = 2, PromotionType = PromotionType.ThreeForTenEuro, PromotionTitle = "3 for 10 Euro" });
                return items;
            }
        }

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

using Klir.TechChallenge.Domain.AggregateModel;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Infrastructure.Repository
{
    public static class PromotionFactory
    {
        // Configure promotions centrally
        public static Dictionary<PromotionType, IPromotion> Promotions
        {
            get
            {
                var promotionDict = new Dictionary<PromotionType, IPromotion>();
                promotionDict.Add(PromotionType.ByOneGetOneFree, new BuyOneGetOneFree());
                return promotionDict;
            }
        }

        // Get promotion by Promotion Type
        public static IPromotion GetPromotion(PromotionType promotionType)
        {
            IPromotion promotion;
            Promotions.TryGetValue(promotionType, out promotion);

            if (promotion == null)
            {
                throw new Exception("Not found: no promotion is configured");
            }

            return promotion;
        }
    }
}

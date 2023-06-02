using Klir.TechChallenge.Domain.AggregateModel;
using Klir.TechChallenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Domain.Services
{
    // Todo: move to application -> services
    public class BuyOneGetOneFree : IPromotion
    {
        // Price calculation for BuyOneGetOneFree
        public CartItem Apply(CartItem item)
        {

            if (item.Quantity == 1)
            {
                return item;
            }

            int freeQuantity = item.Quantity / 2; // quotient 
            item.TotalPrice = item.UnitPrice * (item.Quantity - freeQuantity);
            return item;
        }
    }
}

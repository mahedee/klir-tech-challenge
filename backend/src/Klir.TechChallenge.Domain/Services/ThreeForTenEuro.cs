using Klir.TechChallenge.Domain.AggregateModel;
using Klir.TechChallenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Domain.Services
{
    public class ThreeForTenEuro : IPromotion
    {
        // Calculate total for promotion 3 for ten euro
        // return CartItem
        public CartItem Apply(CartItem item)
        {
            if (item.Quantity < 3)
                return item;

            int quantityForPromotion = item.Quantity / 3; // quotient 
            int quantityForFullPayment = item.Quantity % 3; // reminder

            item.TotalPrice = (quantityForPromotion * 10) + (quantityForFullPayment * item.UnitPrice);

            return item;
        }
    }
}

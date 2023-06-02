using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Domain.AggregateModel
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public bool IsPromotion { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

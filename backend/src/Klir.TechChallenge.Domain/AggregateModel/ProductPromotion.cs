using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Domain.AggregateModel
{
    public class ProductPromotion
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PromotionId { get; set; }
        public bool IsActive { get; set; }
    }
}

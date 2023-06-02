using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Domain.AggregateModel
{
    public class Promotion : BaseEntity<int>
    {
        public PromotionType PromotionType { get; set; }

        public string PromotionTitle { get; set; }
    }
}

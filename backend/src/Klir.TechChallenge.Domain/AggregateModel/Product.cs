using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Domain.AggregateModel
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }

        // Unit price
        public decimal Price { get; set; }
    }
}

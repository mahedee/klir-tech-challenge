using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Domain.AggregateModel
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        // Required for soft delete

        // public bool IsDeleted { get; set; } = false;

        // Auditable Entity should added here
        // Created by, updated by etc.

    }
}

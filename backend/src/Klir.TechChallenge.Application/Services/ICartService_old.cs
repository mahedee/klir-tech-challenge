using Klir.TechChallenge.Domain.AggregateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Application.Services
{
    public interface ICartService_old
    {
        Task<CartItem> CalculateTotalPriceAsync(CartItem cartItem);
    }
}

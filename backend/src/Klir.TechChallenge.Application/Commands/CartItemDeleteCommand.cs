using Klir.TechChallenge.Domain.AggregateModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Application.Commands
{
    public class CartItemDeleteCommand : IRequest<List<CartItem>>
    {
        public int Id { get; private set; }

        public CartItemDeleteCommand(int id)
        {
            Id = id;
        }

    }
}

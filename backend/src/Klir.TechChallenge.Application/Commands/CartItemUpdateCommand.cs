using Klir.TechChallenge.Domain.AggregateModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Application.Commands
{
    public class CartItemUpdateCommand : IRequest<CartItem>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        //public bool IsPromotion { get; set; }
        //public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        //public decimal TotalPrice { get; set; }
    }
}

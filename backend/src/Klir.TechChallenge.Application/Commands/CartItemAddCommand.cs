using Klir.TechChallenge.Domain.AggregateModel;
using MediatR;

namespace Klir.TechChallenge.Application.Commands
{
    // Todo: should refactor based on UI
    // Only ProductId and Quantity is necessary
    public class CartItemAddCommand : IRequest<List<CartItem>>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public bool IsPromotion { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

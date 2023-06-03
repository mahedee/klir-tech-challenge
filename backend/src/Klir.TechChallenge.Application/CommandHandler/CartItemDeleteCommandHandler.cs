using Klir.TechChallenge.Application.Commands;
using Klir.TechChallenge.Domain.AggregateModel;
using Klir.TechChallenge.Domain.Interfaces;
using MediatR;

namespace Klir.TechChallenge.Application.CommandHandler
{
    public class CartItemDeleteCommandHandler : IRequestHandler<CartItemDeleteCommand, List<CartItem>>
    {

        private readonly ICartRepository _cartRepository;
        public CartItemDeleteCommandHandler(
            ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<List<CartItem>> Handle(CartItemDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _cartRepository.RemoveItemFromCart(request.Id);
        }
    }
}

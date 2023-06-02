using Klir.TechChallenge.Application.Commands;
using Klir.TechChallenge.Domain.AggregateModel;
using Klir.TechChallenge.Domain.Interfaces;
using MediatR;

namespace Klir.TechChallenge.Application.CommandHandler
{
    public class CartItemAddCommandHandler : IRequestHandler<CartItemAddCommand, List<CartItem>>
    {

        private readonly ICartRepository _cartRepository;
        private readonly ICartService _cartService;
        public CartItemAddCommandHandler(ICartRepository cartRepository,
            ICartService cartService)
        {
            _cartRepository = cartRepository;
            _cartService = cartService;

        }

        public async Task<List<CartItem>> Handle(CartItemAddCommand request, CancellationToken cancellationToken)
        {
            var cartItem = new CartItem
            {
                //Id = request.Id,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                //UnitPrice = request.UnitPrice,
                //TotalPrice = request.UnitPrice * request.Quantity, // Initally total price will be unit price * quantity
            };

            List<CartItem> userCart = null;

            cartItem = await _cartService.CalculateTotalPriceAsync(cartItem);

            userCart = await _cartRepository.AddItemToCart(cartItem);

            return userCart;

        }
    }
}

using Klir.TechChallenge.Application.Commands;
using Klir.TechChallenge.Domain.AggregateModel;
using Klir.TechChallenge.Domain.Interfaces;
using MediatR;

namespace Klir.TechChallenge.Application.CommandHandler
{

    public class CartItemUpdateCommandHandler : IRequestHandler<CartItemUpdateCommand, CartItem>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartService _cartService;
        public CartItemUpdateCommandHandler(
            ICartRepository cartRepository,
            ICartService cartService)
        {
            _cartRepository = cartRepository;
            _cartService = cartService;

        }

        public async Task<CartItem> Handle(CartItemUpdateCommand request, CancellationToken cancellationToken)
        {
            var cartItem = new CartItem
            {
                Id = request.Id, // Cart id
                ProductId = request.ProductId,
                //IsPromotion = request.IsPromotion, // instead should use promotion id. id = 0 means no promotion
                Quantity = request.Quantity,
                //UnitPrice = request.UnitPrice,
                //TotalPrice = request.UnitPrice * request.Quantity, // Initally total price will be unit price * quantity
            };

            CartItem updatedCartItem = new CartItem();

            cartItem = await _cartService.CalculateTotalPriceAsync(cartItem);

            updatedCartItem = await _cartRepository.UpdateCartItem(cartItem);

            return updatedCartItem;
        }
    }


}

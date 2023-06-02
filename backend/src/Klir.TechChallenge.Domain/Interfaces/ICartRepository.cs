using Klir.TechChallenge.Domain.AggregateModel;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface ICartRepository
    {
        Task<List<CartItem>> AddItemToCart(CartItem cartItem);
        Task<CartItem> UpdateCartItem(CartItem cartItem);
        Task<List<CartItem>> RemoveItemFromCart(int itemId);
        Task<List<CartItem>> GetUsersCart();
    }
}

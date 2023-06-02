using Klir.TechChallenge.Domain.AggregateModel;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Infrastructure.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Infrastructure.Repository
{

    public class CartRepository : ICartRepository
    {
        public async Task<List<CartItem>> AddItemToCart(CartItem cartItem)
        {
            cartItem.Id = FakeContext.UsersCart.Count + 1;
            FakeContext.UsersCart.Add(cartItem);
            return FakeContext.UsersCart;
        }

        public async Task<CartItem> UpdateCartItem(CartItem cartItem)
        {
            int index = FakeContext.UsersCart.FindIndex(p => p.Id == cartItem.Id);

            if (index != -1)
            {
                FakeContext.UsersCart[index] = cartItem;
            }

            return cartItem;
        }

        public async Task<List<CartItem>> RemoveItemFromCart(int itemId)
        {
            int index = FakeContext.UsersCart.FindIndex(p => p.Id == itemId);
            FakeContext.UsersCart.RemoveAt(index);
            return FakeContext.UsersCart;
        }

        public async Task<List<CartItem>> GetUsersCart()
        {
            return FakeContext.UsersCart;
        }
    }
}

using Klir.TechChallenge.Application.DTOs;
using Klir.TechChallenge.Application.Queries;
using Klir.TechChallenge.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Application.QueryHandler
{
    public class GetUsersCartQueryHandler : IRequestHandler<GetUsersCartQuery, List<CartItemResponseDTO>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        public GetUsersCartQueryHandler(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }


        public async Task<List<CartItemResponseDTO>> Handle(GetUsersCartQuery request, CancellationToken cancellationToken)
        {
            var result = await _cartRepository.GetUsersCart();
            List<CartItemResponseDTO> usersCart = new List<CartItemResponseDTO>();
            foreach (var item in result)
            {
                string productName = _productRepository.GetProduct(item.ProductId).Name;
                usersCart.Add(new CartItemResponseDTO()
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    ProductName = productName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.TotalPrice,
                    IsPromotion = item.IsPromotion
                });
            }
            return usersCart;
        }
    }
}

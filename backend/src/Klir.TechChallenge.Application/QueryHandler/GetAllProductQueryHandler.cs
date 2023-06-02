using Klir.TechChallenge.Application.DTOs;
using Klir.TechChallenge.Application.Queries;
using Klir.TechChallenge.Domain.AggregateModel;
using Klir.TechChallenge.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Application.QueryHandler
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductResponseDTO>>
    {

        private readonly IProductRepository _productRepository;

        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<List<ProductResponseDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetAllAsync();
            //var productList = _mapper.Map<List<ProductResponseDTO>>(result);
            //return productList;

            var productResponseDTOs = new List<ProductResponseDTO>();

            foreach (var product in result)
            {
                string promotionTitel = string.Empty;
                ProductPromotion productPromotion = await _productRepository.GetProductPromotion(product.Id);

                if (productPromotion != null)
                {
                    int promotionId = productPromotion.PromotionId;
                    promotionTitel = _productRepository.GetPromotionTitle(promotionId);
                }

                productResponseDTOs.Add(new ProductResponseDTO() { Id = product.Id, Name = product.Name, Price = product.Price, PromotionTitle = promotionTitel });
            }

            return productResponseDTOs;
        }
    }
}

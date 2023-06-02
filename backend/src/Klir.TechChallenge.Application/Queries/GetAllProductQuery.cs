using Klir.TechChallenge.Application.DTOs;
using MediatR;

namespace Klir.TechChallenge.Application.Queries
{
    public class GetAllProductQuery : IRequest<List<ProductResponseDTO>>
    {

    }
}

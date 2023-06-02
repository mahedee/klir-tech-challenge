using Klir.TechChallenge.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Application.Queries
{
    public class GetUsersCartQuery : IRequest<List<CartItemResponseDTO>>
    {

    }
}

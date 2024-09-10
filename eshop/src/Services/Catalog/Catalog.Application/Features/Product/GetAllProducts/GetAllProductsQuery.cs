using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.GetAllProducts
{
    public record GetAllProductResponse(int Id, string Name, string? Description, decimal? Price, string? ImageUrl);
    public class GetAllProductsQuery : IRequest<IEnumerable<GetAllProductResponse>>
    {

    }
}

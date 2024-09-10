using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.GetProductById
{

    public record GetProductByIdResponse(int Id, string Name, string? Description, decimal? Price, string? ImageUrl);
    public record GetProductByIdQuery(int Id) : IRequest<GetProductByIdResponse>;

}

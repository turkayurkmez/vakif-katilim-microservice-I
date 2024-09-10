using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.SearchProductByName
{

    public record SearchProductResponse(int Id, string Name, string? Description, decimal? Price, string? ImageUrl);
    public record SearchProductsByNameResponse(IEnumerable<SearchProductResponse> Responses);
    public record SearhProductsByNameQuery(string Name) : IRequest<SearchProductsByNameResponse>;
   
}

using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.GetProductsByCategory
{
    public record GetProductsByCategoryResponse(int Id, string Name, string? Description, decimal? Price, string? ImageUrl);
    public record GetProductsByCategoryQuery(int CategoryId) : 
                                                        IRequest<IEnumerable<GetProductsByCategoryResponse>>;
    
}

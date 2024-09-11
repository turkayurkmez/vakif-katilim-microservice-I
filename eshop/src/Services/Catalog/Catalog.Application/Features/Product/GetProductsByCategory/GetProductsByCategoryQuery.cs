using MediatR;

namespace Catalog.Application.Features.Product.GetProductsByCategory
{
    public record GetProductsByCategoryResponse(int Id, string Name, string? Description, decimal? Price, string? ImageUrl);
    public record GetProductsByCategoryQuery(int CategoryId) :
                                                        IRequest<IEnumerable<GetProductsByCategoryResponse>>;

}

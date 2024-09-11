using MediatR;

namespace Catalog.Application.Features.Product.GetAllProducts
{
    public record GetAllProductResponse(int Id, string Name, string? Description, decimal? Price, string? ImageUrl);
    public class GetAllProductsQuery : IRequest<IEnumerable<GetAllProductResponse>>
    {

    }
}

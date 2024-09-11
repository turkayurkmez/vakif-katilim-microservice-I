using MediatR;

namespace Catalog.Application.Features.Product.GetProductById
{

    public record GetProductByIdResponse(int Id, string Name, string? Description, decimal? Price, string? ImageUrl);
    public record GetProductByIdQuery(int Id) : IRequest<GetProductByIdResponse>;

}

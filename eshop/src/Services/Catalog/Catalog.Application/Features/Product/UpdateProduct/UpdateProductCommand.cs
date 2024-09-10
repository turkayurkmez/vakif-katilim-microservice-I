using MediatR;

namespace Catalog.Application.Features.Product.UpdateProduct
{
    public record UpdateProductCommand(int Id, string Name, string? Description, decimal? Price, string? ImageUrl) : IRequest;
  
}

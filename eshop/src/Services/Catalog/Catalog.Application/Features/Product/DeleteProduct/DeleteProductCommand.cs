using MediatR;

namespace Catalog.Application.Features.Product.DeleteProduct
{
    public record DeleteProductCommand(int Id) : IRequest;

}

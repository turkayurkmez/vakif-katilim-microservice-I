using MediatR;

namespace Catalog.Application.Features.Product.ChangeProductPrice
{

    public record ChangeProductPriceCommand(int Id, decimal NewPrice) : IRequest;

}

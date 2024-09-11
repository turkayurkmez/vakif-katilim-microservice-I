using Catalog.Application.Contracts.Repositories;
using Mapster;
using MediatR;

namespace Catalog.Application.Features.Product.GetProductById
{
    public class GetProductByIdHandler(IProductRepository repository) : IRequestHandler<GetProductByIdQuery, GetProductByIdResponse>
    {
        public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await repository.GetAsync(request.Id);
            var response = product.Adapt<GetProductByIdResponse>();
            return response;
        }
    }
}

using Catalog.Application.Contracts.Repositories;
using Mapster;
using MediatR;

namespace Catalog.Application.Features.Product.GetProductsByCategory
{
    public class GetProductsByCategoryHandler(IProductRepository repository) : IRequestHandler<GetProductsByCategoryQuery, IEnumerable<GetProductsByCategoryResponse>>
    {
        public async Task<IEnumerable<GetProductsByCategoryResponse>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = await repository.GetProductsByCategory(request.CategoryId);
            var result = response.Adapt<IEnumerable<GetProductsByCategoryResponse>>();
            return result;

        }
    }
}

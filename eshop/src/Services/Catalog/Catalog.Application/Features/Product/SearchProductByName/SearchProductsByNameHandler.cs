using Catalog.Application.Contracts.Repositories;
using Mapster;
using MediatR;

namespace Catalog.Application.Features.Product.SearchProductByName
{
    internal class SearchProductsByNameHandler(IProductRepository repository) : IRequestHandler<SearhProductsByNameQuery, SearchProductsByNameResponse>
    {
        public async Task<SearchProductsByNameResponse> Handle(SearhProductsByNameQuery request, CancellationToken cancellationToken)
        {
            var products = await repository.SearchByName(request.Name);
            var searchedResult = products.Adapt<IEnumerable<SearchProductResponse>>();
            var response = new SearchProductsByNameResponse(searchedResult);
            return response;

        }
    }
}

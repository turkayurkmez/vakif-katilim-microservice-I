using Catalog.Application.Contracts.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.GetAllProducts
{
    public class GetAllProductsHandler(IProductRepository repository) : IRequestHandler<GetAllProductsQuery, IEnumerable<GetAllProductResponse>>
    {
        public async Task<IEnumerable<GetAllProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            // TODO 1: Veritabanına giderek, tüm ürünleri çek.,
            var products = await repository.GetAllAsync();
            // TODO 2: Bu ürünleri, IEnumerable<GetAllProductResponse> tipine dönüştürerek döndür.
            //var result = products.Select(p => new GetAllProductResponse
            //(
            //     Id: p.Id,
            //     Name: p.Name,
            //     Description: p.Description,
            //     Price: p.Price,
            //     ImageUrl: p.ImageUrl
            //));

            var result = products.Adapt<IEnumerable<GetAllProductResponse>>();

            return result;

        }
    }
}

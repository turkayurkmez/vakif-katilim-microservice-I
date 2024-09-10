using Catalog.Application.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.ChangeProductPrice
{
    internal class ChangeProductPriceCommandHandler(IProductRepository productRepository) : IRequestHandler<ChangeProductPriceCommand>
    {
        public async Task Handle(ChangeProductPriceCommand request, CancellationToken cancellationToken)
        {
            var existingProduct =await  productRepository.GetAsync(request.Id);
            if (existingProduct != null) {
                existingProduct.Price = request.NewPrice;
            }
            await productRepository.UpdateAsync(existingProduct);

        }
    }
}

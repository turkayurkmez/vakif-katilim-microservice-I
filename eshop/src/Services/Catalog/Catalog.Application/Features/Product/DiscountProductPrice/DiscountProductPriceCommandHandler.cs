using Catalog.Application.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.DiscountProductPrice
{

    public record DiscountProductPriceCommand(int Id, decimal Rate) : IRequest<DiscountProductPriceResponse>;
    public record DiscountProductPriceResponse(int Id, decimal? OldPrice, decimal? NewPrice);

    internal class DiscountProductPriceCommandHandler(IProductRepository productRepository) : IRequestHandler<DiscountProductPriceCommand, DiscountProductPriceResponse>
    {
        public async Task<DiscountProductPriceResponse> Handle(DiscountProductPriceCommand request, CancellationToken cancellationToken)
        {
            
            var product = await productRepository.GetAsync(request.Id);
            var oldPrice = product.Price;

            product.Price = Math.Round((decimal)product.Price * (1 - request.Rate));
            var newPrice = product.Price;   
           
            await productRepository.UpdateAsync(product);
            return new DiscountProductPriceResponse(product.Id, oldPrice, newPrice);
        }
    }


}

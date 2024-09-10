using Catalog.Application.Contracts.Repositories;
using Catalog.Domain;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.UpdateProduct
{
    internal class UpdateProductCommandHandler(IProductRepository repository) : IRequestHandler<UpdateProductCommand>
    {
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Domain.Product>();
            await repository.UpdateAsync(product);

        }
    }
  
}

using Catalog.Application.Contracts.Repositories;
using Mapster;
using MediatR;

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

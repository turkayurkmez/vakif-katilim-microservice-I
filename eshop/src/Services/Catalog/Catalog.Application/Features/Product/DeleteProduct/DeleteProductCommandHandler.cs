using Catalog.Application.Contracts.Repositories;
using MediatR;

namespace Catalog.Application.Features.Product.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository repository) : IRequestHandler<DeleteProductCommand>
    {
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           await repository.DeleteAsync(request.Id);
        }
    }

}

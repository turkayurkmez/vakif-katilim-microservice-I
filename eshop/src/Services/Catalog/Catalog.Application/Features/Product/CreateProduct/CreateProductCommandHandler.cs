﻿using Catalog.Application.Contracts.Repositories;
using Mapster;
using MediatR;

namespace Catalog.Application.Features.Product.CreateProduct
{
    internal class CreateProductCommandHandler(IProductRepository repository) : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Domain.Product>();
            await repository.CreateAsync(product);
            return new CreateProductCommandResponse(product.Id);

        }
    }
}

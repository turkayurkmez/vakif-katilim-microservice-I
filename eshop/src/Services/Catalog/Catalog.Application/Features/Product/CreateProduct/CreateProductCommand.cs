using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Features.Product.CreateProduct
{
    public record CreateProductCommandResponse(int Id);
    public record CreateProductCommand([Required(ErrorMessage = "Ürün ismi belirtilmelidir")] string Name, string? Description, decimal? Price, string? ImageUrl, int? Stock, int? CategoryId) : IRequest<CreateProductCommandResponse>;


}

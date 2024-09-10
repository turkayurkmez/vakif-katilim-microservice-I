using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.CreateProduct
{
    public record CreateProductCommandResponse(int Id);
    public record CreateProductCommand([Required(ErrorMessage ="Ürün ismi belirtilmelidir")]string Name, string? Description, decimal? Price, string? ImageUrl, int? Stock,  int? CategoryId ): IRequest<CreateProductCommandResponse>;

   
}

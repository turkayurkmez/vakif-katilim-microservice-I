using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.ChangeProductPrice
{

    public record ChangeProductPriceCommand (int Id, decimal NewPrice):IRequest;
  
}

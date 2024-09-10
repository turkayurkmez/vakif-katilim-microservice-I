﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.DeleteProduct
{
    public record DeleteProductCommand(int Id):IRequest;

}

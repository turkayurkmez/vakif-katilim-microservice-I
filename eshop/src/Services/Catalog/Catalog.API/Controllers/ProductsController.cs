using Catalog.Application.Features.Product.ChangeProductPrice;
using Catalog.Application.Features.Product.CreateProduct;
using Catalog.Application.Features.Product.DeleteProduct;
using Catalog.Application.Features.Product.DiscountProductPrice;
using Catalog.Application.Features.Product.GetAllProducts;
using Catalog.Application.Features.Product.GetProductById;
using Catalog.Application.Features.Product.GetProductsByCategory;
using Catalog.Application.Features.Product.SearchProductByName;
using Catalog.Application.Features.Product.UpdateProduct;
using eshop.MessageBus;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator, IPublishEndpoint publishEndpoint) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts()
        {
            var request = new GetAllProductsQuery();
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var request = new GetProductByIdQuery(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> Get(string name)
        {
            var request = new SearhProductsByNameQuery(name);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("category/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByCategory(int id)
        {
            var request = new GetProductsByCategoryQuery(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CreateProduct(CreateProductCommand request)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(request);
                return CreatedAtAction(nameof(Get), routeValues: new { id = response.Id }, request);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangePrice(ChangeProductPriceCommand command)
        {
            // ChangeProductPriceCommand command = new ChangeProductPriceCommand(id, price);
            try
            {
                await mediator.Send(command);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest(ModelState);
            }


        }

        [HttpPut("discount/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DiscountPrice(DiscountProductPriceCommand command)
        {
            // ChangeProductPriceCommand command = new ChangeProductPriceCommand(id, price);
            try
            {
                var response = await mediator.Send(command);
                var @event = new PriceDiscountedEvent()
                {
                    DiscountPriceCommand = new DiscountPriceCommand
                    {
                        NewPrice = response.NewPrice,
                        OldPrice = response.OldPrice,
                        ProductId = response.Id
                    }
                };

                await publishEndpoint.Publish(@event);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest(ModelState);
            }


        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateExistingProduct(int id, UpdateProductCommand updateRequest)
        {
            if (ModelState.IsValid)
            {
                await mediator.Send(updateRequest);
                return NoContent();
            }

            return BadRequest(ModelState);


        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleteCommand = new DeleteProductCommand(id);
            await mediator.Send(deleteCommand);

            return NoContent();



        }

    }
}

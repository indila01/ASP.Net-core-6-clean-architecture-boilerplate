using Boilerplate.API.Models.Products;
using Boilerplate.Business.Actions.Products;
using Boilerplate.Shared.Common.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMediator mediator;
        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<GetProductCommandResult>> GetProduct(string? productName)
        {
            var result = await mediator.Send(new GetProductCommand
            {
                ProductName = productName
            });
            return Ok(result);
        }

        [HttpPost]
        [Route("addproduct")]
        public async Task<ActionResult<ProductDto>> AddProduct([FromBody] CreateProductRequest request)
        {
            var result = await mediator.Send(new CreateProductCommand
            {
                Product = new ProductDto
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Quantity = request.Quantity,
                }
            });

            return Ok(result.Product);
        }
    }
}
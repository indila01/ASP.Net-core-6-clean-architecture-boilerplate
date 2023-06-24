using Boilerplate.Business.Actions.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.API.Controllers
{
    public class ProductController :BaseController
    {
        private readonly IMediator mediator;
        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<GetProductCommandResult>> getproducts(string? productName)
        {
            var result = await mediator.Send(new GetProductCommand
            {
                ProductName = productName
            }); 
            return Ok(result);
        }
    }
}
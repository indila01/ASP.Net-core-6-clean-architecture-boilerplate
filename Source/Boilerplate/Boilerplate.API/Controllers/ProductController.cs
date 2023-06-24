using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.API.Controllers
{
    public class ProductController :BaseController
    {

        public ProductController()
        {
        }

        [HttpGet]
        [Route("get")]
        public IActionResult getproducts() => Ok();
    }
}
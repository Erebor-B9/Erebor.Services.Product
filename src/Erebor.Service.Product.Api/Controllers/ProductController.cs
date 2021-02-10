using Erebor.Service.Product.SharedKernel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Erebor.Service.Product.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController: BaseController
    {
        public readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}

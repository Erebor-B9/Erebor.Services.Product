using Erebor.Service.Product.Core.Domain;
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
        public readonly Courier Courier;
        public ProductController(ILogger<ProductController> logger, Courier courier)
        {
            Courier = courier;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Get(CreateProductCommand command)
        {
           return Ok(Courier.Dispatch(command));
        }
    }
}

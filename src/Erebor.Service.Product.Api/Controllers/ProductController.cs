using System.Threading.Tasks;
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
        public readonly ICourier _courier;
        public ProductController(ILogger<ProductController> logger, ICourier courier)
        {
            _courier = courier;
            _logger = logger;
        }

        [HttpPost("Product")]
        public   IActionResult CreateProduct(CreateProductCommand command)
        {
           _courier.Dispatch(command);
           return  Ok();
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryCommand command)
        {
            _courier.Dispatch(command);
            return Ok();
        }
    }
}

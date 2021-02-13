using System.Threading.Tasks;
using Erebor.Service.Product.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Erebor.Service.Product.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        public readonly ILogger<CatalogController> _logger;
        private readonly IMediator _mediator;

        public CatalogController(ILogger<CatalogController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("Product")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            return  Ok(await _mediator.Send(command));
        }

        [HttpPost("Category")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("Category/Update")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("Category")]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("Category/{name}")]
        public async Task<IActionResult> GetCategory(string name)
        {
            return Ok(await _mediator.Send(new GetCategoryRequest(name)));
        }

        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _mediator.Send(new GetCategoryListRequest()));
        }
    }
}

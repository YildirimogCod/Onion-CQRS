using Application.Features.Products.Command.CreateProduct;
using Application.Features.Products.Queries;
using Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var reponse = await mediator.Send(new GetAllProductQueryRequest());
            return Ok(reponse);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}

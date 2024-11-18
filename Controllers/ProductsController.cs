using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XmlBillingSystem.BillDbContext.Models;
using XmlBillingSystem.Services;
using XmlBillingSystem.Services.Dto;

namespace XmlBillingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("get-list-of-products")]
        [Produces("application/xml")]
        public async Task<Products> GetListOfProducts()
        {
            return await _productsService.GetListOfProducts();
        }

        [HttpPost("add-or-edit-product")]
        [Consumes("application/xml")]
        public async Task<IActionResult> CreateOrUpdateProduct([FromBody] CreateProductRequest product)
        {
            if (product == null)
            {
                return BadRequest("No se ha recibido un producto válido.");
            }

            await _productsService.CreateOrUpdateProduct(product);

            return Ok(product);
        }

    }
}


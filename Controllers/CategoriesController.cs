using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XmlBillingSystem.BillDbContext.Models;
using XmlBillingSystem.Services;
using XmlBillingSystem.Services.Dto;

namespace XmlBillingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet("get-list-of-categories")]
        [Produces("application/xml")]
        public async Task<Categories> GetListOfCategories()
        {
            return await _categoriesService.GetListOfCategories();
        }

        [HttpPost("add-or-edit-category")]
        [Consumes("application/xml")]
        public async Task<IActionResult> CreateOrUpdateCategory([FromBody] CreateCategoryRequest category)
        {
            if (category == null)
            {
                return BadRequest("No se ha recibido una categoría válida.");
            }

            await _categoriesService.CreateOrUpdateCategory(category);

            return Ok(category);
        }
    }
}

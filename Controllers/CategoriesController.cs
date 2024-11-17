using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XmlBillingSystem.BillDbContext.Models;
using XmlBillingSystem.Services;

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
    }
}

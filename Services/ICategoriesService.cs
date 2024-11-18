using XmlBillingSystem.BillDbContext.Models;
using XmlBillingSystem.Services.Dto;

namespace XmlBillingSystem.Services
{
    public interface ICategoriesService
    {
        Task<Categories> GetListOfCategories();
        Task CreateOrUpdateCategory(CreateCategoryRequest category);
    }
}

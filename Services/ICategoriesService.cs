using XmlBillingSystem.BillDbContext.Models;

namespace XmlBillingSystem.Services
{
    public interface ICategoriesService
    {
        Task<Categories> GetListOfCategories();
    }
}

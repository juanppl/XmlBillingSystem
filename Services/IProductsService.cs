using XmlBillingSystem.BillDbContext.Models;

namespace XmlBillingSystem.Services
{
    public interface IProductsService
    {
        Task<Products> GetListOfProducts();
    }
}

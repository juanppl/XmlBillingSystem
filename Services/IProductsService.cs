using Microsoft.AspNetCore.Mvc;
using XmlBillingSystem.BillDbContext.Models;
using XmlBillingSystem.Services.Dto;

namespace XmlBillingSystem.Services
{
    public interface IProductsService
    {
        Task<Products> GetListOfProducts();
        Task CreateOrUpdateProduct(CreateProductRequest product);
    }
}

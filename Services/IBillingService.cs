

using XmlBillingSystem.BillDbContext.Models;

namespace XmlBillingSystem.Services
{
    public interface IBillingService
    {
        Task<Customers> GetAllCustomers();
    }
}

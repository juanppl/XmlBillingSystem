

using Microsoft.AspNetCore.Mvc;
using XmlBillingSystem.BillDbContext.Models;
using XmlBillingSystem.Services.Dto;

namespace XmlBillingSystem.Services
{
    public interface IBillingService
    {
        Task<Customers> GetAllCustomers();
        Task CreateOrUpdateCustomer(CreateCustomerRequest customer);
        Task CreateNewBill(CreateNewBillRequest createNewBillRequest);
    }
}

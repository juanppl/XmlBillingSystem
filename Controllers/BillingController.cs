using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XmlBillingSystem.BillDbContext.Models;
using XmlBillingSystem.Services;
using XmlBillingSystem.Services.Dto;

namespace XmlBillingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _billingService;
        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpGet("get-list-of-customer")]
        [Produces("application/xml")]
        public async Task<Customers> GetAllCustomers()
        {
            return await _billingService.GetAllCustomers();
        }

        [HttpPost("add-or-edit-customer")]
        [Consumes("application/xml")]
        public async Task<IActionResult> CreateOrUpdateCustomer([FromBody] CreateCustomerRequest customer)
        {
            if (customer == null)
            {
                return BadRequest("No se ha recibido un cliente válido.");
            }

            await _billingService.CreateOrUpdateCustomer(customer);

            return Ok(customer);
        }

        [HttpPost("create-new-bill")]
        [Consumes("application/xml")]
        public async Task<IActionResult> CreateNewBill([FromBody] CreateNewBillRequest createNewBillRequest)
        {
            await _billingService.CreateNewBill(createNewBillRequest);
            return Ok(createNewBillRequest);
        }

    }
}

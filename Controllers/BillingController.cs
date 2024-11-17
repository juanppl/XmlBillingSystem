using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XmlBillingSystem.BillDbContext.Models;
using XmlBillingSystem.Services;

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

        [HttpGet("get-billing")]
        [Produces("application/xml")]
        public async Task<ActionResult> GetBilling([FromBody] Customer customer)
        {
            return Ok();
        }

    }
}

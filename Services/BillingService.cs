
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Xml.Serialization;
using XmlBillingSystem.BillDbContext;
using XmlBillingSystem.BillDbContext.Models;
using XmlBillingSystem.Services.Dto;

namespace XmlBillingSystem.Services
{
    public class BillingService : IBillingService
    {
        private readonly BillContext _context;
        public BillingService(BillContext context)
        {
            _context = context;
        }

        public async Task CreateOrUpdateCustomer(CreateCustomerRequest customer)
        {
            if (customer.CustomerId != default)
            {
                var customerFound = await _context.Customer.FirstOrDefaultAsync(c => c.CustomerId == customer.CustomerId);
                if (customerFound == null)
                {
                    throw new Exception($"Customer with id: {customer.CustomerId} not found");
                }

                customerFound.Name = customer.Name;
                customerFound.LastName = customer.LastName;
                customerFound.Email = customer.Email;
                customerFound.Phone = customer.Phone;
                customerFound.Address = customer.Address;

                _context.Update(customerFound);
                await _context.SaveChangesAsync();
            }
            else
            {
                var newCustomer = new Customer
                {
                    Name = customer.Name,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Address = customer.Address,
                };

                _context.Add(newCustomer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Customers> GetAllCustomers()
        {
            var customers = await _context.Customer
                .Include(p => p.Bills)
                .ThenInclude(b => b.BillItems)
                .ThenInclude(bi => bi.Product)
                .ThenInclude(p => p.Category)
                .ToListAsync();
            if (customers == default)
            {
                return new Customers { CustomersList = new List<Customer>() };
            }

            return new Customers { CustomersList = customers };
        }

        //public async Task<Customers> GetAllCustomers()
        //{
        //    string rutaArchivoXml = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles", "customers.xml");

        //    if (File.Exists(rutaArchivoXml))
        //    {
        //        // Leer y deserializar el XML
        //        XmlSerializer serializer = new XmlSerializer(typeof(Customers));

        //        using (StreamReader reader = new StreamReader(rutaArchivoXml))
        //        {
        //            try
        //            {
        //                Customers customers = (Customers)serializer.Deserialize(reader);
        //                return customers;
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception("Could not read categories");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("El archivo XML no se encontró.");
        //    }
        //}
    }
}

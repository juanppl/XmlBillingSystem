
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Xml.Serialization;
using XmlBillingSystem.BillDbContext;
using XmlBillingSystem.BillDbContext.Models;

namespace XmlBillingSystem.Services
{
    public class BillingService : IBillingService
    {
        private readonly BillContext _context;
        public BillingService(BillContext context)
        {
            _context = context;
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

using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;
using XmlBillingSystem.BillDbContext;
using XmlBillingSystem.BillDbContext.Models;

namespace XmlBillingSystem.Services
{
    public class ProductsService : IProductsService
    {
        private readonly BillContext _context;
        public ProductsService(BillContext context)
        {
            _context = context;
        }

        public async Task<Products> GetListOfProducts()
        {
            var products = await _context.Product
                .Include(p => p.Category)
                .ToListAsync();
            if (products == default)
            {
                return new Products { ProductsList = new List<Product>() };
            }

            return new Products { ProductsList = products };
        }

        //public async Task<Products> GetListOfProducts()
        //{
        //    string rutaArchivoXml = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles", "products.xml");

        //    if (File.Exists(rutaArchivoXml))
        //    {
        //        // Leer y deserializar el XML
        //        XmlSerializer serializer = new XmlSerializer(typeof(Products));

        //        using (StreamReader reader = new StreamReader(rutaArchivoXml))
        //        {
        //            try
        //            {
        //                Products products = (Products)serializer.Deserialize(reader);
        //                return products;
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

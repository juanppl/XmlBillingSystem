using System.Xml.Serialization;
using XmlBillingSystem.BillDbContext.Models;

namespace XmlBillingSystem.Services
{
    public class ProductsService : IProductsService
    {
        public async Task<Products> GetListOfProducts()
        {
            string rutaArchivoXml = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles", "products.xml");

            if (File.Exists(rutaArchivoXml))
            {
                // Leer y deserializar el XML
                XmlSerializer serializer = new XmlSerializer(typeof(Products));

                using (StreamReader reader = new StreamReader(rutaArchivoXml))
                {
                    try
                    {
                        Products products = (Products)serializer.Deserialize(reader);
                        return products;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Could not read categories");
                    }
                }
            }
            else
            {
                throw new Exception("El archivo XML no se encontró.");
            }
        }
    }
}

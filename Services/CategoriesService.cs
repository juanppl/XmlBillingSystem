using System.Xml.Serialization;
using XmlBillingSystem.BillDbContext.Models;

namespace XmlBillingSystem.Services
{
    public class CategoriesService : ICategoriesService
    {
        public async Task<Categories> GetListOfCategories()
        {
            string rutaArchivoXml = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles", "categories.xml");

            if (File.Exists(rutaArchivoXml))
            {
                // Leer y deserializar el XML
                XmlSerializer serializer = new XmlSerializer(typeof(Categories));

                using (StreamReader reader = new StreamReader(rutaArchivoXml))
                {
                    try
                    {
                        Categories categories = (Categories) serializer.Deserialize(reader);
                        return categories;
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

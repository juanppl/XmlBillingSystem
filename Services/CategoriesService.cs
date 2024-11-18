using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using System.Xml.Serialization;
using XmlBillingSystem.BillDbContext;
using XmlBillingSystem.BillDbContext.Models;
using XmlBillingSystem.Services.Dto;

namespace XmlBillingSystem.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly BillContext _context;
        public CategoriesService(BillContext context)
        {
            _context = context;
        }

        public async Task<Categories> GetListOfCategories()
        {
            var categories = await _context.Category.ToListAsync();
            if (categories == default)
            {
                return new Categories { CategoryList = new List<Category>() };
            }

            return new Categories { CategoryList = categories };
        }

        public async Task CreateOrUpdateCategory(CreateCategoryRequest category)
        {
            if (category.CategoryId != default)
            {
                var categoryFound = await _context.Category.FirstOrDefaultAsync(c => c.CategoryId == category.CategoryId);
                if (categoryFound == null) {
                    throw new Exception($"Category with id: {category.CategoryId} not found");
                }
                categoryFound.Name = category.Name;
                categoryFound.Description = category.Description;
                _context.Update(categoryFound);
                await _context.SaveChangesAsync();
            }
            else
            {
                var newCategory = new Category {
                    Name = category.Name,
                    Description = category.Description,
                };

                _context.Add(newCategory);
                await _context.SaveChangesAsync();
            }
        }

        //public async Task<Categories> GetListOfCategories()
        //{
        //    string rutaArchivoXml = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles", "categories.xml");

        //    if (File.Exists(rutaArchivoXml))
        //    {
        //        // Leer y deserializar el XML
        //        XmlSerializer serializer = new XmlSerializer(typeof(Categories));

        //        using (StreamReader reader = new StreamReader(rutaArchivoXml))
        //        {
        //            try
        //            {
        //                Categories categories = (Categories) serializer.Deserialize(reader);
        //                return categories;
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

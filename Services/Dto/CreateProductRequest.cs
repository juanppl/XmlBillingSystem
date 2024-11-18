using System.Xml.Serialization;
using XmlBillingSystem.BillDbContext.Models;

namespace XmlBillingSystem.Services.Dto
{
    [XmlRoot("Product")]
    public class CreateProductRequest
    {
        [XmlAttribute("productId")]
        public int ProductId { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("Price")]
        public double Price { get; set; }

        [XmlElement("Tax")]
        public double Tax { get; set; }

        [XmlElement("Stock")]
        public int Stock { get; set; }

        [XmlElement("IsActive")]
        public bool IsActive { get; set; } = true;

        [XmlElement("Category")]
        public CategoryDto Category { get; set; }
    }

    public class CategoryDto
    {
        [XmlAttribute("categoryId")]
        public int CategoryId { get; set; }
    }
}

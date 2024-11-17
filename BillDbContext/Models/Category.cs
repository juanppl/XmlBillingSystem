using System.Xml.Serialization;

namespace XmlBillingSystem.BillDbContext.Models
{
    [XmlRoot("Categories")] 
    public class Categories
    {
        [XmlElement("Category")]
        public List<Category> CategoryList { get; set; }
    }

    public class Category
    {
        [XmlAttribute("categoryId")]
        public string CategoryId { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }
    }
}

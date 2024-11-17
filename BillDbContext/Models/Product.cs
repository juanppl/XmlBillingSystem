using System.Xml.Serialization;

namespace XmlBillingSystem.BillDbContext.Models
{
    [XmlRoot("Products")]
    public class Products
    {
        [XmlElement("Product")]
        public List<Product> ProductsList { get; set; }
    }
    public class Product
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
        public bool IsActive { get; set; }

        [XmlIgnore]
        public int CategoryId { get; set; }

        [XmlElement("Category")]
        public Category Category { get; set; }

        [XmlIgnore]
        public virtual List<BillItem> BillItems { get; set; }
    }
}

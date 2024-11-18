using System.Xml.Serialization;

namespace XmlBillingSystem.Services.Dto
{
    [XmlRoot("Category")]
    public class CreateCategoryRequest
    {
        [XmlAttribute("categoryId")]
        public int CategoryId { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }
    }
}

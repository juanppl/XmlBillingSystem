using System.Xml.Serialization;

namespace XmlBillingSystem.Services.Dto
{
    [XmlRoot("Customer")]
    public class CreateCustomerRequest
    {
        [XmlAttribute("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }

        [XmlElement("Phone")]
        public string Phone { get; set; }

        [XmlElement("Address")]
        public string Address { get; set; }
    }
}

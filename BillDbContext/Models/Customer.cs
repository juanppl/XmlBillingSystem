using System.Xml.Serialization;

namespace XmlBillingSystem.BillDbContext.Models
{
    [XmlRoot("Customers")]
    public class Customers
    {
        [XmlElement("Customer")]
        public List<Customer> CustomersList { get; set; }
    }
    public class Customer
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

        [XmlArray("Bills")]
        [XmlArrayItem("Bill")]
        public List<Bill> Bills { get; set; }
    }
}

using System.Xml.Serialization;

namespace XmlBillingSystem.BillDbContext.Models
{
    public class BillItem
    {
        [XmlIgnore]
        public int BillItemId { get; set; }

        [XmlElement("Quantity")]
        public int Quantity { get; set; }

        [XmlElement("Price")]
        public double Price { get; set; }

        [XmlElement("Stock")]
        public int Stock { get; set; }

        [XmlElement("Subtotal")]
        public decimal Subtotal { get; set; }

        [XmlIgnore]
        public int ProductId { get; set; }

        [XmlElement("Product")]
        public Product Product { get; set; }

        [XmlIgnore]
        public Bill Bill { get; set; }

        [XmlIgnore]
        public int BillId { get; set; }
    }
}

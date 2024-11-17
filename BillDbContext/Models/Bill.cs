using System.Xml.Serialization;

namespace XmlBillingSystem.BillDbContext.Models
{
    public class Bill
    {
        [XmlAttribute("billId")]
        public string BillId { get; set; }

        [XmlAttribute("date")]
        public DateTime Date { get; set; }

        [XmlAttribute("referenceNumber")]
        public string ReferenceNumber { get; set; }

        [XmlElement("TotalAmount")]
        public decimal TotalAmount { get; set; }

        [XmlArray("BillItems")]
        [XmlArrayItem("BillItem")]
        public List<BillItem> BillItems { get; set; }
    }
}

using System.Xml.Serialization;

namespace XmlBillingSystem.Services.Dto
{
    [XmlRoot("Customer")]
    public class CreateNewBillRequest
    {
        [XmlAttribute("customerId")]
        public int CustomerId { get; set; }

        [XmlArray("Bills")]
        [XmlArrayItem("Bill")]
        public List<BillDto> Bills { get; set; }
    }

    public class BillDto
    {

        [XmlArray("BillItems")]
        [XmlArrayItem("BillItem")]
        public List<BillItemDto> BillItems { get; set; }
    }

    public class BillItemDto
    {
        [XmlElement("Quantity")]
        public int Quantity { get; set; }

        [XmlElement("Price")]
        public double Price { get; set; }

        [XmlElement("Stock")]
        public int Stock { get; set; }

        [XmlElement("Subtotal")]
        public decimal Subtotal { get; set; }

        [XmlElement("Product")]
        public ProductDto Product { get; set; }
    }

    public class ProductDto
    {
        [XmlAttribute("productId")]
        public int ProductId { get; set; }
    }
}

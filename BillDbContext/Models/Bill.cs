namespace XmlBillingSystem.BillDbContext.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public DateTime Date { get; set; }
        public string ReferenceNumber { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<BillItems> BillItems { get; set; }
    }
}

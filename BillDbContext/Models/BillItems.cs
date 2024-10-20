namespace XmlBillingSystem.BillDbContext.Models
{
    public class BillItems
    {
        public int BillId { get; set; }
        public Bill Bill { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}

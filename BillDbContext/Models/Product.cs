namespace XmlBillingSystem.BillDbContext.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<BillItems> BillItems { get; set; }
    }
}

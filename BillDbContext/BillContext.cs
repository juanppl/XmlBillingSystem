using Microsoft.EntityFrameworkCore;
using System;
using XmlBillingSystem.BillDbContext.Models;

namespace XmlBillingSystem.BillDbContext
{
    public class BillContext : DbContext
    {
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<BillItems> BillItems { get; set; }
        public BillContext(DbContextOptions<BillContext> options) : base(options) { }


    }
}

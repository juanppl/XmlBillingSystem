using LATAM_CDS.AppDbContext.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using XmlBillingSystem.BillDbContext.Configurations;
using XmlBillingSystem.BillDbContext.Models;

namespace XmlBillingSystem.BillDbContext
{
    public partial class BillContext : DbContext
    {
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<BillItem> BillItem { get; set; }
        public BillContext(DbContextOptions<BillContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new BillItemsConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

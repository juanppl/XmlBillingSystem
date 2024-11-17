using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XmlBillingSystem.BillDbContext.Models;

namespace XmlBillingSystem.BillDbContext.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("CUSTOMER");
            builder.HasKey(e => e.CustomerId)
                .HasName("PK_CUSTOMER");

            builder.Property(e => e.CustomerId)
                .HasColumnName("CUSTOMER_ID");
            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(50);
            builder.Property(e => e.LastName)
                .HasColumnName("LAST_NAME")
                .HasMaxLength(50);
            builder.Property(e => e.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(50);
            builder.Property(e => e.Phone)
                .HasColumnName("PHONE")
                .HasMaxLength(50);
            builder.Property(e => e.Address)
                .HasColumnName("ADDRESS")
                .HasMaxLength(100);

            builder.HasMany(d => d.Bills)
                .WithOne(p => p.Customer)
                .HasForeignKey(e => e.CustomerId)
                .HasConstraintName("FK_CUSTOMER_BILLS")
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

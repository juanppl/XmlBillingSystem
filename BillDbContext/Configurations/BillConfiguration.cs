using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XmlBillingSystem.BillDbContext.Models;

namespace XmlBillingSystem.BillDbContext.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("BILL");
            builder.HasKey(e => e.BillId)
                .HasName("PK_BILL");

            builder.Property(e => e.BillId)
                .HasColumnName("BILL_ID");

            builder.Property(e => e.Date)
                .HasColumnName("DATE")
                .HasColumnType("datetime");
            builder.Property(e => e.ReferenceNumber)
                .HasColumnName("REFERENCE_NUMBER")
                .HasMaxLength(50);
            builder.Property(e => e.TotalAmount)
                .HasColumnName("TOTAL_AMOUNT")
                .HasColumnType("decimal");

            builder.HasMany(d => d.BillItems)
                .WithOne(p => p.Bill)
                .HasForeignKey(e => e.BillId)
                .HasConstraintName("FK_BILL_BILL_ITEMS")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

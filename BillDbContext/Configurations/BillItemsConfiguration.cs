using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XmlBillingSystem.BillDbContext.Models;

namespace XmlBillingSystem.BillDbContext.Configurations
{
    public class BillItemsConfiguration : IEntityTypeConfiguration<BillItem>
    {
        public void Configure(EntityTypeBuilder<BillItem> builder)
        {
            builder.ToTable("BILL_ITEM");
            builder.HasKey(e => e.BillItemId)
                .HasName("PK_BILL_ITEM");

            builder.Property(e => e.ProductId)
                .HasColumnName("ID");
            builder.Property(e => e.Quantity)
                .HasColumnName("QUANTITY");
            builder.Property(e => e.Price)
                .HasColumnName("PRICE")
                .HasColumnType("decimal");
            builder.Property(e => e.Stock)
                .HasColumnName("STOCK");
            builder.Property(e => e.Subtotal)
                .HasColumnName("SUB_TOTAL")
                .HasColumnType("decimal");

            builder.HasOne(d => d.Bill)
                .WithMany(p => p.BillItems)
                .HasForeignKey(e => e.BillId)
                .HasConstraintName("FK_BILL_ITEM_BILL")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.Product)
                .WithMany(p => p.BillItems)
                .HasForeignKey(e => e.ProductId)
                .HasConstraintName("FK_BILL_ITEM_PRODUCT")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

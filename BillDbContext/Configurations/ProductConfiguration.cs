using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XmlBillingSystem.BillDbContext.Models;

namespace LATAM_CDS.AppDbContext.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCT");
            builder.HasKey(e => e.ProductId)
                .HasName("PK_PRODUCT");

            builder.Property(e => e.ProductId)
                .HasColumnName("ID");
            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(50);
            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(250);
            builder.Property(e => e.Price)
                .HasColumnName("PRICE");
            builder.Property(e => e.Tax)
                .HasColumnName("TAX");
            builder.Property(e => e.IsActive)
                .HasColumnName("IS_ACTIVE");
            builder.Property(e => e.Stock)
                .HasColumnName("STOCK");
            builder.Property(e => e.CategoryId)
                .HasColumnName("CATEGORY_ID");

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(e => e.CategoryId)
                .HasConstraintName("FK_PRODUCT_CATEGORY")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

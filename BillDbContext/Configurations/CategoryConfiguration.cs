using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XmlBillingSystem.BillDbContext.Models;

namespace LATAM_CDS.AppDbContext.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("CATEGORY");
            builder.HasKey(e => e.CategoryId)
                .HasName("PK_CATEGORY");

            builder.Property(e => e.CategoryId)
                .HasColumnName("CATEGORY_ID");

            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(200);
        }
    }
}

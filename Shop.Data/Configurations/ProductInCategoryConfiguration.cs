using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Entities;

namespace Shop.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategory");
            builder.HasKey(x => new { x.ProductId, x.CategoryId });

            builder.HasOne(p => p.Product).WithMany(pc => pc.ProductInCategories).HasForeignKey(pc => pc.ProductId);

            builder.HasOne(c => c.Category).WithMany(pc => pc.ProductInCategories).HasForeignKey(pc => pc.CategoryId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Entities;

namespace Shop.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.shipEmail).IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.shipName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.shipAddress).IsRequired().HasMaxLength(100);
            builder.Property(x => x.shipPhoneNumber).IsRequired().IsUnicode(false).HasMaxLength(13);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);

        }
    }
}

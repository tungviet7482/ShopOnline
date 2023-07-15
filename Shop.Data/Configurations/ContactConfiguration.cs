using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Entities;

namespace Shop.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();

            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Message).IsRequired();
        }
    }
}

using CustomerManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManager.Infrastructure.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);
            builder.Property(c => c.FirstName).HasColumnName("FirstName").HasColumnType("varchar").HasMaxLength(300).IsRequired();
            builder.Property(c => c.LastName).HasColumnName("LastName").HasColumnType("varchar").HasMaxLength(300).IsRequired();
            builder.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber").HasColumnType("varchar").HasMaxLength(13);

            //relacion
            builder.HasMany(c => c.Addresses)
                .WithOne(ad => ad.Customer)
                .HasForeignKey(c => c.CustomerId);
                

            builder.ToTable("Customers");
        }
    }
}

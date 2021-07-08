using CustomerManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManager.Infrastructure.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(ad => ad.AddressId);
            builder.Property(ad => ad.CustomerId).HasColumnName("CustomerId").HasColumnType("int").IsRequired();
            builder.Property(ad => ad.Street).HasColumnName("Street").HasColumnType("varchar").HasMaxLength(800).IsRequired();
            builder.Property(ad => ad.NumberAparment).HasColumnName("NumberAparment").HasColumnType("varchar").HasMaxLength(800).IsRequired();
            builder.Property(ad => ad.CreateDate).HasColumnName("CreateDate").HasColumnType("DateTime").IsRequired();
                                    

            builder.ToTable("Addresses");
        }
    }
}

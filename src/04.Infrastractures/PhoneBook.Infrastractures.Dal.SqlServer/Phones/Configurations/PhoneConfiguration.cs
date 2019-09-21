using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Domain.Phones;
using System;

namespace PhoneBook.Infrastractures.Dal.SqlServer.Phones.Configurations
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
            builder.Property(c => c.PhoneType).HasConversion(c => c.ToString(),
                x =>(PhoneType) Enum.Parse(typeof(PhoneType), x));
        }
    }
}

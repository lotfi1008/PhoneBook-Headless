﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Domain.People;

namespace PhoneBook.Infrastractures.Dal.SqlServer.People.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(50);
            builder.Property(c => c.LastName).HasMaxLength(50);
            builder.Property(c => c.Image).IsUnicode(false);
            builder.Property(c => c.Email).HasMaxLength(256);
            builder.Property(c => c.Address).HasMaxLength(500);
        }
    }
}

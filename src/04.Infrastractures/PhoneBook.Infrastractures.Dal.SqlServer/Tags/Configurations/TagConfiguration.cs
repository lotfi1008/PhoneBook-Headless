using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Domain.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastractures.Dal.SqlServer.Tags.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(50);
        }
    }
}

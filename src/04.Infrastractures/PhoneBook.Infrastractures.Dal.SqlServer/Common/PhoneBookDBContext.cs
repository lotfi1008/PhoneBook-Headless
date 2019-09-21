using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Domain.People;
using PhoneBook.Core.Domain.Phones;
using PhoneBook.Core.Domain.Tags;
using System.Reflection;

namespace PhoneBook.Infrastractures.Dal.SqlServer.Common
{
    public class PhoneBookDBContext : DbContext
    {
        public PhoneBookDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonTag> PersonTags { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PhoneBookDBContext).Assembly);
            base.OnModelCreating(modelBuilder); 
        }
    }
}

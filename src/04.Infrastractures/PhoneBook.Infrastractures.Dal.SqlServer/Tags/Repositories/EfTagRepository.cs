using PhoneBook.Core.Domain.Tags;
using PhoneBook.Core.Domain.Tags.Contracts;
using PhoneBook.Infrastractures.Dal.SqlServer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastractures.Dal.SqlServer.People.Repositories
{
    public class EfTagRepository : EFBaseRepository<Tag>, TagRepository
    {
        public EfTagRepository(PhoneBookDBContext context) : base(context)
        {
        }
    }
}

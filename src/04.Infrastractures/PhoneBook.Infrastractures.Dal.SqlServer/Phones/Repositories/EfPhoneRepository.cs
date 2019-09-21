using PhoneBook.Core.Domain.Phones;
using PhoneBook.Core.Domain.Phones.Contracts;
using PhoneBook.Infrastractures.Dal.SqlServer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastractures.Dal.SqlServer.People.Repositories
{
    public class EfPhoneRepository : EFBaseRepository<Phone>, PhoneRepositroy
    {
        public EfPhoneRepository(PhoneBookDBContext context) : base(context)
        {
        }
    }
}

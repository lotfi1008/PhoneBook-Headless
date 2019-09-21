using PhoneBook.Core.Domain.People;
using PhoneBook.Core.Domain.People.Contracts;
using PhoneBook.Infrastractures.Dal.SqlServer.Common;

namespace PhoneBook.Infrastractures.Dal.SqlServer.People.Repositories
{
    public class EfPersonRepository : EFBaseRepository<Person>, PersonRepository
    {
        public EfPersonRepository(PhoneBookDBContext context) : base(context)
        {
        }
    }
}

using PhoneBook.Core.Domain.Common;
using PhoneBook.Core.Domain.Tags;

namespace PhoneBook.Core.Domain.People
{
    public class PersonTag : BaseEntity
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}

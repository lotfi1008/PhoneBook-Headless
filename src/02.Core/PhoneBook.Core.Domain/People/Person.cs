using PhoneBook.Core.Domain.Common;
using PhoneBook.Core.Domain.Phones;
using System.Collections.Generic;

namespace PhoneBook.Core.Domain.People
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Image { get; set;  }
        public ICollection<Phone> Phones { get; set; }
        public ICollection<PersonTag> Tags { get; set; }

    }
}

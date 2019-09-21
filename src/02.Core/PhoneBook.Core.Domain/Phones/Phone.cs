using PhoneBook.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Domain.Phones
{
    public class Phone:BaseEntity
    {
        public string PhoneNumber { get; set; }
        public PhoneType PhoneType { get; set; }
    }
}

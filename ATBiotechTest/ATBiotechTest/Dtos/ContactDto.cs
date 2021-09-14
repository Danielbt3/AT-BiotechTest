using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATBiotechTest.Dtos
{
    public class ContactDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ContactDto() { }
        public ContactDto(long Id,string Name,string Address)
        {
            this.Id = Id;
            this.Name = Name;
            this.Address = Address;
        }
    }
}

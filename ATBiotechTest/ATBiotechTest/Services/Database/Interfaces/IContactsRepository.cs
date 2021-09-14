using ATBiotechTest.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATBiotechTest.Services.Database.Interfaces
{
    public interface IContactsRepository
    {
        void Create(ContactDto input);
        List<ContactDto> GetContacts(ContactQueryDto query);
        void UpdateContacts(ContactDto input, long id);
        void DeleteContacts(long id);
    }
}

using ATBiotechTest.Dtos;
using System.Collections.Generic;

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

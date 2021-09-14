using ATBiotechTest.Dtos;
using System.Collections.Generic;

namespace ATBiotechTest.Services.Interfaces
{
    public interface IContactsService
    {
        void Create(ContactDto contactDto);
        List<ContactDto> Get(ContactQueryDto query);
        void Update(ContactDto input, long id);
        void Delete(long id);
    }
}

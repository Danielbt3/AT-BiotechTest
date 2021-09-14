using ATBiotechTest.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

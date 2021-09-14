using ATBiotechTest.Dtos;
using ATBiotechTest.Services.Database.Interfaces;
using ATBiotechTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATBiotechTest.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsService(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public void Create(ContactDto contactDto)
        {
            _contactsRepository.Create(contactDto);
        }

        public List<ContactDto> Get(ContactQueryDto query)
        {
            return _contactsRepository.GetContacts(query);
        }

        public void Update(ContactDto input,long id)
        {
            _contactsRepository.UpdateContacts(input, id);
        }

        public void Delete(long id)
        {
            _contactsRepository.DeleteContacts(id);
        }
    }
}

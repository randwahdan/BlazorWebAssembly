using BlazorCRUDApp.Server.Models;
using BlazorCRUDApp.Server.Repository;

namespace BlazorCRUDApp.Server.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> _contact;
        public ContactService(IRepository<Contact> contact)
        {
            _contact = contact;
        }
        public async Task<Contact> AddContact(Contact person)
        {
            return await _contact.CreateAsync(person);
        }

        public async Task<bool> UpdateContact(int id, Contact contact) 
        {
            var data = await _contact.GetByIdAsync(id);

            if (data != null)
            {  
                data.FirstName = contact.FirstName;
                data.LastName = contact.LastName;
                data.Email = contact.Email;
                data.PhoneNumber = contact.PhoneNumber;

                await _contact.UpdateAsync(data);
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteContact(int id)
        {
            await _contact.DeleteAsync(id);
            return true;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _contact.GetAllAsync();
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _contact.GetByIdAsync(id);
        }
    }
}

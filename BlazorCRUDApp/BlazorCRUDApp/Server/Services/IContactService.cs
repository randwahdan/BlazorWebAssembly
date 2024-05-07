using BlazorCRUDApp.Server.Models;

namespace BlazorCRUDApp.Server.Services
{
    public interface IContactService
    {
        Task<Contact> AddContact(Contact person);

        Task<bool> UpdateContact(int id, Contact person);

        Task<bool> DeleteContact(int id);

        Task<List<Contact>> GetAllContacts();

        Task<Contact> GetContact(int id);

    }
}

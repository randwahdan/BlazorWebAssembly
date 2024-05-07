using BlazorCRUDApp.Server.Models;
using BlazorCRUDApp.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUDApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService personService)
        {
            _contactService = personService;
        }

        [HttpGet]
        public async Task<List<Contact>> GetAll()
        {
            return await _contactService.GetAllContacts();
        }

        [HttpGet("{id}")]
        public async Task<Contact> Get(int id)
        {
            return await _contactService.GetContact(id);
        }

        [HttpPost]
        public async Task<Contact> AddContact([FromBody] Contact contact)
        {
           return await _contactService.AddContact(contact);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteContact(int id)
        {
            await _contactService.DeleteContact(id); return true;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateContact(int id, [FromBody] Contact Object)
        {
            await _contactService.UpdateContact(id, Object); return true;
        }
    }
}

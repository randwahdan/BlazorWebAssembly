using BlazorCRUDApp.Server.AppDbContext;
using BlazorCRUDApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Repository
{
    public class ContactRepository : IRepository<Contact>
    {
        ApplicationDbContext _dbContext;
        public ContactRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Contact> CreateAsync(Contact _object)
        {
            var obj = await _dbContext.Contacts.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task UpdateAsync(Contact _object)
        {
            _dbContext.Contacts.Update(_object);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _dbContext.Contacts.ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int Id)
        {
            return await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                _dbContext.Remove(contact);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

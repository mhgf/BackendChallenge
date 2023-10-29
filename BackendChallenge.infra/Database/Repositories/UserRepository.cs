using BackendChallenge.core.Entity;
using BackendChallenge.core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.infra.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;
        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<User> CreateAsync(User entity)
        {
            var resutl = await _context.Users.AddAsync(entity);
            return resutl.Entity;
        }

        public Task DeleteByIdAsync(User entity)
        {
            _context.Users.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<User>> FindAllAsync()
        {
            return await _context.Users.AsNoTracking().ToArrayAsync();
        }

        public async Task<User?> FindByDocumentAsync(string document)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Document == document);
        }

        public async Task<User?> FindByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}

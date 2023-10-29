using BackendChallenge.core.Entity;
using BackendChallenge.core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.infra.Database.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DatabaseContext _context;

        public TransactionRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Transaction> CreateAsync(Transaction entity)
        {
            await _context.Transactions.AddAsync(entity);
            return entity;
        }

        public Task DeleteByIdAsync(Transaction entity)
        {
            _context.Transactions.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Transaction>> FindAllAsync()
        {
            return await _context.Transactions.AsNoTracking().ToArrayAsync();
        }

        public async Task<Transaction?> FindByIdAsync(Guid id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Transaction?> FindByIdCompleteAsync(Guid id)
        {
            return await _context.Transactions
                .Include(x => x.Sender)
                .Include(x => x.Resiver)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Transaction>> FindByReciverid(Guid reciverId)
        {
            return await _context.Transactions.AsNoTracking().Where(x => x.ResiverId == reciverId).ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> FindBySenderid(Guid senderId)
        {
            return await _context.Transactions.AsNoTracking().Where(x => x.SenderId == senderId).ToArrayAsync();
        }

        public Task<Transaction> UpdateAsync(Transaction entity)
        {
            _context.Update(entity);
            return Task.FromResult(entity);
        }
    }
}

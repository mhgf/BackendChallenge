﻿using BackendChallenge.core.Entity;

namespace BackendChallenge.core.Repositories
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> FindBySenderid(Guid senderId);
        Task<IEnumerable<Transaction>> FindByReciverid(Guid reciverId);
    }
}

using BackendChallenge.core.Entity;
using BackendChallenge.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.core.Repository
{
    internal interface UserRepository: BaseRepository<User>
    {
        Task<User> FindByDocumentAsync(string document);
    }
}

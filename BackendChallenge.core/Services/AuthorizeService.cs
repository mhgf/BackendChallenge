using BackendChallenge.core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.core.Services
{
    public interface AuthorizeService
    {
        public Task<bool> AuthorizeTransaction(User sender, decimal amaunt);
    }
}

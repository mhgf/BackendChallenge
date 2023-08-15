using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.core.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}

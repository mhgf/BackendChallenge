using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.core.Entity
{
    public class Transaction : BaseEntity
    {
        public Guid SenderId { get; private set; }
        public User? Sender { get; private set; }

        public Guid ResiverId { get; private set; }
        public User? Resiver { get; private set; }

        public decimal Amount { get; set; }

        private Transaction() { }
        private Transaction(Guid senderId, Guid resiverId, decimal amount)
        {
            SenderId = senderId;
            ResiverId = resiverId;
            Amount = amount;
        }

        public  static Transaction Create(Guid senderId, Guid resiverId, decimal amount) =>  new Transaction(senderId, resiverId, amount);
    }
}

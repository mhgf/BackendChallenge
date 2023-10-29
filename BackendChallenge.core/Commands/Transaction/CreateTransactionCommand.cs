using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.core.Commands.Transaction
{
    public record CreateTransactionCommand(Guid senderId, Guid resiverId, decimal amount): IRequest<Guid>;
}

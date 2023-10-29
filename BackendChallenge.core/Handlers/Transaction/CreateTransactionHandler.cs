using BackendChallenge.core.Commands.Transaction;
using BackendChallenge.core.Enum;
using BackendChallenge.core.Notification;
using BackendChallenge.core.Repositories;
using BackendChallenge.core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.core.Handlers.Transaction
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserRepository _userRepository;
        private readonly AuthorizeService _authorizeService;
        private readonly NotificationContext _notificationContext;

        public CreateTransactionHandler(ITransactionRepository transactionRepository, IUserRepository userRepository, AuthorizeService authorizeService , NotificationContext notificationContext)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _authorizeService = authorizeService;
            _notificationContext = notificationContext;
        }

        public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {

            var users = await Task.WhenAll(_userRepository.FindByIdAsync(request.senderId), _userRepository.FindByIdAsync(request.resiverId));
            if (users.Any(x => x is null) || users[0].Type == users[1].Type)
            {
                _notificationContext.AddNotification("User", "Sender/Resiver id são Inválidos");
                return Guid.Empty;
            }

            var sender = users.First(x => x.Id == request.senderId);
            var resiver = users.First(x => x.Id == request.resiverId);

            if(sender.CanTransfer())
            {
                _notificationContext.AddNotification("User", "Logista não pode realizar trasnferencias!!");
                return Guid.Empty;
            }

            if (!sender.HaveBalance(request.amount))
            {
                _notificationContext.AddNotification("User", "Saldo insuficiente");
                return Guid.Empty;
            }
            

            if(!(await _authorizeService.AuthorizeTransaction(sender, request.amount)))
            {
                _notificationContext.AddNotification("User", "Transação não autorizada");
                return Guid.Empty;
            }

            sender.RemoveBalance(request.amount);
            resiver.AddBalance(request.amount);

            var transaction = Entity.Transaction.Create(request.senderId, request.resiverId, request.amount);
            if (transaction.Invalid)
            {
                _notificationContext.AddNotifications(transaction.ValidationResult);
                return Guid.Empty;
            }

            var result = await _transactionRepository.CreateAsync(transaction);

            return result.Id;
        }
    }
}

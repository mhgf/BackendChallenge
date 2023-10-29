using BackendChallenge.core.Commands.Notification;
using BackendChallenge.core.Repositories;
using BackendChallenge.core.Services;
using MediatR;

namespace BackendChallenge.core.Handlers.Notification
{
    public class NotifyReceiverHandler : IRequestHandler<NotifyReceiverCommand, bool>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly NotificationService _notificationService;

        public NotifyReceiverHandler(ITransactionRepository transactionRepository, NotificationService notificationService)
        {
            _transactionRepository = transactionRepository;
            _notificationService = notificationService;
        }
        public async Task<bool> Handle(NotifyReceiverCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var transaction = await _transactionRepository.FindByIdCompleteAsync(request.TransactionId);
                if (transaction == null) return false;

                var msg = $"Olá {transaction?.Resiver?.Name}, o {transaction?.Sender?.Name} acaba de tranferir para você R${transaction?.Amount.ToString("C")}";
                await _notificationService.SendMenssage(transaction?.Resiver?.Email ?? "", msg);
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }
    }
}

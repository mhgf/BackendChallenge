using MediatR;

namespace BackendChallenge.core.Commands.Notification
{
    public record NotifyReceiverCommand(Guid TransactionId): IRequest<bool>;
}

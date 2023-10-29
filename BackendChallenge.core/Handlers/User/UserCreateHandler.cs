using BackendChallenge.core.Commands.User;
using BackendChallenge.core.Entity;
using BackendChallenge.core.Notification;
using BackendChallenge.core.Repositories;
using MediatR;

namespace BackendChallenge.core.Services
{
    public class UserCreateHandler : IRequestHandler<CreateUserCommand, User?>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IUserRepository _userRepository;
        public UserCreateHandler(IUserRepository userRepository, NotificationContext notificationContext)
        {
            _userRepository = userRepository;
            _notificationContext = notificationContext;
        }


        public async Task<User?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Create(request.Name, request.Email, request.Document, request.Password, request.type);

            if (user.Invalid)
            {
                _notificationContext.AddNotifications(user.ValidationResult);
                return null;
            }

            var result = await _userRepository.CreateAsync(user);

            return result;
        }
    }
}

using BackendChallenge.core.Entity;
using BackendChallenge.core.Enum;
using MediatR;


namespace BackendChallenge.core.Commands.User
{
    public record CreateUserCommand(string Name, string Document, string Email, string Password, string type) : IRequest<Entity.User?>;
}

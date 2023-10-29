using BackendChallenge.infra.Database;
using MediatR;

namespace BackendChallenge.Behaviours
{
    public class ContextBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly DatabaseContext _context;

        public ContextBehaviour(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var result = await next();

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}

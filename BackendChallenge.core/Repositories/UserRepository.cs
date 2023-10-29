using BackendChallenge.core.Entity;

namespace BackendChallenge.core.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<User?> FindByDocumentAsync(string document);
    }
}

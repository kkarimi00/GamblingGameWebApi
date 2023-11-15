using GamblingGameWebApi.Entities.Domains.Users;

namespace GamblingGameWebApi.Entities.Domains.RepositoryContracts.Users;

public interface IUserRepository
{
    Task<User> Add(User user);
    Task Update(User user);
    Task Delete(User user);
    IEnumerable<User> GetAll();
    IEnumerable<User> Get(int id);
}

using GamblingGameWebApi.Entities.Domains.RepositoryContracts.Users;
using GamblingGameWebApi.Entities.Domains.Users;

namespace GamblingGameWebApi.DataAccess.Repositories;

public class UsersRepository : IUserRepository
{
    private readonly IGamblingGameDbContext _dbContext;
    public UsersRepository(IGamblingGameDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> Add(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task Delete(User user)
    {
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }

    public IEnumerable<User> Get(int id)
    {
        return _dbContext.Users.Where(c => c.Id == id);
    }

    public IEnumerable<User> GetAll()
    {
        return _dbContext.Users.ToList();
    }

    public async Task Update(User user)
    {
        _dbContext.Users.Update(user);
       await _dbContext.SaveChangesAsync();
    }
}

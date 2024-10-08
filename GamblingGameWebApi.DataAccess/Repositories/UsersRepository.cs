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
        await _dbContext.SaveChanges();
        return user;
    }

    public async Task Delete(User user)
    {
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChanges();
    }

    public async Task<User> GetById(int id)
    {
        return await Task.FromResult(_dbContext.Users.FirstOrDefault(c => c.Id == id));
    }

    public IEnumerable<User> GetAll()
    {
        return _dbContext.Users.ToList();
    }

    public async Task Update(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChanges();
    }
}

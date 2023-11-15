using GamblingGameWebApi.Entities.Domains.GambleRequests;
using GamblingGameWebApi.Entities.Domains.RepositoryContracts.GambleRequests;

namespace GamblingGameWebApi.DataAccess.Repositories;

public class GambleRequestsRepository : IGambleRequestsRepository
{
    private readonly IGamblingGameDbContext _dbContext;

    public GambleRequestsRepository(IGamblingGameDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GambleRequest> Add(GambleRequest gambleRequest)
    {
        _dbContext.GambleRequests.Add(gambleRequest);
        await _dbContext.SaveChangesAsync();
        return gambleRequest;
    }

    public async Task Delete(GambleRequest gambleRequest)
    {
        _dbContext.GambleRequests.Remove(gambleRequest);
        await _dbContext.SaveChangesAsync();
    }

    public IEnumerable<GambleRequest> Get(int id)
    {
        return _dbContext.GambleRequests.Where(c => c.Id == id);
    }

    public IEnumerable<GambleRequest> GetAll()
    {
        return _dbContext.GambleRequests.ToList();
    }

    public async void Update(GambleRequest gambleRequest)
    {
        _dbContext.GambleRequests.Update(gambleRequest);
        await _dbContext.SaveChangesAsync();
    }
}

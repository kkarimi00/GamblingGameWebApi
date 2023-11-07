using GamblingGameWebApi.Entities.Domains.GambleRequests;

namespace GamblingGameWebApi.Entities.Domains.RepositoryContracts.GambleRequests;

public interface IGambleRequestsRepository
{
    Task<GambleRequest> Add(GambleRequest gambleRequest);
    void Update(GambleRequest gambleRequest);
    Task Delete(GambleRequest gambleRequest);
    IEnumerable<GambleRequest> GetAll();
    IEnumerable<GambleRequest> Get(int id);
}

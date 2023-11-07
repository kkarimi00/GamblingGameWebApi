using GamblingGameWebApi.Entities.Domains.GambleRequests;
using GamblingGameWebApi.Entities.Domains.Users;
using Microsoft.EntityFrameworkCore;

namespace GamblingGameWebApi.DataAccess;

public interface IGamblingGameDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<GambleRequest> GambleRequests { get; set; }

    Task<int> SaveChanges();
}

using GamblingGameWebApi.DataAccess.DbMaps;
using GamblingGameWebApi.Entities.Domains.GambleRequests;
using GamblingGameWebApi.Entities.Domains.Users;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace GamblingGameWebApi.DataAccess;

public class GamblingGameDbContext : DbContext, IGamblingGameDbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<GambleRequest> GambleRequests { get; set; } = null!;

    public GamblingGameDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GambleRequestDbMaps());
        modelBuilder.ApplyConfiguration(new UserDbMaps());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
}

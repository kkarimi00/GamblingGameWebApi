using GamblingGameWebApi.DataAccess.DbMaps;
using GamblingGameWebApi.Entities.Domains.GambleRequests;
using GamblingGameWebApi.Entities.Domains.Users;
using Microsoft.EntityFrameworkCore;

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

        modelBuilder.Entity<User>().HasData(
        new User { Id=1, Name = "Saam", InitialPoint = 12, CurrentPoint = 18 },
        new User { Id = 2, Name = "Mouse", InitialPoint = 9, CurrentPoint = 0 });
    }

    public async Task<int> SaveChanges(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}

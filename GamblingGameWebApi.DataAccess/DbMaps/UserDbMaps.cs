using GamblingGameWebApi.Entities.Domains.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamblingGameWebApi.DataAccess.DbMaps;

public class UserDbMaps : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.HasMany(x => x.Requests)
            .WithOne(x => x.User);
    }
}

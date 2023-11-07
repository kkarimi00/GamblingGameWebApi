using GamblingGameWebApi.Entities.Domains.GambleRequests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamblingGameWebApi.DataAccess.DbMaps;

public class GambleRequestDbMaps : IEntityTypeConfiguration<GambleRequest>
{
    public void Configure(EntityTypeBuilder<GambleRequest> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.InvestPoint).IsRequired();
        builder.Property(x=>x.SelectedNumber).IsRequired();
    }
}

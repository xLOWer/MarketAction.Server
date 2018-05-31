using MarketAction.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketAction.Server.Model.Mappings
{
    public class MarketsMap : DbEntityConfiguration<Market>
    {
        public override void Configure(EntityTypeBuilder<Market> entity)
        {
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.TradeNetwork).WithMany(x => x.Markets).HasForeignKey(x => x.TradeNetworkId).OnDelete(DeleteBehavior.SetNull);
            entity.ToTable("Markets");
        }
    }
}

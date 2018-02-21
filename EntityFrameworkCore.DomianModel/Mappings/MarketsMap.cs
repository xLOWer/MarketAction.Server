using MarketAction.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketAction.Server.Model.Mappings
{
    public class MarketsMap : DbEntityConfiguration<Market>
    {
        public override void Configure(EntityTypeBuilder<Market> entity)
        {
            //entity.HasOne(x => x.Document).WithMany(w => w.Attaches).IsRequired().OnDelete(DeleteBehavior.Restrict);
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.TradeNetwork).WithMany(x => x.Markets).HasForeignKey(x => x.TradeNetworkId);
            entity.ToTable("Markets");
        }
    }
}

using MarketAction.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketAction.Server.Model.Mappings
{
    public class TradeNetworksMap : DbEntityConfiguration<TradeNetwork>
    {
        public override void Configure(EntityTypeBuilder<TradeNetwork> entity)
        {
            //entity.HasOne(x => x.Document).WithMany(w => w.Attaches).IsRequired().OnDelete(DeleteBehavior.Restrict);
            entity.HasKey(x => x.Id);
            entity.ToTable("TradeNetworks");
        }
    }
}

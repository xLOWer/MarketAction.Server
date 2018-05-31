using MarketAction.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketAction.Server.Model.Mappings
{
    public class ActionsMap : DbEntityConfiguration<Action>
    {
        public override void Configure(EntityTypeBuilder<Action> entity)
        {
            entity.HasKey(x => x.Id);
            entity.HasMany(x => x.Products).WithOne(x => x.Action);
            entity.HasOne(x => x.TradeNetwork).WithMany(x => x.Actions).HasForeignKey(x => x.TradeNetworkId).OnDelete(DeleteBehavior.SetNull);
            entity.ToTable("Actions");
        }
    }
}

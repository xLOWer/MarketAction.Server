using EntityFrameworkCore.DomianModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.DomianModel.Mappings
{
    public class TradeNetworksMap : DbEntityConfiguration<TradeNetwork>
    {
        public override void Configure(EntityTypeBuilder<TradeNetwork> entity)
        {
            entity.HasKey(x => x.Id);
            entity.HasMany(x => x.Actions).WithOne(x => x.TradeNetwork);
            entity.HasMany(x => x.Markets).WithOne(x => x.TradeNetwork);
            entity.ToTable("TradeNetworks");
        }
    }
}

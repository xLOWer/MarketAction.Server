using MarketAction.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketAction.Server.Model.Mappings
{
    public class CataloguesMap : DbEntityConfiguration<Catalogue>
    {
        public override void Configure(EntityTypeBuilder<Catalogue> entity)
        {
            //entity.HasOne(x => x.Document).WithMany(w => w.Attaches).IsRequired().OnDelete(DeleteBehavior.Restrict);
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.TradeNetwork).WithMany(x => x.Catalogues).HasForeignKey(x => x.TradeNetworkId);
            entity.ToTable("Catalogues");
        }
    }
}

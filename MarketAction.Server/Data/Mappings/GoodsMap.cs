using MarketAction.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketAction.Server.Model.Mappings
{
    public class GoodsMap : DbEntityConfiguration<Good>
    {
        public override void Configure(EntityTypeBuilder<Good> entity)
        {
            //entity.HasOne(x => x.Document).WithMany(w => w.Attaches).IsRequired().OnDelete(DeleteBehavior.Restrict);
            entity.HasKey(x => x.Id);

            entity.HasMany(x => x.Actions);//WithMany
            entity.HasMany(x => x.Markets);//WithMany
            entity.HasMany(x => x.Catalogues);//WithMany

            entity.ToTable("Goods");
        }
    }
}

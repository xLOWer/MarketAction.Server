using MarketAction.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MarketAction.Server;

namespace MarketAction.Server.EntityFrameworkCore.DomianModel
{
    public class AccessLevelsMap : DbEntityConfiguration<AccessLevel>
    {
        public override void Configure(EntityTypeBuilder<AccessLevel> entity)
        {
            //entity.HasOne(x => x.Document).WithMany(w => w.Attaches).IsRequired().OnDelete(DeleteBehavior.Restrict);
            entity.HasKey(x => x.Id);
            entity.ToTable("AccessLevels");
        }
    }
}

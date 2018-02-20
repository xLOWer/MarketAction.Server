using MarketAction.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketAction.Server.Model.Mappings
{
    public class UsersMap : DbEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> entity)
        {
            //entity.HasOne(x => x.Document).WithMany(w => w.Attaches).IsRequired().OnDelete(DeleteBehavior.Restrict);
            entity.HasKey(x => x.Id);
            entity.HasMany(x => x.AccessLevels);
            entity.HasOne(x => x.Person).WithOne(x => x.User).HasPrincipalKey<User>(x => x.PersonId);
            entity.ToTable("Users");
        }
    }
}

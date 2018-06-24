using EntityFrameworkCore.DomianModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.DomianModel.Mappings
{
    public class ProductsMap : DbEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.Action).WithMany(x => x.Products).HasForeignKey(x => x.ActionId).OnDelete(DeleteBehavior.SetNull);
            entity.ToTable("Products");
        }
    }
}

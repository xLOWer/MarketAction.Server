using Microsoft.EntityFrameworkCore;
using MarketAction.Server.Model;
using MarketAction.Server.Model.Mappings;
using MarketAction.Server.Data;

namespace MarketAction.Server.Models
{ 
    public class MaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<AccessLevel> AccessLevels { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }
        public DbSet<TradeNetwork> TradeNetworks { get; set; }
        public DbSet<Action> Actions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddConfiguration(new UsersMap());
            modelBuilder.AddConfiguration(new GoodsMap());
            modelBuilder.AddConfiguration(new MarketsMap());
            modelBuilder.AddConfiguration(new AccessLevelsMap());
            modelBuilder.AddConfiguration(new CataloguesMap());
            modelBuilder.AddConfiguration(new PersonsMap());
            modelBuilder.AddConfiguration(new TradeNetworksMap());
            modelBuilder.AddConfiguration(new ActionsMap());
        }

        public MaDbContext(DbContextOptions<MaDbContext> options)
            : base(options)
        {}

    }
}

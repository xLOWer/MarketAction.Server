using Microsoft.EntityFrameworkCore;
using MarketAction.Server.Model;
using MarketAction.Server.Model.Mappings;
using MarketAction.Server.Data;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

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
        {

        }
        public class MaDbContextFactory : IDesignTimeDbContextFactory<MaDbContext>
        {
            public MaDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                var builder = new DbContextOptionsBuilder<MaDbContext>();
                var connectionString = configuration.GetConnectionString("MaDbContext");
                builder.UseSqlServer(connectionString);
                return new MaDbContext(builder.Options);
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MarketAction.Server.Model.Mappings;
using MarketAction.Server.Model;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using MarketAction.Server.Data;

namespace MarketAction.Server.EntityFrameworkCore.DomianModel
{
    public class MaDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<TradeNetwork> TradeNetworks { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Market> Markets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddConfiguration(new ProductsMap());
            modelBuilder.AddConfiguration(new MarketsMap());
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

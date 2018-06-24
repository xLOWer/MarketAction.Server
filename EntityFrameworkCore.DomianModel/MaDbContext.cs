using System.IO;
using EntityFrameworkCore.DomianModel.Mappings;
using EntityFrameworkCore.DomianModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCore.DomianModel
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

        public MaDbContext(DbContextOptions<MaDbContext> options) : base(options)
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
                //builder.UseSqlServer(@"Server=192.168.1.102;Database=MarketAction;User=sa;Password=su4kaebanayaTbl;");
                var context = new MaDbContext(builder.Options);
                
                return context;
            }
        }
    }
}

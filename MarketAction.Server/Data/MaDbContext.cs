using Microsoft.EntityFrameworkCore;
using MarketAction.Server.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketAction.Server.Models
{
    using Microsoft.EntityFrameworkCore.Metadata;
    using System.Data;

    public class MaDbContext : DbContext
    {
        public MaDbContext (DbContextOptions<MaDbContext> options)
            : base(options)
        {            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Stamp> Stamps { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<AccessLevel> AccessLevels { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<TradeNetwork> TradeNetworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //User
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasOne(x => x.Person).WithOne(x => x.User).HasForeignKey<User>(x=>x.PersonId);
            modelBuilder.Entity<User>().HasOne(x=>x.AccessLevel).WithMany(x=>x.Users).OnDelete(DeleteBehavior.SetNull);
            //Stamp
            modelBuilder.Entity<Stamp>().HasKey(x => x.Id);
            //modelBuilder.Entity<Stamp>().HasOne(x => x.UserCreator).WithMany(x => x.)
            //Good
            modelBuilder.Entity<Good>().HasKey(x => x.Id);
            //modelBuilder.Entity<Good>().HasMany(x => x.Markets).WithOne
            //Market
            modelBuilder.Entity<Market>().HasKey(x => x.Id);
            modelBuilder.Entity<Market>().HasOne(x => x.TradeNetwork).WithMany(x => x.Markets).OnDelete(DeleteBehavior.SetNull);
            //AccessLevel
            modelBuilder.Entity<AccessLevel>().HasKey(x => x.Id);

            //Catalogue
            modelBuilder.Entity<Catalogue>().HasKey(x => x.Id);

            //Person
            modelBuilder.Entity<Person>().HasKey(x => x.Id);

            //TradeNetwork
            modelBuilder.Entity<TradeNetwork>().HasKey(x => x.Id);
        }
    }
}

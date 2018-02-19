using Microsoft.EntityFrameworkCore;
using MarketAction.Server.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace MarketAction.Server.Models
{
    using System.Data;
    using System.Collections.Generic;
    using Raven.Data.Entity;
    using Raven.Data;

    public class MaDbContext : DbContext
    {
        public MaDbContext (DbContextOptions<MaDbContext> options)
            : base(options)
        {            
        }

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
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Good>().HasKey(x => x.Id);
            modelBuilder.Entity<Market>().HasKey(x => x.Id);
            modelBuilder.Entity<AccessLevel>().HasKey(x => x.Id);
            modelBuilder.Entity<Catalogue>().HasKey(x => x.Id);
            modelBuilder.Entity<Person>().HasKey(x => x.Id);
            modelBuilder.Entity<TradeNetwork>().HasKey(x => x.Id);
            modelBuilder.Entity<Action>().HasKey(x => x.Id);

            modelBuilder.Entity<User>().HasOne(x => x.Person).WithOne(x=>x.User).HasPrincipalKey<User>(x=>x.PersonId);
            modelBuilder.Entity<User>().HasMany(x => x.AccessLevels);
            modelBuilder.Entity<Good>().HasMany(x => x.Actions);//WithMany
            modelBuilder.Entity<Good>().HasMany(x => x.Markets);//WithMany
            modelBuilder.Entity<Good>().HasMany(x => x.Catalogues);//WithMany
            modelBuilder.Entity<Market>().HasOne(x => x.TradeNetwork).WithMany(x => x.Markets).HasForeignKey(x => x.TradeNetworkId);
            modelBuilder.Entity<Catalogue>().HasOne(x => x.TradeNetwork).WithMany(x => x.Catalogues).HasForeignKey(x => x.TradeNetworkId);
            //modelBuilder.Entity<User>().HasMany<AccessLevel>(x=>x.AccessLevels)
            //modelBuilder.Ma
        }
    }
}

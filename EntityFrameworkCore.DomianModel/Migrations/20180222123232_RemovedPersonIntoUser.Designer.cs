﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EntityFrameworkCore.DomianModel.Migrations
{
    [DbContext(typeof(MaDbContext))]
    [Migration("20180222123232_RemovedPersonIntoUser")]
    partial class RemovedPersonIntoUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MarketAction.Server.AccessLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsRemoved");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<bool>("ReadAccessLevels");

                    b.Property<bool>("ReadActions");

                    b.Property<bool>("ReadAll");

                    b.Property<bool>("ReadCatalogues");

                    b.Property<bool>("ReadGoods");

                    b.Property<bool>("ReadTradeNetworks");

                    b.Property<bool>("ReadUsers");

                    b.Property<DateTime?>("RemoveDate");

                    b.Property<Guid?>("UserId");

                    b.Property<bool>("WriteAccessLevels");

                    b.Property<bool>("WriteActions");

                    b.Property<bool>("WriteAll");

                    b.Property<bool>("WriteCatalogues");

                    b.Property<bool>("WriteGoods");

                    b.Property<bool>("WriteTradeNetworks");

                    b.Property<bool>("WriteUsers");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AccessLevels");
                });

            modelBuilder.Entity("MarketAction.Server.Model.Action", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("Cost");

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime?>("DateActionEnd");

                    b.Property<DateTime?>("DateActionStart");

                    b.Property<string>("Description");

                    b.Property<Guid?>("GoodId");

                    b.Property<bool>("IsRemoved");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<string>("NewCost");

                    b.Property<DateTime?>("RemoveDate");

                    b.Property<string>("SalePercent");

                    b.Property<decimal?>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("MarketAction.Server.Model.Catalogue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid?>("GoodId");

                    b.Property<bool>("IsRemoved");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("RemoveDate");

                    b.Property<Guid?>("TradeNetworkId");

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.HasIndex("TradeNetworkId");

                    b.ToTable("Catalogues");
                });

            modelBuilder.Entity("MarketAction.Server.Model.Good", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cost");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsRemoved");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<decimal>("NewStr");

                    b.Property<DateTime?>("RemoveDate");

                    b.Property<decimal?>("Weight");

                    b.HasKey("Id");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("MarketAction.Server.Model.Market", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<Guid?>("GoodId");

                    b.Property<bool>("IsRemoved");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("RemoveDate");

                    b.Property<Guid?>("TradeNetworkId");

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.HasIndex("TradeNetworkId");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("MarketAction.Server.Model.TradeNetwork", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<bool>("IsRemoved");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("RemoveDate");

                    b.HasKey("Id");

                    b.ToTable("TradeNetworks");
                });

            modelBuilder.Entity("MarketAction.Server.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsRemoved");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<DateTime>("LastEntryDate");

                    b.Property<string>("LastName");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<DateTime?>("RemoveDate");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MarketAction.Server.AccessLevel", b =>
                {
                    b.HasOne("MarketAction.Server.Model.User")
                        .WithMany("AccessLevels")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MarketAction.Server.Model.Action", b =>
                {
                    b.HasOne("MarketAction.Server.Model.Good")
                        .WithMany("Actions")
                        .HasForeignKey("GoodId");
                });

            modelBuilder.Entity("MarketAction.Server.Model.Catalogue", b =>
                {
                    b.HasOne("MarketAction.Server.Model.Good")
                        .WithMany("Catalogues")
                        .HasForeignKey("GoodId");

                    b.HasOne("MarketAction.Server.Model.TradeNetwork", "TradeNetwork")
                        .WithMany("Catalogues")
                        .HasForeignKey("TradeNetworkId");
                });

            modelBuilder.Entity("MarketAction.Server.Model.Market", b =>
                {
                    b.HasOne("MarketAction.Server.Model.Good")
                        .WithMany("Markets")
                        .HasForeignKey("GoodId");

                    b.HasOne("MarketAction.Server.Model.TradeNetwork", "TradeNetwork")
                        .WithMany("Markets")
                        .HasForeignKey("TradeNetworkId");
                });
#pragma warning restore 612, 618
        }
    }
}

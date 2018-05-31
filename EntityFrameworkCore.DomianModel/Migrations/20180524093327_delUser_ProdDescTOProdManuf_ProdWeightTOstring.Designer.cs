﻿// <auto-generated />
using MarketAction.Server.EntityFrameworkCore.DomianModel;
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
    [Migration("20180524093327_delUser_ProdDescTOProdManuf_ProdWeightTOstring")]
    partial class delUser_ProdDescTOProdManuf_ProdWeightTOstring
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MarketAction.Server.Model.Action", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime?>("DateActionEnd");

                    b.Property<DateTime?>("DateActionStart");

                    b.Property<string>("Description");

                    b.Property<bool>("IsRemoved");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("RemoveDate");

                    b.Property<Guid?>("TradeNetworkId");

                    b.HasKey("Id");

                    b.HasIndex("TradeNetworkId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("MarketAction.Server.Model.Market", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<bool>("IsRemoved");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("RemoveDate");

                    b.Property<Guid?>("TradeNetworkId");

                    b.HasKey("Id");

                    b.HasIndex("TradeNetworkId");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("MarketAction.Server.Model.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ActionId");

                    b.Property<string>("Cost");

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsRemoved");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("RemoveDate");

                    b.Property<string>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.ToTable("Products");
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

            modelBuilder.Entity("MarketAction.Server.Model.Action", b =>
                {
                    b.HasOne("MarketAction.Server.Model.TradeNetwork", "TradeNetwork")
                        .WithMany("Actions")
                        .HasForeignKey("TradeNetworkId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("MarketAction.Server.Model.Market", b =>
                {
                    b.HasOne("MarketAction.Server.Model.TradeNetwork", "TradeNetwork")
                        .WithMany("Markets")
                        .HasForeignKey("TradeNetworkId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("MarketAction.Server.Model.Product", b =>
                {
                    b.HasOne("MarketAction.Server.Model.Action", "Action")
                        .WithMany("Products")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}

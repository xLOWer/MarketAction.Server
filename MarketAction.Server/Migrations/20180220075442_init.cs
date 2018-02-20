using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MarketAction.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cost = table.Column<decimal>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsRemoved = table.Column<bool>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RemoveDate = table.Column<DateTime>(nullable: true),
                    Weight = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradeNetworks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsRemoved = table.Column<bool>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RemoveDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeNetworks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    LastEntryDate = table.Column<DateTime>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: false),
                    RemoveDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_PersonId", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cost = table.Column<decimal>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DateActionEnd = table.Column<DateTime>(nullable: true),
                    DateActionStart = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GoodId = table.Column<Guid>(nullable: true),
                    IsRemoved = table.Column<bool>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NewCost = table.Column<string>(nullable: true),
                    RemoveDate = table.Column<DateTime>(nullable: true),
                    SalePercent = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_Goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalogues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    GoodId = table.Column<Guid>(nullable: true),
                    IsRemoved = table.Column<bool>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RemoveDate = table.Column<DateTime>(nullable: true),
                    TradeNetworkId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogues_Goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Catalogues_TradeNetworks_TradeNetworkId",
                        column: x => x.TradeNetworkId,
                        principalTable: "TradeNetworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    GoodId = table.Column<Guid>(nullable: true),
                    IsRemoved = table.Column<bool>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RemoveDate = table.Column<DateTime>(nullable: true),
                    TradeNetworkId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Markets_Goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Markets_TradeNetworks_TradeNetworkId",
                        column: x => x.TradeNetworkId,
                        principalTable: "TradeNetworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccessLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ReadAccessLevels = table.Column<bool>(nullable: false),
                    ReadAll = table.Column<bool>(nullable: false),
                    ReadCatalogues = table.Column<bool>(nullable: false),
                    ReadGoods = table.Column<bool>(nullable: false),
                    ReadPersons = table.Column<bool>(nullable: false),
                    ReadStamps = table.Column<bool>(nullable: false),
                    ReadTradeNetworks = table.Column<bool>(nullable: false),
                    ReadUsers = table.Column<bool>(nullable: false),
                    RemoveDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    WriteAccessLevels = table.Column<bool>(nullable: false),
                    WriteAll = table.Column<bool>(nullable: false),
                    WriteCatalogues = table.Column<bool>(nullable: false),
                    WriteGoods = table.Column<bool>(nullable: false),
                    WritePersons = table.Column<bool>(nullable: false),
                    WriteStamps = table.Column<bool>(nullable: false),
                    WriteTradeNetworks = table.Column<bool>(nullable: false),
                    WriteUsers = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessLevels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    IsRemoved = table.Column<bool>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    RemoveDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessLevels_UserId",
                table: "AccessLevels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_GoodId",
                table: "Actions",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogues_GoodId",
                table: "Catalogues",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogues_TradeNetworkId",
                table: "Catalogues",
                column: "TradeNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_GoodId",
                table: "Markets",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_TradeNetworkId",
                table: "Markets",
                column: "TradeNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserId",
                table: "Persons",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessLevels");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Catalogues");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "TradeNetworks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

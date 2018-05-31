using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.DomianModel.Migrations
{
    public partial class totalRefactoringModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Goods_GoodId",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Markets_Goods_GoodId",
                table: "Markets");

            migrationBuilder.DropForeignKey(
                name: "FK_Markets_TradeNetworks_TradeNetworkId",
                table: "Markets");

            migrationBuilder.DropTable(
                name: "AccessLevels");

            migrationBuilder.DropTable(
                name: "Catalogues");

            migrationBuilder.DropIndex(
                name: "IX_Markets_GoodId",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "GoodId",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "NewCost",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "SalePercent",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "NewStr",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "GoodId",
                table: "Actions",
                newName: "TradeNetworkId");

            migrationBuilder.RenameIndex(
                name: "IX_Actions_GoodId",
                table: "Actions",
                newName: "IX_Actions_TradeNetworkId");

            migrationBuilder.AddColumn<bool>(
                name: "ReadAccessLevels",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReadActions",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReadAll",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReadCatalogues",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReadProducts",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReadTradeNetworks",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReadUsers",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WriteAccessLevels",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WriteActions",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WriteAll",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WriteCatalogues",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WriteProducts",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WriteTradeNetworks",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WriteUsers",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ActionId",
                table: "Goods",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Goods_ActionId",
                table: "Goods",
                column: "ActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_TradeNetworks_TradeNetworkId",
                table: "Actions",
                column: "TradeNetworkId",
                principalTable: "TradeNetworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Actions_ActionId",
                table: "Goods",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Markets_TradeNetworks_TradeNetworkId",
                table: "Markets",
                column: "TradeNetworkId",
                principalTable: "TradeNetworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_TradeNetworks_TradeNetworkId",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Actions_ActionId",
                table: "Goods");

            migrationBuilder.DropForeignKey(
                name: "FK_Markets_TradeNetworks_TradeNetworkId",
                table: "Markets");

            migrationBuilder.DropIndex(
                name: "IX_Goods_ActionId",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "ReadAccessLevels",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReadActions",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReadAll",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReadCatalogues",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReadProducts",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReadTradeNetworks",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReadUsers",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WriteAccessLevels",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WriteActions",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WriteAll",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WriteCatalogues",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WriteProducts",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WriteTradeNetworks",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WriteUsers",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ActionId",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "TradeNetworkId",
                table: "Actions",
                newName: "GoodId");

            migrationBuilder.RenameIndex(
                name: "IX_Actions_TradeNetworkId",
                table: "Actions",
                newName: "IX_Actions_GoodId");

            migrationBuilder.AddColumn<Guid>(
                name: "GoodId",
                table: "Markets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Actions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewCost",
                table: "Actions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalePercent",
                table: "Actions",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "Actions",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NewStr",
                table: "Goods",
                nullable: false,
                defaultValue: 0m);

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
                    ReadActions = table.Column<bool>(nullable: false),
                    ReadAll = table.Column<bool>(nullable: false),
                    ReadCatalogues = table.Column<bool>(nullable: false),
                    ReadGoods = table.Column<bool>(nullable: false),
                    ReadTradeNetworks = table.Column<bool>(nullable: false),
                    ReadUsers = table.Column<bool>(nullable: false),
                    RemoveDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    WriteAccessLevels = table.Column<bool>(nullable: false),
                    WriteActions = table.Column<bool>(nullable: false),
                    WriteAll = table.Column<bool>(nullable: false),
                    WriteCatalogues = table.Column<bool>(nullable: false),
                    WriteGoods = table.Column<bool>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Markets_GoodId",
                table: "Markets",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLevels_UserId",
                table: "AccessLevels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogues_GoodId",
                table: "Catalogues",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogues_TradeNetworkId",
                table: "Catalogues",
                column: "TradeNetworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Goods_GoodId",
                table: "Actions",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Markets_Goods_GoodId",
                table: "Markets",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Markets_TradeNetworks_TradeNetworkId",
                table: "Markets",
                column: "TradeNetworkId",
                principalTable: "TradeNetworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

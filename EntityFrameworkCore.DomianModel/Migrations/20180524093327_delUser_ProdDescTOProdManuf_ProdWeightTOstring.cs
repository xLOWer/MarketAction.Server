using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.DomianModel.Migrations
{
    public partial class delUser_ProdDescTOProdManuf_ProdWeightTOstring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Actions_ActionId",
                table: "Goods");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goods",
                table: "Goods");

            migrationBuilder.RenameTable(
                name: "Goods",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Manufacturer");

            migrationBuilder.RenameIndex(
                name: "IX_Goods_ActionId",
                table: "Products",
                newName: "IX_Products_ActionId");

            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                table: "Products",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cost",
                table: "Products",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Actions_ActionId",
                table: "Products",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Actions_ActionId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Goods");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Goods",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ActionId",
                table: "Goods",
                newName: "IX_Goods_ActionId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Goods",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Goods",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goods",
                table: "Goods",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    IsRemoved = table.Column<bool>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    LastEntryDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    ReadAccessLevels = table.Column<bool>(nullable: false),
                    ReadActions = table.Column<bool>(nullable: false),
                    ReadAll = table.Column<bool>(nullable: false),
                    ReadCatalogues = table.Column<bool>(nullable: false),
                    ReadProducts = table.Column<bool>(nullable: false),
                    ReadTradeNetworks = table.Column<bool>(nullable: false),
                    ReadUsers = table.Column<bool>(nullable: false),
                    RemoveDate = table.Column<DateTime>(nullable: true),
                    WriteAccessLevels = table.Column<bool>(nullable: false),
                    WriteActions = table.Column<bool>(nullable: false),
                    WriteAll = table.Column<bool>(nullable: false),
                    WriteCatalogues = table.Column<bool>(nullable: false),
                    WriteProducts = table.Column<bool>(nullable: false),
                    WriteTradeNetworks = table.Column<bool>(nullable: false),
                    WriteUsers = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Actions_ActionId",
                table: "Goods",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}

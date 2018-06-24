using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.DomianModel.Migrations
{
    public partial class ProductFinderWebApiServerVersion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Markets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Markets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Markets",
                nullable: true);
        }
    }
}

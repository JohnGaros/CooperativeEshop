using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CooperativeEshop.Migrations
{
    public partial class AddBasePriceComponents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasePrice_PriceComponents_PriceComponentID",
                table: "BasePrice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasePrice",
                table: "BasePrice");

            migrationBuilder.RenameTable(
                name: "BasePrice",
                newName: "BasePriceComponents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasePriceComponents",
                table: "BasePriceComponents",
                column: "PriceComponentID");

            migrationBuilder.AddForeignKey(
                name: "FK_BasePriceComponents_PriceComponents_PriceComponentID",
                table: "BasePriceComponents",
                column: "PriceComponentID",
                principalTable: "PriceComponents",
                principalColumn: "PriceComponentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasePriceComponents_PriceComponents_PriceComponentID",
                table: "BasePriceComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasePriceComponents",
                table: "BasePriceComponents");

            migrationBuilder.RenameTable(
                name: "BasePriceComponents",
                newName: "BasePrice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasePrice",
                table: "BasePrice",
                column: "PriceComponentID");

            migrationBuilder.AddForeignKey(
                name: "FK_BasePrice_PriceComponents_PriceComponentID",
                table: "BasePrice",
                column: "PriceComponentID",
                principalTable: "PriceComponents",
                principalColumn: "PriceComponentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

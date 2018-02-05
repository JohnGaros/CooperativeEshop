using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CooperativeEshop.Migrations
{
    public partial class FixedName_ProductPriceComponents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceComponents_Products_ProductID",
                table: "PriceComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceComponents_AspNetUsers_SellerId",
                table: "PriceComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceComponents",
                table: "PriceComponents");

            migrationBuilder.RenameTable(
                name: "PriceComponents",
                newName: "ProductPriceComponents");

            migrationBuilder.RenameIndex(
                name: "IX_PriceComponents_SellerId",
                table: "ProductPriceComponents",
                newName: "IX_ProductPriceComponents_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_PriceComponents_ProductID",
                table: "ProductPriceComponents",
                newName: "IX_ProductPriceComponents_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPriceComponents",
                table: "ProductPriceComponents",
                column: "PriceComponentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPriceComponents_Products_ProductID",
                table: "ProductPriceComponents",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPriceComponents_AspNetUsers_SellerId",
                table: "ProductPriceComponents",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPriceComponents_Products_ProductID",
                table: "ProductPriceComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPriceComponents_AspNetUsers_SellerId",
                table: "ProductPriceComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPriceComponents",
                table: "ProductPriceComponents");

            migrationBuilder.RenameTable(
                name: "ProductPriceComponents",
                newName: "PriceComponents");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPriceComponents_SellerId",
                table: "PriceComponents",
                newName: "IX_PriceComponents_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPriceComponents_ProductID",
                table: "PriceComponents",
                newName: "IX_PriceComponents_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceComponents",
                table: "PriceComponents",
                column: "PriceComponentID");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceComponents_Products_ProductID",
                table: "PriceComponents",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceComponents_AspNetUsers_SellerId",
                table: "PriceComponents",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CooperativeEshop.Migrations
{
    public partial class AddBaseSalePrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasePrices",
                columns: table => new
                {
                    PriceComponentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductPriceComponentPriceComponentID = table.Column<int>(nullable: true),
                    basePrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasePrices", x => x.PriceComponentID);
                    table.ForeignKey(
                        name: "FK_BasePrices_ProductPriceComponents_ProductPriceComponentPriceComponentID",
                        column: x => x.ProductPriceComponentPriceComponentID,
                        principalTable: "ProductPriceComponents",
                        principalColumn: "PriceComponentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalePrices",
                columns: table => new
                {
                    PriceComponentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductPriceComponentPriceComponentID = table.Column<int>(nullable: true),
                    salePrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePrices", x => x.PriceComponentID);
                    table.ForeignKey(
                        name: "FK_SalePrices_ProductPriceComponents_ProductPriceComponentPriceComponentID",
                        column: x => x.ProductPriceComponentPriceComponentID,
                        principalTable: "ProductPriceComponents",
                        principalColumn: "PriceComponentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasePrices_ProductPriceComponentPriceComponentID",
                table: "BasePrices",
                column: "ProductPriceComponentPriceComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_SalePrices_ProductPriceComponentPriceComponentID",
                table: "SalePrices",
                column: "ProductPriceComponentPriceComponentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasePrices");

            migrationBuilder.DropTable(
                name: "SalePrices");
        }
    }
}

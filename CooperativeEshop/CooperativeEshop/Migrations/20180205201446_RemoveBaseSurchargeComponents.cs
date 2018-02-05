using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CooperativeEshop.Migrations
{
    public partial class RemoveBaseSurchargeComponents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasePriceComponents");

            migrationBuilder.DropTable(
                name: "SurchargePriceComponents");

            migrationBuilder.AddColumn<decimal>(
                name: "BasePrice",
                table: "PriceComponents",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Surcharge",
                table: "PriceComponents",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "PriceComponents");

            migrationBuilder.DropColumn(
                name: "Surcharge",
                table: "PriceComponents");

            migrationBuilder.CreateTable(
                name: "BasePriceComponents",
                columns: table => new
                {
                    PriceComponentID = table.Column<int>(nullable: false),
                    BasePrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasePriceComponents", x => x.PriceComponentID);
                    table.ForeignKey(
                        name: "FK_BasePriceComponents_PriceComponents_PriceComponentID",
                        column: x => x.PriceComponentID,
                        principalTable: "PriceComponents",
                        principalColumn: "PriceComponentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurchargePriceComponents",
                columns: table => new
                {
                    PriceComponentID = table.Column<int>(nullable: false),
                    Surcharge = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurchargePriceComponents", x => x.PriceComponentID);
                    table.ForeignKey(
                        name: "FK_SurchargePriceComponents_PriceComponents_PriceComponentID",
                        column: x => x.PriceComponentID,
                        principalTable: "PriceComponents",
                        principalColumn: "PriceComponentID",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}

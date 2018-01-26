using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CooperativeEshop.Migrations
{
    public partial class AddSurchargePriceComponents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurchargePriceComponents");
        }
    }
}

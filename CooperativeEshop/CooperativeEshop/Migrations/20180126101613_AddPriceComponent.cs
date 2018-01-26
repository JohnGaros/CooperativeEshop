using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CooperativeEshop.Migrations
{
    public partial class AddPriceComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierProducts");

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Individuals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Individuals",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PriceComponents",
                columns: table => new
                {
                    PriceComponentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    SellerId = table.Column<string>(nullable: false),
                    ThruDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceComponents", x => x.PriceComponentID);
                    table.ForeignKey(
                        name: "FK_PriceComponents_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceComponents_AspNetUsers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceComponents_ProductID",
                table: "PriceComponents",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PriceComponents_SellerId",
                table: "PriceComponents",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceComponents");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Individuals");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Individuals");

            migrationBuilder.CreateTable(
                name: "SupplierProducts",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    StockQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProducts", x => new { x.ProductID, x.UserID });
                    table.ForeignKey(
                        name: "FK_SupplierProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierProducts_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProducts_UserID",
                table: "SupplierProducts",
                column: "UserID");
        }
    }
}

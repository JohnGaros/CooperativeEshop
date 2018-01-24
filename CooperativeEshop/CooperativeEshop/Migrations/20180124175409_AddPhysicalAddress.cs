using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CooperativeEshop.Migrations
{
    public partial class AddPhysicalAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhysicalAddresses",
                columns: table => new
                {
                    CommChannelID = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    Line1 = table.Column<string>(nullable: true),
                    Line2 = table.Column<string>(nullable: true),
                    Zip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalAddresses", x => x.CommChannelID);
                    table.ForeignKey(
                        name: "FK_PhysicalAddresses_CommunicationChannels_CommChannelID",
                        column: x => x.CommChannelID,
                        principalTable: "CommunicationChannels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhysicalAddresses");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CooperativeEshop.Migrations
{
    public partial class AddPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    CommChannelID = table.Column<int>(nullable: false),
                    AreaCode = table.Column<int>(nullable: false),
                    CountryCode = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.CommChannelID);
                    table.ForeignKey(
                        name: "FK_Phones_CommunicationChannels_CommChannelID",
                        column: x => x.CommChannelID,
                        principalTable: "CommunicationChannels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");
        }
    }
}

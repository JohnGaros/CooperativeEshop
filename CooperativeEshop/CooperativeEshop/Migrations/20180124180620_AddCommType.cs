using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CooperativeEshop.Migrations
{
    public partial class AddCommType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeID",
                table: "CommunicationChannels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CommunicationChannelTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationChannelTypes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationChannels_TypeID",
                table: "CommunicationChannels",
                column: "TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationChannels_CommunicationChannelTypes_TypeID",
                table: "CommunicationChannels",
                column: "TypeID",
                principalTable: "CommunicationChannelTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunicationChannels_CommunicationChannelTypes_TypeID",
                table: "CommunicationChannels");

            migrationBuilder.DropTable(
                name: "CommunicationChannelTypes");

            migrationBuilder.DropIndex(
                name: "IX_CommunicationChannels_TypeID",
                table: "CommunicationChannels");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "CommunicationChannels");
        }
    }
}

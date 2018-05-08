using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IcarufyGarden.Migrations
{
    public partial class gardenbedowners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GardenBedOwners",
                columns: table => new
                {
                    OwnerId = table.Column<string>(nullable: false),
                    GardenBedId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenBedOwners", x => new { x.OwnerId, x.GardenBedId });
                    table.ForeignKey(
                        name: "FK_GardenBedOwners_GardenBeds_GardenBedId",
                        column: x => x.GardenBedId,
                        principalTable: "GardenBeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenBedOwners_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenBedOwners_GardenBedId",
                table: "GardenBedOwners",
                column: "GardenBedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenBedOwners");
        }
    }
}

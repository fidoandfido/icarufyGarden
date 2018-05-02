using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IcarufyGarden.Migrations
{
    public partial class GardenTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_GardenBeds_GardenBedId",
                table: "Plants");

            migrationBuilder.RenameColumn(
                name: "GardenBedId",
                table: "Plants",
                newName: "locationId");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_GardenBedId",
                table: "Plants",
                newName: "IX_Plants_locationId");

            migrationBuilder.AddColumn<DateTime>(
                name: "datePlanted",
                table: "Plants",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GardenBedTasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false),
                    GardenBedId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenBedTasks", x => new { x.TaskId, x.GardenBedId });
                    table.ForeignKey(
                        name: "FK_GardenBedTasks_GardenBeds_GardenBedId",
                        column: x => x.GardenBedId,
                        principalTable: "GardenBeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenBedTasks_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenBedTasks_GardenBedId",
                table: "GardenBedTasks",
                column: "GardenBedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_GardenBeds_locationId",
                table: "Plants",
                column: "locationId",
                principalTable: "GardenBeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_GardenBeds_locationId",
                table: "Plants");

            migrationBuilder.DropTable(
                name: "GardenBedTasks");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropColumn(
                name: "datePlanted",
                table: "Plants");

            migrationBuilder.RenameColumn(
                name: "locationId",
                table: "Plants",
                newName: "GardenBedId");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_locationId",
                table: "Plants",
                newName: "IX_Plants_GardenBedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_GardenBeds_GardenBedId",
                table: "Plants",
                column: "GardenBedId",
                principalTable: "GardenBeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

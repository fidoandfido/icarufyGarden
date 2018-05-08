using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IcarufyGarden.Migrations
{
    public partial class gardenbedowner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ownerId",
                table: "GardenBeds",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GardenBeds_ownerId",
                table: "GardenBeds",
                column: "ownerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GardenBeds_AspNetUsers_ownerId",
                table: "GardenBeds",
                column: "ownerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GardenBeds_AspNetUsers_ownerId",
                table: "GardenBeds");

            migrationBuilder.DropIndex(
                name: "IX_GardenBeds_ownerId",
                table: "GardenBeds");

            migrationBuilder.DropColumn(
                name: "ownerId",
                table: "GardenBeds");
        }
    }
}

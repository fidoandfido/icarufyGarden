using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IcarufyGarden.Migrations
{
    public partial class gardenbedcreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GardenBeds_AspNetUsers_ownerId",
                table: "GardenBeds");

            migrationBuilder.RenameColumn(
                name: "ownerId",
                table: "GardenBeds",
                newName: "creatorId");

            migrationBuilder.RenameIndex(
                name: "IX_GardenBeds_ownerId",
                table: "GardenBeds",
                newName: "IX_GardenBeds_creatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_GardenBeds_AspNetUsers_creatorId",
                table: "GardenBeds",
                column: "creatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GardenBeds_AspNetUsers_creatorId",
                table: "GardenBeds");

            migrationBuilder.RenameColumn(
                name: "creatorId",
                table: "GardenBeds",
                newName: "ownerId");

            migrationBuilder.RenameIndex(
                name: "IX_GardenBeds_creatorId",
                table: "GardenBeds",
                newName: "IX_GardenBeds_ownerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GardenBeds_AspNetUsers_ownerId",
                table: "GardenBeds",
                column: "ownerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IcarufyGarden.Migrations
{
    public partial class GardenTasksLinked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GardenBedTasks_Task_TaskId",
                table: "GardenBedTasks");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.CreateTable(
                name: "GardenTask",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenTask", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GardenBedTasks_GardenTask_TaskId",
                table: "GardenBedTasks",
                column: "TaskId",
                principalTable: "GardenTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GardenBedTasks_GardenTask_TaskId",
                table: "GardenBedTasks");

            migrationBuilder.DropTable(
                name: "GardenTask");

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

            migrationBuilder.AddForeignKey(
                name: "FK_GardenBedTasks_Task_TaskId",
                table: "GardenBedTasks",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

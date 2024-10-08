using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamblingGameWebApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    InitialPoint = table.Column<int>(type: "int", nullable: false),
                    CurrentPoint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GambleRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvestPoint = table.Column<int>(type: "int", nullable: false),
                    SelectedNumber = table.Column<int>(type: "int", nullable: false),
                    ResultState = table.Column<int>(type: "int", nullable: false),
                    ResultPoints = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GambleRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GambleRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CurrentPoint", "InitialPoint", "Name" },
                values: new object[,]
                {
                    { new Guid("0b986f14-eadc-4a32-95b5-2c2649f51412"), 0, 9, "Mouse" },
                    { new Guid("baf2c21f-a79e-4cf3-84c8-4d93e69aa6d6"), 18, 12, "Saam" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GambleRequests_UserId",
                table: "GambleRequests",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GambleRequests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

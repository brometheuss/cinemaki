using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class Rated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatedId",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rateds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rateds", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_RatedId",
                table: "Movies",
                column: "RatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Rateds_RatedId",
                table: "Movies",
                column: "RatedId",
                principalTable: "Rateds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Rateds_RatedId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Rateds");

            migrationBuilder.DropIndex(
                name: "IX_Movies_RatedId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "RatedId",
                table: "Movies");
        }
    }
}

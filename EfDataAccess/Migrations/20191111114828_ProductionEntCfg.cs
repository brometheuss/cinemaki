using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class ProductionEntCfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductionId",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Production",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ProductionId",
                table: "Movies",
                column: "ProductionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Production_ProductionId",
                table: "Movies",
                column: "ProductionId",
                principalTable: "Production",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Production_ProductionId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Production");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ProductionId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ProductionId",
                table: "Movies");
        }
    }
}

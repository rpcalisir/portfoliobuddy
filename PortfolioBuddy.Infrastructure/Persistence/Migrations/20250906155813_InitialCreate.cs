using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioBuddy.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InvestmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    Unit = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    ValueInTL = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentDetails_Investments_InvestmentId",
                        column: x => x.InvestmentId,
                        principalTable: "Investments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentDetails_InvestmentId",
                table: "InvestmentDetails",
                column: "InvestmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentDetails");

            migrationBuilder.DropTable(
                name: "Investments");
        }
    }
}

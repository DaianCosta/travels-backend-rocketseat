using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class _01Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Travel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Destiny = table.Column<string>(maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Travel");
        }
    }
}

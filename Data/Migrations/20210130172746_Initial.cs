using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResultConsumeApiExternals",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(maxLength: 2, nullable: false),
                    Province = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CityCode = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: false),
                    Lon = table.Column<string>(nullable: false),
                    Confirmed = table.Column<int>(nullable: false),
                    Deaths = table.Column<int>(nullable: false),
                    Recovered = table.Column<int>(nullable: false),
                    Active = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultConsumeApiExternals", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultConsumeApiExternals");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalCar.Migrations
{
    public partial class CentroDeCusto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "CentroDeCusto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "CentroDeCusto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

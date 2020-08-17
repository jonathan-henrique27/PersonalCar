using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalCar.Migrations
{
    public partial class atualizado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destino",
                table: "Passageiro");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Passageiro");

            migrationBuilder.DropColumn(
                name: "Origem",
                table: "Passageiro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destino",
                table: "Passageiro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Passageiro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origem",
                table: "Passageiro",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

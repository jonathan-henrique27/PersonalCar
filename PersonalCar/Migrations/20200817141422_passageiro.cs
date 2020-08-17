using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalCar.Migrations
{
    public partial class passageiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destino",
                table: "Passageiro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Passageiro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origem",
                table: "Passageiro",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

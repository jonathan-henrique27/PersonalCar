using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalCar.Migrations
{
    public partial class clienteid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnidadeDeNegocio_Cliente_ClienteId",
                table: "UnidadeDeNegocio");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Cliente_ClienteId",
                table: "Voucher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Cliente",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadeDeNegocio_Cliente_ClienteId",
                table: "UnidadeDeNegocio",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Cliente_ClienteId",
                table: "Voucher",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnidadeDeNegocio_Cliente_ClienteId",
                table: "UnidadeDeNegocio");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Cliente_ClienteId",
                table: "Voucher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadeDeNegocio_Cliente_ClienteId",
                table: "UnidadeDeNegocio",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Cliente_ClienteId",
                table: "Voucher",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

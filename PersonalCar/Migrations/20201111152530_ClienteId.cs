using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalCar.Migrations
{
    public partial class ClienteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Cliente_ClienteId",
                table: "Voucher");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Voucher",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Cliente_ClienteId",
                table: "Voucher",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Cliente_ClienteId",
                table: "Voucher");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Voucher",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Cliente_ClienteId",
                table: "Voucher",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

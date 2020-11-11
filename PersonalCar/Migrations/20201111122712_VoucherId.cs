using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalCar.Migrations
{
    public partial class VoucherId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_CentroDeCusto_CentroDeCustoId",
                table: "Voucher");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Cliente_ClienteId",
                table: "Voucher");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Solicitante_SolicitanteId",
                table: "Voucher");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_UnidadeDeNegocio_UnidadeId",
                table: "Voucher");

            migrationBuilder.DropIndex(
                name: "IX_Voucher_UnidadeId",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "ControleDeTaxiamentoId",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "UnidadeId",
                table: "Voucher");

            migrationBuilder.AlterColumn<int>(
                name: "SolicitanteId",
                table: "Voucher",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Voucher",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CentroDeCustoId",
                table: "Voucher",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnidadeDeNegocioId",
                table: "Voucher",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_UnidadeDeNegocioId",
                table: "Voucher",
                column: "UnidadeDeNegocioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_CentroDeCusto_CentroDeCustoId",
                table: "Voucher",
                column: "CentroDeCustoId",
                principalTable: "CentroDeCusto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Cliente_ClienteId",
                table: "Voucher",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Solicitante_SolicitanteId",
                table: "Voucher",
                column: "SolicitanteId",
                principalTable: "Solicitante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_UnidadeDeNegocio_UnidadeDeNegocioId",
                table: "Voucher",
                column: "UnidadeDeNegocioId",
                principalTable: "UnidadeDeNegocio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_CentroDeCusto_CentroDeCustoId",
                table: "Voucher");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Cliente_ClienteId",
                table: "Voucher");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Solicitante_SolicitanteId",
                table: "Voucher");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_UnidadeDeNegocio_UnidadeDeNegocioId",
                table: "Voucher");

            migrationBuilder.DropIndex(
                name: "IX_Voucher_UnidadeDeNegocioId",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "UnidadeDeNegocioId",
                table: "Voucher");

            migrationBuilder.AlterColumn<int>(
                name: "SolicitanteId",
                table: "Voucher",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Voucher",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CentroDeCustoId",
                table: "Voucher",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ControleDeTaxiamentoId",
                table: "Voucher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnidadeId",
                table: "Voucher",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_UnidadeId",
                table: "Voucher",
                column: "UnidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_CentroDeCusto_CentroDeCustoId",
                table: "Voucher",
                column: "CentroDeCustoId",
                principalTable: "CentroDeCusto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Cliente_ClienteId",
                table: "Voucher",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Solicitante_SolicitanteId",
                table: "Voucher",
                column: "SolicitanteId",
                principalTable: "Solicitante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_UnidadeDeNegocio_UnidadeId",
                table: "Voucher",
                column: "UnidadeId",
                principalTable: "UnidadeDeNegocio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

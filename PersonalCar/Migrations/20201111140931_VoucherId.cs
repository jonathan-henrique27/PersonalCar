using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalCar.Migrations
{
    public partial class VoucherId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFantasia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motorista",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    CNH = table.Column<int>(nullable: false),
                    CnhVenc = table.Column<DateTime>(nullable: false),
                    Nascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Ano = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadeDeNegocio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFantasia = table.Column<string>(maxLength: 60, nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 60, nullable: false),
                    Cnpj = table.Column<string>(maxLength: 18, nullable: false),
                    Cep = table.Column<string>(maxLength: 9, nullable: false),
                    Numero = table.Column<string>(maxLength: 6, nullable: false),
                    Endereco = table.Column<string>(maxLength: 60, nullable: true),
                    Bairro = table.Column<string>(maxLength: 40, nullable: true),
                    Cidade = table.Column<string>(maxLength: 40, nullable: true),
                    Estado = table.Column<string>(maxLength: 2, nullable: true),
                    Ibge = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeDeNegocio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnidadeDeNegocio_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CentroDeCusto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    UnidadeDeNegocioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroDeCusto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroDeCusto_UnidadeDeNegocio_UnidadeDeNegocioId",
                        column: x => x.UnidadeDeNegocioId,
                        principalTable: "UnidadeDeNegocio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Telecom = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Cargo = table.Column<string>(maxLength: 30, nullable: true),
                    UnidadeDeNegocioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitante_UnidadeDeNegocio_UnidadeDeNegocioId",
                        column: x => x.UnidadeDeNegocioId,
                        principalTable: "UnidadeDeNegocio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    ControleDeTaxiamento = table.Column<string>(nullable: true),
                    DataSolicitacao = table.Column<DateTime>(nullable: false),
                    DataInicial = table.Column<DateTime>(nullable: false),
                    DataFinal = table.Column<DateTime>(nullable: false),
                    ValorPedagio = table.Column<double>(nullable: false),
                    ValorEstacionamento = table.Column<double>(nullable: false),
                    KmInicial = table.Column<double>(nullable: false),
                    KmFinal = table.Column<double>(nullable: false),
                    Placa = table.Column<string>(nullable: true),
                    ValorTotalDaViagem = table.Column<double>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    UnidadeDeNegocioId = table.Column<int>(nullable: true),
                    SolicitanteId = table.Column<int>(nullable: true),
                    CentroDeCustoId = table.Column<int>(nullable: true),
                    MotoristaId = table.Column<int>(nullable: true),
                    VeiculoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voucher_CentroDeCusto_CentroDeCustoId",
                        column: x => x.CentroDeCustoId,
                        principalTable: "CentroDeCusto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voucher_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voucher_Motorista_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Motorista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voucher_Solicitante_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voucher_UnidadeDeNegocio_UnidadeDeNegocioId",
                        column: x => x.UnidadeDeNegocioId,
                        principalTable: "UnidadeDeNegocio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voucher_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoraParada",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Fim = table.Column<DateTime>(nullable: false),
                    VoucherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoraParada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoraParada_Voucher_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Voucher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passageiro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    VoucherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passageiro_Voucher_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Voucher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origem = table.Column<string>(nullable: true),
                    Destino = table.Column<string>(nullable: true),
                    TotalKM = table.Column<double>(nullable: false),
                    ValorPorKm = table.Column<double>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false),
                    VoucherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Voucher_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Voucher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentroDeCusto_UnidadeDeNegocioId",
                table: "CentroDeCusto",
                column: "UnidadeDeNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_HoraParada_VoucherId",
                table: "HoraParada",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Passageiro_VoucherId",
                table: "Passageiro",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_VoucherId",
                table: "Produto",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitante_UnidadeDeNegocioId",
                table: "Solicitante",
                column: "UnidadeDeNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadeDeNegocio_ClienteId",
                table: "UnidadeDeNegocio",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_CentroDeCustoId",
                table: "Voucher",
                column: "CentroDeCustoId");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_ClienteId",
                table: "Voucher",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_MotoristaId",
                table: "Voucher",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_SolicitanteId",
                table: "Voucher",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_UnidadeDeNegocioId",
                table: "Voucher",
                column: "UnidadeDeNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_VeiculoId",
                table: "Voucher",
                column: "VeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoraParada");

            migrationBuilder.DropTable(
                name: "Passageiro");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "CentroDeCusto");

            migrationBuilder.DropTable(
                name: "Motorista");

            migrationBuilder.DropTable(
                name: "Solicitante");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "UnidadeDeNegocio");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}

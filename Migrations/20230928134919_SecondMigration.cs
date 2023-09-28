using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api_portaria.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_entrada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Transportadora = table.Column<string>(type: "text", nullable: true),
                    Cliente = table.Column<string>(type: "text", nullable: true),
                    DataHoraEntrada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraSaida = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TempoParaAtendimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_entrada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_responsavel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_responsavel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_PrimeiroResponsavelEntrada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntradaId = table.Column<int>(type: "integer", nullable: false),
                    ResponsavelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_PrimeiroResponsavelEntrada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_PrimeiroResponsavelEntrada_tab_entrada_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "tab_entrada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_PrimeiroResponsavelEntrada_tab_responsavel_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "tab_responsavel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tab_SegundoResponsavelEntrada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntradaId = table.Column<int>(type: "integer", nullable: false),
                    ResponsavelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_SegundoResponsavelEntrada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_SegundoResponsavelEntrada_tab_entrada_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "tab_entrada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_SegundoResponsavelEntrada_tab_responsavel_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "tab_responsavel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_PrimeiroResponsavelEntrada_EntradaId",
                table: "tab_PrimeiroResponsavelEntrada",
                column: "EntradaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_PrimeiroResponsavelEntrada_ResponsavelId",
                table: "tab_PrimeiroResponsavelEntrada",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_SegundoResponsavelEntrada_EntradaId",
                table: "tab_SegundoResponsavelEntrada",
                column: "EntradaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_SegundoResponsavelEntrada_ResponsavelId",
                table: "tab_SegundoResponsavelEntrada",
                column: "ResponsavelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_PrimeiroResponsavelEntrada");

            migrationBuilder.DropTable(
                name: "tab_SegundoResponsavelEntrada");

            migrationBuilder.DropTable(
                name: "tab_entrada");

            migrationBuilder.DropTable(
                name: "tab_responsavel");
        }
    }
}

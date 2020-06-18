using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BonosCalculadora.Migrations.DbBonos
{
    public partial class models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capitalizacion",
                columns: table => new
                {
                    CapitalizacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCapitalizacion = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitalizacion", x => x.CapitalizacionId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(maxLength: 256, nullable: true),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Dni = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Correo = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "DiasAño",
                columns: table => new
                {
                    DiasAñoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalculadoraId = table.Column<int>(nullable: true),
                    Dias = table.Column<int>(unicode: false, maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasAño", x => x.DiasAñoId);
                });

            migrationBuilder.CreateTable(
                name: "FrecuenciaPago",
                columns: table => new
                {
                    FrecuenciaPagoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipofrecuencia = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Diasfrecuencia = table.Column<int>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrecuenciaPago", x => x.FrecuenciaPagoId);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    MetodoPagoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMetodo = table.Column<string>(unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.MetodoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "TasaInteres",
                columns: table => new
                {
                    TasaInteresId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tasa = table.Column<double>(unicode: false, maxLength: 10, nullable: false),
                    Tipotasa = table.Column<string>(unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasaInteres", x => x.TasaInteresId);
                });

            migrationBuilder.CreateTable(
                name: "Historial",
                columns: table => new
                {
                    HistorialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: true),
                    Observacion = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial", x => x.HistorialId);
                    table.ForeignKey(
                        name: "FK_Historial_Ciente",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calculadora",
                columns: table => new
                {
                    CalculadoraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: false),
                    FrecuenciaPagoId = table.Column<int>(nullable: false),
                    DiasAñoId = table.Column<int>(nullable: false),
                    TasaInteresId = table.Column<int>(nullable: false),
                    CapitalizacionId = table.Column<int>(nullable: false),
                    MetodoPagoId = table.Column<int>(nullable: false),
                    Vnominal = table.Column<double>(unicode: false, maxLength: 15, nullable: false),
                    Vcomercial = table.Column<double>(unicode: false, maxLength: 15, nullable: false),
                    NAños = table.Column<int>(unicode: false, maxLength: 11, nullable: false),
                    Cok = table.Column<double>(unicode: false, maxLength: 15, nullable: false),
                    ImRenta = table.Column<double>(unicode: false, maxLength: 15, nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    Prima = table.Column<double>(unicode: false, maxLength: 15, nullable: false),
                    Estructuración = table.Column<double>(unicode: false, maxLength: 15, nullable: false),
                    Colocación = table.Column<double>(unicode: false, maxLength: 15, nullable: false),
                    Flotacion = table.Column<double>(unicode: false, maxLength: 15, nullable: false),
                    Cavali = table.Column<double>(unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculadora", x => x.CalculadoraId);
                    table.ForeignKey(
                        name: "FK_Calculadora_Capitalizacion",
                        column: x => x.CapitalizacionId,
                        principalTable: "Capitalizacion",
                        principalColumn: "CapitalizacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calculadora_Ciente",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calculadora_DiasAño",
                        column: x => x.DiasAñoId,
                        principalTable: "DiasAño",
                        principalColumn: "DiasAñoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calculadora_FrecuenciaPago",
                        column: x => x.FrecuenciaPagoId,
                        principalTable: "FrecuenciaPago",
                        principalColumn: "FrecuenciaPagoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calculadora_MetodoPago",
                        column: x => x.MetodoPagoId,
                        principalTable: "MetodoPago",
                        principalColumn: "MetodoPagoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calculadora_TasaInteres",
                        column: x => x.TasaInteresId,
                        principalTable: "TasaInteres",
                        principalColumn: "TasaInteresId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculadora_CapitalizacionId",
                table: "Calculadora",
                column: "CapitalizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculadora_ClienteId",
                table: "Calculadora",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculadora_DiasAñoId",
                table: "Calculadora",
                column: "DiasAñoId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculadora_FrecuenciaPagoId",
                table: "Calculadora",
                column: "FrecuenciaPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculadora_MetodoPagoId",
                table: "Calculadora",
                column: "MetodoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculadora_TasaInteresId",
                table: "Calculadora",
                column: "TasaInteresId");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_ClienteId",
                table: "Historial",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculadora");

            migrationBuilder.DropTable(
                name: "Historial");

            migrationBuilder.DropTable(
                name: "Capitalizacion");

            migrationBuilder.DropTable(
                name: "DiasAño");

            migrationBuilder.DropTable(
                name: "FrecuenciaPago");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "TasaInteres");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}

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
                    TipoCapitalizacion = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
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
                name: "FrecuenciaPago",
                columns: table => new
                {
                    FrecuenciaPagoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipofrecuencia = table.Column<string>(unicode: false, maxLength: 15, nullable: false)
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
                    TipoTasa = table.Column<string>(unicode: false, maxLength: 15, nullable: true)
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
                    FrecuenciaPagoId = table.Column<int>(nullable: false),
                    TasaInteresId = table.Column<int>(nullable: false),
                    CapitalizacionId = table.Column<int>(nullable: false),
                    MetodoPagoId = table.Column<int>(nullable: false),
                    Vnominal = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Vcomercial = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    TasaDeInteres = table.Column<string>(nullable: false),
                    NAños = table.Column<int>(unicode: false, maxLength: 11, nullable: false),
                    DiasAño = table.Column<int>(nullable: false),
                    Cok = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    Prima = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    Estructuración = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    Colocación = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    Flotacion = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    Cavali = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    ClienteId = table.Column<int>(nullable: true)
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
                        name: "FK_Calculadora_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
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

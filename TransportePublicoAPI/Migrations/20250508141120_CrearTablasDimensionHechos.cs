using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportePublicoAPI.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablasDimensionHechos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distancias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistanciaKm = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distancias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frecuencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrecuenciaLunesASabado = table.Column<int>(type: "int", nullable: false),
                    FrecuenciaDomingoYFestivos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frecuencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rutas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreRuta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sentido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstacionInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstacionFin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tiempos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraInicioLunesASabado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraFinLunesASabado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicioDomingoYFestivos = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraFinDomingoYFestivos = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiempos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HechosRutas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutaId = table.Column<int>(type: "int", nullable: false),
                    TiempoId = table.Column<int>(type: "int", nullable: false),
                    FrecuenciaId = table.Column<int>(type: "int", nullable: false),
                    DistanciaId = table.Column<int>(type: "int", nullable: false),
                    TiempoDestinoMinutosLunesASab = table.Column<int>(type: "int", nullable: false),
                    TiempoTotalMinutosLunesASab = table.Column<int>(type: "int", nullable: false),
                    TiempoDestinoMinutosDomYFestivos = table.Column<int>(type: "int", nullable: false),
                    TiempoTotalMinutosDomYFestivos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HechosRutas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HechosRutas_Distancias_DistanciaId",
                        column: x => x.DistanciaId,
                        principalTable: "Distancias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HechosRutas_Frecuencias_FrecuenciaId",
                        column: x => x.FrecuenciaId,
                        principalTable: "Frecuencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HechosRutas_Rutas_RutaId",
                        column: x => x.RutaId,
                        principalTable: "Rutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HechosRutas_Tiempos_TiempoId",
                        column: x => x.TiempoId,
                        principalTable: "Tiempos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HechosRutas_DistanciaId",
                table: "HechosRutas",
                column: "DistanciaId");

            migrationBuilder.CreateIndex(
                name: "IX_HechosRutas_FrecuenciaId",
                table: "HechosRutas",
                column: "FrecuenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_HechosRutas_RutaId",
                table: "HechosRutas",
                column: "RutaId");

            migrationBuilder.CreateIndex(
                name: "IX_HechosRutas_TiempoId",
                table: "HechosRutas",
                column: "TiempoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HechosRutas");

            migrationBuilder.DropTable(
                name: "Distancias");

            migrationBuilder.DropTable(
                name: "Frecuencias");

            migrationBuilder.DropTable(
                name: "Rutas");

            migrationBuilder.DropTable(
                name: "Tiempos");
        }
    }
}

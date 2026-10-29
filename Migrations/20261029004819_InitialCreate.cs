using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExamenGrupal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oficiales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombres = table.Column<string>(type: "text", nullable: false),
                    Apellidos = table.Column<string>(type: "text", nullable: false),
                    Grado = table.Column<string>(type: "text", nullable: false),
                    NumeroEscalafon = table.Column<string>(type: "text", nullable: false),
                    Cargo = table.Column<string>(type: "text", nullable: false),
                    Unidad = table.Column<string>(type: "text", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oficiales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accidentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoCaso = table.Column<string>(type: "text", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TipoAccidente = table.Column<string>(type: "text", nullable: false),
                    Gravedad = table.Column<string>(type: "text", nullable: false),
                    Distrito = table.Column<string>(type: "text", nullable: false),
                    ZonaBarrio = table.Column<string>(type: "text", nullable: false),
                    DireccionReferencia = table.Column<string>(type: "text", nullable: false),
                    Latitud = table.Column<decimal>(type: "numeric", nullable: true),
                    Longitud = table.Column<decimal>(type: "numeric", nullable: true),
                    CondicionClimatica = table.Column<string>(type: "text", nullable: true),
                    EstadoCalzada = table.Column<string>(type: "text", nullable: true),
                    EstadoCaso = table.Column<string>(type: "text", nullable: true),
                    JuzgadoOInstitucion = table.Column<string>(type: "text", nullable: true),
                    NumeroCuadernoInvestigacion = table.Column<string>(type: "text", nullable: true),
                    MotivoPase = table.Column<string>(type: "text", nullable: true),
                    Observaciones = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OficialAsignadoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accidentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accidentes_Oficiales_OficialAsignadoId",
                        column: x => x.OficialAsignadoId,
                        principalTable: "Oficiales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PeritajesTecnicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaPeritaje = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VelocidadEstimadaImpactoKmh = table.Column<decimal>(type: "numeric", nullable: true),
                    HuellaFrenadoMetros = table.Column<decimal>(type: "numeric", nullable: true),
                    FactorDeterminante = table.Column<string>(type: "text", nullable: false),
                    Conclusiones = table.Column<string>(type: "text", nullable: false),
                    CroquisUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AccidenteId = table.Column<int>(type: "integer", nullable: false),
                    PeritoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeritajesTecnicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeritajesTecnicos_Accidentes_AccidenteId",
                        column: x => x.AccidenteId,
                        principalTable: "Accidentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeritajesTecnicos_Oficiales_PeritoId",
                        column: x => x.PeritoId,
                        principalTable: "Oficiales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiculosInvolucrados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Placa = table.Column<string>(type: "text", nullable: false),
                    Marca = table.Column<string>(type: "text", nullable: true),
                    Modelo = table.Column<string>(type: "text", nullable: true),
                    TipoVehiculo = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true),
                    NumeroChasis = table.Column<string>(type: "text", nullable: true),
                    SoatVigente = table.Column<bool>(type: "boolean", nullable: false),
                    Aseguradora = table.Column<string>(type: "text", nullable: true),
                    DescripcionDanios = table.Column<string>(type: "text", nullable: true),
                    RemolcadoA = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AccidenteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculosInvolucrados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiculosInvolucrados_Accidentes_AccidenteId",
                        column: x => x.AccidenteId,
                        principalTable: "Accidentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonasInvolucradas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombres = table.Column<string>(type: "text", nullable: false),
                    Apellidos = table.Column<string>(type: "text", nullable: false),
                    Ci = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Rol = table.Column<string>(type: "text", nullable: true),
                    NumeroLicencia = table.Column<string>(type: "text", nullable: true),
                    CategoriaLicencia = table.Column<string>(type: "text", nullable: true),
                    GradoAlcoholemiaGral = table.Column<decimal>(type: "numeric", nullable: true),
                    EstadoAlcoholemia = table.Column<string>(type: "text", nullable: true),
                    NumeroActaDosaje = table.Column<string>(type: "text", nullable: true),
                    Laboratorio = table.Column<string>(type: "text", nullable: true),
                    EstadoSalud = table.Column<string>(type: "text", nullable: true),
                    CentroMedicoTraslado = table.Column<string>(type: "text", nullable: true),
                    DiagnosticoPreliminar = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AccidenteId = table.Column<int>(type: "integer", nullable: false),
                    VehiculoId = table.Column<int>(type: "integer", nullable: true),
                    VehiculoInvolucradoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonasInvolucradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonasInvolucradas_Accidentes_AccidenteId",
                        column: x => x.AccidenteId,
                        principalTable: "Accidentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonasInvolucradas_VehiculosInvolucrados_VehiculoInvolucr~",
                        column: x => x.VehiculoInvolucradoId,
                        principalTable: "VehiculosInvolucrados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accidentes_OficialAsignadoId",
                table: "Accidentes",
                column: "OficialAsignadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PeritajesTecnicos_AccidenteId",
                table: "PeritajesTecnicos",
                column: "AccidenteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeritajesTecnicos_PeritoId",
                table: "PeritajesTecnicos",
                column: "PeritoId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasInvolucradas_AccidenteId",
                table: "PersonasInvolucradas",
                column: "AccidenteId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasInvolucradas_VehiculoInvolucradoId",
                table: "PersonasInvolucradas",
                column: "VehiculoInvolucradoId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculosInvolucrados_AccidenteId",
                table: "VehiculosInvolucrados",
                column: "AccidenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeritajesTecnicos");

            migrationBuilder.DropTable(
                name: "PersonasInvolucradas");

            migrationBuilder.DropTable(
                name: "VehiculosInvolucrados");

            migrationBuilder.DropTable(
                name: "Accidentes");

            migrationBuilder.DropTable(
                name: "Oficiales");
        }
    }
}

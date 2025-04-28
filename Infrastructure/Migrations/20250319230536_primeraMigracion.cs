using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class primeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enemigo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    nivelAmenaza = table.Column<int>(type: "integer", nullable: false),
                    recompensas = table.Column<List<string>>(type: "text[]", nullable: false),
                    salud = table.Column<int>(type: "integer", nullable: false),
                    energia = table.Column<int>(type: "integer", nullable: false),
                    fuerza = table.Column<int>(type: "integer", nullable: false),
                    defensa = table.Column<int>(type: "integer", nullable: false),
                    inteligencia = table.Column<int>(type: "integer", nullable: false),
                    agilidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemigo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    casco = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    armadura = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    arma1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    arma2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    guanteletes = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    grebas = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mision",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    objetivos = table.Column<List<string>>(type: "text[]", nullable: false),
                    recompensas = table.Column<List<string>>(type: "text[]", nullable: false),
                    estado = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mision", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Objeto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    tipo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    estadisticas = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objeto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPersonajes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersonajes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ubicacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    clima = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Habilidads",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    ataqueBase = table.Column<int>(type: "integer", nullable: false),
                    nivelRequerido = table.Column<int>(type: "integer", nullable: false),
                    costoMana = table.Column<int>(type: "integer", nullable: false),
                    costoEnergia = table.Column<int>(type: "integer", nullable: false),
                    costoSalud = table.Column<int>(type: "integer", nullable: false),
                    tiempoEnfriamiento = table.Column<double>(type: "double precision", nullable: false),
                    Enemigoid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidads", x => x.id);
                    table.ForeignKey(
                        name: "FK_Habilidads_Enemigo_Enemigoid",
                        column: x => x.Enemigoid,
                        principalTable: "Enemigo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Personaje",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    salud = table.Column<int>(type: "integer", nullable: false),
                    energia = table.Column<int>(type: "integer", nullable: false),
                    fuerza = table.Column<int>(type: "integer", nullable: false),
                    inteligencia = table.Column<int>(type: "integer", nullable: false),
                    agilidad = table.Column<int>(type: "integer", nullable: false),
                    nivel = table.Column<int>(type: "integer", nullable: false),
                    defensa = table.Column<int>(type: "integer", nullable: false),
                    experiencia = table.Column<int>(type: "integer", nullable: false),
                    tipoId = table.Column<int>(type: "integer", nullable: true),
                    ubicacionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personaje", x => x.id);
                    table.ForeignKey(
                        name: "FK_Personaje_TipoPersonajes_tipoId",
                        column: x => x.tipoId,
                        principalTable: "TipoPersonajes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Personaje_Ubicacion_ubicacionId",
                        column: x => x.ubicacionId,
                        principalTable: "Ubicacion",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "HabilidadPersonaje",
                columns: table => new
                {
                    habilidadesid = table.Column<int>(type: "integer", nullable: false),
                    personajesid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabilidadPersonaje", x => new { x.habilidadesid, x.personajesid });
                    table.ForeignKey(
                        name: "FK_HabilidadPersonaje_Habilidads_habilidadesid",
                        column: x => x.habilidadesid,
                        principalTable: "Habilidads",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabilidadPersonaje_Personaje_personajesid",
                        column: x => x.personajesid,
                        principalTable: "Personaje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabilidadPersonaje_personajesid",
                table: "HabilidadPersonaje",
                column: "personajesid");

            migrationBuilder.CreateIndex(
                name: "IX_Habilidads_Enemigoid",
                table: "Habilidads",
                column: "Enemigoid");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_tipoId",
                table: "Personaje",
                column: "tipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_ubicacionId",
                table: "Personaje",
                column: "ubicacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "HabilidadPersonaje");

            migrationBuilder.DropTable(
                name: "Mision");

            migrationBuilder.DropTable(
                name: "Objeto");

            migrationBuilder.DropTable(
                name: "Habilidads");

            migrationBuilder.DropTable(
                name: "Personaje");

            migrationBuilder.DropTable(
                name: "Enemigo");

            migrationBuilder.DropTable(
                name: "TipoPersonajes");

            migrationBuilder.DropTable(
                name: "Ubicacion");
        }
    }
}

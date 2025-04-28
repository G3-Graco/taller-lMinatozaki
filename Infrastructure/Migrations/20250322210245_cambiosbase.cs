using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cambiosbase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo",
                table: "Objeto");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Mision");

            migrationBuilder.DropColumn(
                name: "objetivos",
                table: "Mision");

            migrationBuilder.DropColumn(
                name: "arma1",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "arma2",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "armadura",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "casco",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "grebas",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "guanteletes",
                table: "Equipo");

            migrationBuilder.RenameColumn(
                name: "salud",
                table: "Personaje",
                newName: "saludId");

            migrationBuilder.RenameColumn(
                name: "inteligencia",
                table: "Personaje",
                newName: "inteligenciaId");

            migrationBuilder.RenameColumn(
                name: "fuerza",
                table: "Personaje",
                newName: "fuerzaId");

            migrationBuilder.RenameColumn(
                name: "energia",
                table: "Personaje",
                newName: "energiaId");

            migrationBuilder.RenameColumn(
                name: "defensa",
                table: "Personaje",
                newName: "defensaId");

            migrationBuilder.RenameColumn(
                name: "agilidad",
                table: "Personaje",
                newName: "agilidadId");

            migrationBuilder.AddColumn<int>(
                name: "equipoId",
                table: "Personaje",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tipoObjetoId",
                table: "Objeto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "arma1Id",
                table: "Equipo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "arma2Id",
                table: "Equipo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "armaduraId",
                table: "Equipo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cascoId",
                table: "Equipo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "grebasId",
                table: "Equipo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "guanteletesId",
                table: "Equipo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Objetivo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    misionId = table.Column<int>(type: "integer", nullable: false),
                    descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    valorObjetivo = table.Column<int>(type: "integer", nullable: false),
                    valorActual = table.Column<int>(type: "integer", nullable: false),
                    completado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objetivo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Objetivo_Mision_misionId",
                        column: x => x.misionId,
                        principalTable: "Mision",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersoanjeMision",
                columns: table => new
                {
                    PersonajeId = table.Column<int>(type: "integer", nullable: false),
                    MisionId = table.Column<int>(type: "integer", nullable: false),
                    Progreso = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersoanjeMision", x => new { x.PersonajeId, x.MisionId });
                    table.ForeignKey(
                        name: "FK_PersoanjeMision_Mision_MisionId",
                        column: x => x.MisionId,
                        principalTable: "Mision",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersoanjeMision_Personaje_PersonajeId",
                        column: x => x.PersonajeId,
                        principalTable: "Personaje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoEstadistica",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEstadistica", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoObjeto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoObjeto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Estadistica",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipoEstadisticaId = table.Column<int>(type: "integer", nullable: false),
                    valor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadistica", x => x.id);
                    table.ForeignKey(
                        name: "FK_Estadistica_TipoEstadistica_tipoEstadisticaId",
                        column: x => x.tipoEstadisticaId,
                        principalTable: "TipoEstadistica",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ranura",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipoObjetoId = table.Column<int>(type: "integer", nullable: false),
                    objetoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranura", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ranura_Objeto_objetoId",
                        column: x => x.objetoId,
                        principalTable: "Objeto",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Ranura_TipoObjeto_tipoObjetoId",
                        column: x => x.tipoObjetoId,
                        principalTable: "TipoObjeto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_agilidadId",
                table: "Personaje",
                column: "agilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_defensaId",
                table: "Personaje",
                column: "defensaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_energiaId",
                table: "Personaje",
                column: "energiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_fuerzaId",
                table: "Personaje",
                column: "fuerzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_inteligenciaId",
                table: "Personaje",
                column: "inteligenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_saludId",
                table: "Personaje",
                column: "saludId");

            migrationBuilder.CreateIndex(
                name: "IX_Objeto_tipoObjetoId",
                table: "Objeto",
                column: "tipoObjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_arma1Id",
                table: "Equipo",
                column: "arma1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_arma2Id",
                table: "Equipo",
                column: "arma2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_armaduraId",
                table: "Equipo",
                column: "armaduraId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_cascoId",
                table: "Equipo",
                column: "cascoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_grebasId",
                table: "Equipo",
                column: "grebasId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_guanteletesId",
                table: "Equipo",
                column: "guanteletesId");

            migrationBuilder.CreateIndex(
                name: "IX_Estadistica_tipoEstadisticaId",
                table: "Estadistica",
                column: "tipoEstadisticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Objetivo_misionId",
                table: "Objetivo",
                column: "misionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersoanjeMision_MisionId",
                table: "PersoanjeMision",
                column: "MisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranura_objetoId",
                table: "Ranura",
                column: "objetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranura_tipoObjetoId",
                table: "Ranura",
                column: "tipoObjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_Ranura_arma1Id",
                table: "Equipo",
                column: "arma1Id",
                principalTable: "Ranura",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_Ranura_arma2Id",
                table: "Equipo",
                column: "arma2Id",
                principalTable: "Ranura",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_Ranura_armaduraId",
                table: "Equipo",
                column: "armaduraId",
                principalTable: "Ranura",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_Ranura_cascoId",
                table: "Equipo",
                column: "cascoId",
                principalTable: "Ranura",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_Ranura_grebasId",
                table: "Equipo",
                column: "grebasId",
                principalTable: "Ranura",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_Ranura_guanteletesId",
                table: "Equipo",
                column: "guanteletesId",
                principalTable: "Ranura",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Objeto_TipoObjeto_tipoObjetoId",
                table: "Objeto",
                column: "tipoObjetoId",
                principalTable: "TipoObjeto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personaje_Equipo_tipoId",
                table: "Personaje",
                column: "tipoId",
                principalTable: "Equipo",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personaje_Estadistica_agilidadId",
                table: "Personaje",
                column: "agilidadId",
                principalTable: "Estadistica",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personaje_Estadistica_defensaId",
                table: "Personaje",
                column: "defensaId",
                principalTable: "Estadistica",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personaje_Estadistica_energiaId",
                table: "Personaje",
                column: "energiaId",
                principalTable: "Estadistica",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personaje_Estadistica_fuerzaId",
                table: "Personaje",
                column: "fuerzaId",
                principalTable: "Estadistica",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personaje_Estadistica_inteligenciaId",
                table: "Personaje",
                column: "inteligenciaId",
                principalTable: "Estadistica",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personaje_Estadistica_saludId",
                table: "Personaje",
                column: "saludId",
                principalTable: "Estadistica",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_Ranura_arma1Id",
                table: "Equipo");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_Ranura_arma2Id",
                table: "Equipo");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_Ranura_armaduraId",
                table: "Equipo");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_Ranura_cascoId",
                table: "Equipo");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_Ranura_grebasId",
                table: "Equipo");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_Ranura_guanteletesId",
                table: "Equipo");

            migrationBuilder.DropForeignKey(
                name: "FK_Objeto_TipoObjeto_tipoObjetoId",
                table: "Objeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_Equipo_tipoId",
                table: "Personaje");

            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_Estadistica_agilidadId",
                table: "Personaje");

            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_Estadistica_defensaId",
                table: "Personaje");

            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_Estadistica_energiaId",
                table: "Personaje");

            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_Estadistica_fuerzaId",
                table: "Personaje");

            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_Estadistica_inteligenciaId",
                table: "Personaje");

            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_Estadistica_saludId",
                table: "Personaje");

            migrationBuilder.DropTable(
                name: "Estadistica");

            migrationBuilder.DropTable(
                name: "Objetivo");

            migrationBuilder.DropTable(
                name: "PersoanjeMision");

            migrationBuilder.DropTable(
                name: "Ranura");

            migrationBuilder.DropTable(
                name: "TipoEstadistica");

            migrationBuilder.DropTable(
                name: "TipoObjeto");

            migrationBuilder.DropIndex(
                name: "IX_Personaje_agilidadId",
                table: "Personaje");

            migrationBuilder.DropIndex(
                name: "IX_Personaje_defensaId",
                table: "Personaje");

            migrationBuilder.DropIndex(
                name: "IX_Personaje_energiaId",
                table: "Personaje");

            migrationBuilder.DropIndex(
                name: "IX_Personaje_fuerzaId",
                table: "Personaje");

            migrationBuilder.DropIndex(
                name: "IX_Personaje_inteligenciaId",
                table: "Personaje");

            migrationBuilder.DropIndex(
                name: "IX_Personaje_saludId",
                table: "Personaje");

            migrationBuilder.DropIndex(
                name: "IX_Objeto_tipoObjetoId",
                table: "Objeto");

            migrationBuilder.DropIndex(
                name: "IX_Equipo_arma1Id",
                table: "Equipo");

            migrationBuilder.DropIndex(
                name: "IX_Equipo_arma2Id",
                table: "Equipo");

            migrationBuilder.DropIndex(
                name: "IX_Equipo_armaduraId",
                table: "Equipo");

            migrationBuilder.DropIndex(
                name: "IX_Equipo_cascoId",
                table: "Equipo");

            migrationBuilder.DropIndex(
                name: "IX_Equipo_grebasId",
                table: "Equipo");

            migrationBuilder.DropIndex(
                name: "IX_Equipo_guanteletesId",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "equipoId",
                table: "Personaje");

            migrationBuilder.DropColumn(
                name: "tipoObjetoId",
                table: "Objeto");

            migrationBuilder.DropColumn(
                name: "arma1Id",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "arma2Id",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "armaduraId",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "cascoId",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "grebasId",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "guanteletesId",
                table: "Equipo");

            migrationBuilder.RenameColumn(
                name: "saludId",
                table: "Personaje",
                newName: "salud");

            migrationBuilder.RenameColumn(
                name: "inteligenciaId",
                table: "Personaje",
                newName: "inteligencia");

            migrationBuilder.RenameColumn(
                name: "fuerzaId",
                table: "Personaje",
                newName: "fuerza");

            migrationBuilder.RenameColumn(
                name: "energiaId",
                table: "Personaje",
                newName: "energia");

            migrationBuilder.RenameColumn(
                name: "defensaId",
                table: "Personaje",
                newName: "defensa");

            migrationBuilder.RenameColumn(
                name: "agilidadId",
                table: "Personaje",
                newName: "agilidad");

            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "Objeto",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<char>(
                name: "estado",
                table: "Mision",
                type: "character(1)",
                nullable: false,
                defaultValue: '\0');

            migrationBuilder.AddColumn<List<string>>(
                name: "objetivos",
                table: "Mision",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "arma1",
                table: "Equipo",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "arma2",
                table: "Equipo",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "armadura",
                table: "Equipo",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "casco",
                table: "Equipo",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "grebas",
                table: "Equipo",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "guanteletes",
                table: "Equipo",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}

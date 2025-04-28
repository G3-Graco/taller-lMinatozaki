using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cambiosbaseper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_Equipo_tipoId",
                table: "Personaje");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_equipoId",
                table: "Personaje",
                column: "equipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personaje_Equipo_equipoId",
                table: "Personaje",
                column: "equipoId",
                principalTable: "Equipo",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_Equipo_equipoId",
                table: "Personaje");

            migrationBuilder.DropIndex(
                name: "IX_Personaje_equipoId",
                table: "Personaje");

            migrationBuilder.AddForeignKey(
                name: "FK_Personaje_Equipo_tipoId",
                table: "Personaje",
                column: "tipoId",
                principalTable: "Equipo",
                principalColumn: "id");
        }
    }
}

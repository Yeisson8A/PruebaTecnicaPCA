using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaPCA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vuelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origen = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Destino = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaLlegada = table.Column<DateTime>(type: "datetime", nullable: false),
                    Aerolinea = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVuelo = table.Column<int>(type: "int", nullable: false),
                    NombreUsuario = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoUsuario = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    CorreoUsuario = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_Vuelo",
                        column: x => x.IdVuelo,
                        principalTable: "Vuelo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdVuelo",
                table: "Reserva",
                column: "IdVuelo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Vuelo");
        }
    }
}

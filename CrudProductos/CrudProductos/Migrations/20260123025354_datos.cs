using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudProductos.Migrations
{
    /// <inheritdoc />
    public partial class datos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreCompleto",
                table: "Clientes",
                newName: "Provincia");

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Clientes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CedulaRuc",
                table: "Clientes",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Clientes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "EstaActivo",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "Clientes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CedulaRuc",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EstaActivo",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Provincia",
                table: "Clientes",
                newName: "NombreCompleto");
        }
    }
}

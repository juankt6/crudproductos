using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudProductos.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Vendedores_VendedorId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Vendedores_VendedorId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_VendedorId",
                table: "Ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendedores",
                table: "Vendedores");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Vendedores",
                newName: "Vendedor");

            migrationBuilder.RenameColumn(
                name: "VendedorId",
                table: "Ventas",
                newName: "Cantidad");

            migrationBuilder.AddColumn<string>(
                name: "MetodoPago",
                table: "Ventas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CodigoInterno",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Categorias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Categorias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendedor",
                table: "Vendedor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Vendedor_VendedorId",
                table: "Clientes",
                column: "VendedorId",
                principalTable: "Vendedor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Vendedor_VendedorId",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendedor",
                table: "Vendedor");

            migrationBuilder.DropColumn(
                name: "MetodoPago",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CodigoInterno",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Vendedor",
                newName: "Vendedores");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Ventas",
                newName: "VendedorId");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Productos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendedores",
                table: "Vendedores",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_VendedorId",
                table: "Ventas",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Vendedores_VendedorId",
                table: "Clientes",
                column: "VendedorId",
                principalTable: "Vendedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Vendedores_VendedorId",
                table: "Ventas",
                column: "VendedorId",
                principalTable: "Vendedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

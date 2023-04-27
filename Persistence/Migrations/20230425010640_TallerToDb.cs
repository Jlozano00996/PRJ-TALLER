using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taller.Persistence.Migrations
{
    public partial class TallerToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personales",
                columns: table => new
                {
                    PersonalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Posicion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personales", x => x.PersonalId);
                });

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "compras",
                columns: table => new
                {
                    CompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    CantidadComprada = table.Column<int>(type: "int", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compras", x => x.CompraId);
                    table.ForeignKey(
                        name: "FK_compras_proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventarios",
                columns: table => new
                {
                    InventarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompraId = table.Column<int>(type: "int", nullable: false),
                    CantidadDisponible = table.Column<int>(type: "int", nullable: false),
                    UbicacionAlmacen = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventarios", x => x.InventarioId);
                    table.ForeignKey(
                        name: "FK_inventarios_compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "compras",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "precios",
                columns: table => new
                {
                    PrecioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompraId = table.Column<int>(type: "int", nullable: false),
                    CostoCompra = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<int>(type: "int", nullable: false),
                    MargenGanancias = table.Column<int>(type: "int", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_precios", x => x.PrecioId);
                    table.ForeignKey(
                        name: "FK_precios_compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "compras",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "repuestos",
                columns: table => new
                {
                    RepuestoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPieza = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ModeloVehiculo = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    CompraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repuestos", x => x.RepuestoId);
                    table.ForeignKey(
                        name: "FK_repuestos_compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "compras",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compras_ProveedorId",
                table: "compras",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_inventarios_CompraId",
                table: "inventarios",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_precios_CompraId",
                table: "precios",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_repuestos_CompraId",
                table: "repuestos",
                column: "CompraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventarios");

            migrationBuilder.DropTable(
                name: "personales");

            migrationBuilder.DropTable(
                name: "precios");

            migrationBuilder.DropTable(
                name: "repuestos");

            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "proveedores");
        }
    }
}

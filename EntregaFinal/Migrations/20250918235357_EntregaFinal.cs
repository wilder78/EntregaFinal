using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntregaFinal.Migrations
{
    /// <inheritdoc />
    public partial class EntregaFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NombreNegocio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreContacto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NIT_Cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreditoActivo = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clientes__71ABD0A744CA5938", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NombreCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaContratacion = table.Column<DateOnly>(type: "date", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empleado__958BE6F026A16611", x => x.EmpleadoID);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrecioCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    UbicacionAlmacen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__A430AE83528E52BE", x => x.ProductoID);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proveedo__61266BB909CC9A7A", x => x.ProveedorID);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    VendedorID = table.Column<int>(type: "int", nullable: false),
                    FechaPedido = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    EstadoPedido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Pendiente"),
                    TotalPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaEntregaEstimada = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pedidos__09BA14109B43D2D9", x => x.PedidoID);
                    table.ForeignKey(
                        name: "FK__Pedidos__Cliente__571DF1D5",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID");
                    table.ForeignKey(
                        name: "FK__Pedidos__Vendedo__5812160E",
                        column: x => x.VendedorID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID");
                });

            migrationBuilder.CreateTable(
                name: "CalificacionesProductos",
                columns: table => new
                {
                    CalificacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoID = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    Puntuacion = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Califica__4CF54ABE1478A61C", x => x.CalificacionID);
                    table.ForeignKey(
                        name: "FK__Calificac__Clien__6E01572D",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID");
                    table.ForeignKey(
                        name: "FK__Calificac__Produ__6D0D32F4",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    CompraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorID = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CostoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Compras__067DA725CA111327", x => x.CompraID);
                    table.ForeignKey(
                        name: "FK__Compras__Proveed__797309D9",
                        column: x => x.ProveedorID,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorID");
                });

            migrationBuilder.CreateTable(
                name: "Comisiones",
                columns: table => new
                {
                    ComisionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendedorID = table.Column<int>(type: "int", nullable: false),
                    PedidoID = table.Column<int>(type: "int", nullable: false),
                    PorcentajeComision = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MontoComision = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCalculo = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Pagada = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comision__A014A712AF093CBF", x => x.ComisionID);
                    table.ForeignKey(
                        name: "FK__Comisione__Pedid__628FA481",
                        column: x => x.PedidoID,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoID");
                    table.ForeignKey(
                        name: "FK__Comisione__Vende__619B8048",
                        column: x => x.VendedorID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID");
                });

            migrationBuilder.CreateTable(
                name: "DetallePedidos",
                columns: table => new
                {
                    DetallePedidoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoID = table.Column<int>(type: "int", nullable: false),
                    ProductoID = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(29,2)", nullable: true, computedColumnSql: "([Cantidad]*[PrecioUnitario])", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleP__6ED21C012B734B53", x => x.DetallePedidoID);
                    table.ForeignKey(
                        name: "FK__DetallePe__Pedid__5CD6CB2B",
                        column: x => x.PedidoID,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DetallePe__Produ__5DCAEF64",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID");
                });

            migrationBuilder.CreateTable(
                name: "NotasCredito",
                columns: table => new
                {
                    NotaCreditoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    PedidoID = table.Column<int>(type: "int", nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Motivo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Activa")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotasCre__12E55628ACF99166", x => x.NotaCreditoID);
                    table.ForeignKey(
                        name: "FK__NotasCred__Clien__6754599E",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID");
                    table.ForeignKey(
                        name: "FK__NotasCred__Pedid__68487DD7",
                        column: x => x.PedidoID,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoID");
                });

            migrationBuilder.CreateTable(
                name: "Quejas",
                columns: table => new
                {
                    QuejaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    ProductoID = table.Column<int>(type: "int", nullable: true),
                    PedidoID = table.Column<int>(type: "int", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Recibida"),
                    FechaResolucion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Quejas__59BD66FBD9C973F4", x => x.QuejaID);
                    table.ForeignKey(
                        name: "FK__Quejas__ClienteI__72C60C4A",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID");
                    table.ForeignKey(
                        name: "FK__Quejas__PedidoID__74AE54BC",
                        column: x => x.PedidoID,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoID");
                    table.ForeignKey(
                        name: "FK__Quejas__Producto__73BA3083",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID");
                });

            migrationBuilder.CreateTable(
                name: "DetalleCompras",
                columns: table => new
                {
                    DetalleCompraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompraID = table.Column<int>(type: "int", nullable: false),
                    ProductoID = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CostoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(29,2)", nullable: true, computedColumnSql: "([Cantidad]*[CostoUnitario])", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleC__F7FC189AEDE2F723", x => x.DetalleCompraID);
                    table.ForeignKey(
                        name: "FK__DetalleCo__Compr__7D439ABD",
                        column: x => x.CompraID,
                        principalTable: "Compras",
                        principalColumn: "CompraID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DetalleCo__Produ__7E37BEF6",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_ProductoID",
                table: "CalificacionesProductos",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_CalificacionesProductos_ClienteID",
                table: "CalificacionesProductos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "UQ__Clientes__1788CCAD0AD02329",
                table: "Clientes",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Clientes__3DE647A8C8945430",
                table: "Clientes",
                column: "NIT_Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comisiones_VendedorID",
                table: "Comisiones",
                column: "VendedorID");

            migrationBuilder.CreateIndex(
                name: "UQ__Comision__09BA141123A6EC52",
                table: "Comisiones",
                column: "PedidoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ProveedorID",
                table: "Compras",
                column: "ProveedorID");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_CompraID",
                table: "DetalleCompras",
                column: "CompraID");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_ProductoID",
                table: "DetalleCompras",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_PedidoID",
                table: "DetallePedidos",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_ProductoID",
                table: "DetallePedidos",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "UQ__Empleado__1788CCAD50646051",
                table: "Empleados",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NotasCredito_ClienteID",
                table: "NotasCredito",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_NotasCredito_PedidoID",
                table: "NotasCredito",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteID",
                table: "Pedidos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_VendedorID",
                table: "Pedidos",
                column: "VendedorID");

            migrationBuilder.CreateIndex(
                name: "UQ__Producto__25DFC03A7668FF53",
                table: "Productos",
                column: "Referencia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quejas_ClienteID",
                table: "Quejas",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Quejas_PedidoID",
                table: "Quejas",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Quejas_ProductoID",
                table: "Quejas",
                column: "ProductoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalificacionesProductos");

            migrationBuilder.DropTable(
                name: "Comisiones");

            migrationBuilder.DropTable(
                name: "DetalleCompras");

            migrationBuilder.DropTable(
                name: "DetallePedidos");

            migrationBuilder.DropTable(
                name: "NotasCredito");

            migrationBuilder.DropTable(
                name: "Quejas");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}

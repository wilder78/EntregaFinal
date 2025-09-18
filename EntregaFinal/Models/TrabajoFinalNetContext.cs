using Microsoft.EntityFrameworkCore;

namespace EntregaFinal.Models;

public partial class TrabajoFinalNetContext : DbContext
{
    public TrabajoFinalNetContext()
    {
    }

    public TrabajoFinalNetContext(DbContextOptions<TrabajoFinalNetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CalificacionesProducto> CalificacionesProductos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Comisione> Comisiones { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<NotasCredito> NotasCreditos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Queja> Quejas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            //        => optionsBuilder.UseSqlServer("Server=DESKTOP-6M0BV5K\\SQLEXPRESS;Database=TrabajoFinalNet;Integrated Security=True;TrustServerCertificate=True");

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalificacionesProducto>(entity =>
        {
            entity.HasKey(e => e.CalificacionId).HasName("PK__Califica__4CF54ABE1478A61C");

            entity.HasIndex(e => e.ProductoId, "IX_Calificaciones_ProductoID");

            entity.Property(e => e.CalificacionId).HasColumnName("CalificacionID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.CalificacionesProductos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__Clien__6E01572D");

            entity.HasOne(d => d.Producto).WithMany(p => p.CalificacionesProductos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Calificac__Produ__6D0D32F4");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A744CA5938");

            entity.HasIndex(e => e.UserId, "UQ__Clientes__1788CCAD0AD02329").IsUnique();

            entity.HasIndex(e => e.NitCedula, "UQ__Clientes__3DE647A8C8945430").IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.CreditoActivo).HasDefaultValue(false);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.NitCedula)
                .HasMaxLength(20)
                .HasColumnName("NIT_Cedula");
            entity.Property(e => e.NombreContacto).HasMaxLength(100);
            entity.Property(e => e.NombreNegocio).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Comisione>(entity =>
        {
            entity.HasKey(e => e.ComisionId).HasName("PK__Comision__A014A712AF093CBF");

            entity.HasIndex(e => e.VendedorId, "IX_Comisiones_VendedorID");

            entity.HasIndex(e => e.PedidoId, "UQ__Comision__09BA141123A6EC52").IsUnique();

            entity.Property(e => e.ComisionId).HasColumnName("ComisionID");
            entity.Property(e => e.FechaCalculo)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MontoComision).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Pagada).HasDefaultValue(false);
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.PorcentajeComision).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.VendedorId).HasColumnName("VendedorID");

            entity.HasOne(d => d.Pedido).WithOne(p => p.Comisione)
                .HasForeignKey<Comisione>(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comisione__Pedid__628FA481");

            entity.HasOne(d => d.Vendedor).WithMany(p => p.Comisiones)
                .HasForeignKey(d => d.VendedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comisione__Vende__619B8048");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.CompraId).HasName("PK__Compras__067DA725CA111327");

            entity.HasIndex(e => e.ProveedorId, "IX_Compras_ProveedorID");

            entity.Property(e => e.CompraId).HasColumnName("CompraID");
            entity.Property(e => e.CostoTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Compras__Proveed__797309D9");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.DetalleCompraId).HasName("PK__DetalleC__F7FC189AEDE2F723");

            entity.HasIndex(e => e.CompraId, "IX_DetalleCompras_CompraID");

            entity.HasIndex(e => e.ProductoId, "IX_DetalleCompras_ProductoID");

            entity.Property(e => e.DetalleCompraId).HasColumnName("DetalleCompraID");
            entity.Property(e => e.CompraId).HasColumnName("CompraID");
            entity.Property(e => e.CostoUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Subtotal)
                .HasComputedColumnSql("([Cantidad]*[CostoUnitario])", true)
                .HasColumnType("decimal(29, 2)");

            entity.HasOne(d => d.Compra).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.CompraId)
                .HasConstraintName("FK__DetalleCo__Compr__7D439ABD");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCo__Produ__7E37BEF6");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.DetallePedidoId).HasName("PK__DetalleP__6ED21C012B734B53");

            entity.HasIndex(e => e.PedidoId, "IX_DetallePedidos_PedidoID");

            entity.HasIndex(e => e.ProductoId, "IX_DetallePedidos_ProductoID");

            entity.Property(e => e.DetallePedidoId).HasColumnName("DetallePedidoID");
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Subtotal)
                .HasComputedColumnSql("([Cantidad]*[PrecioUnitario])", true)
                .HasColumnType("decimal(29, 2)");

            entity.HasOne(d => d.Pedido).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK__DetallePe__Pedid__5CD6CB2B");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallePe__Produ__5DCAEF64");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE6F026A16611");

            entity.HasIndex(e => e.UserId, "UQ__Empleado__1788CCAD50646051").IsUnique();

            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Cargo).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.NombreCompleto).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<NotasCredito>(entity =>
        {
            entity.HasKey(e => e.NotaCreditoId).HasName("PK__NotasCre__12E55628ACF99166");

            entity.ToTable("NotasCredito");

            entity.HasIndex(e => e.ClienteId, "IX_NotasCredito_ClienteID");

            entity.Property(e => e.NotaCreditoId).HasColumnName("NotaCreditoID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("Activa");
            entity.Property(e => e.FechaEmision)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Motivo).HasMaxLength(255);
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.NotasCreditos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NotasCred__Clien__6754599E");

            entity.HasOne(d => d.Pedido).WithMany(p => p.NotasCreditos)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK__NotasCred__Pedid__68487DD7");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("PK__Pedidos__09BA14109B43D2D9");

            entity.HasIndex(e => e.ClienteId, "IX_Pedidos_ClienteID");

            entity.HasIndex(e => e.VendedorId, "IX_Pedidos_VendedorID");

            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.EstadoPedido)
                .HasMaxLength(50)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.FechaEntregaEstimada).HasColumnType("datetime");
            entity.Property(e => e.FechaPedido)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TotalPedido).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VendedorId).HasColumnName("VendedorID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__Cliente__571DF1D5");

            entity.HasOne(d => d.Vendedor).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.VendedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__Vendedo__5812160E");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE83528E52BE");

            entity.HasIndex(e => e.Referencia, "UQ__Producto__25DFC03A7668FF53").IsUnique();

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PrecioCompra).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Referencia).HasMaxLength(50);
            entity.Property(e => e.Stock).HasDefaultValue(0);
            entity.Property(e => e.UbicacionAlmacen).HasMaxLength(50);
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PK__Proveedo__61266BB909CC9A7A");

            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.Contacto).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Queja>(entity =>
        {
            entity.HasKey(e => e.QuejaId).HasName("PK__Quejas__59BD66FBD9C973F4");

            entity.HasIndex(e => e.ClienteId, "IX_Quejas_ClienteID");

            entity.Property(e => e.QuejaId).HasColumnName("QuejaID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("Recibida");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaResolucion).HasColumnType("datetime");
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Quejas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quejas__ClienteI__72C60C4A");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Quejas)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK__Quejas__PedidoID__74AE54BC");

            entity.HasOne(d => d.Producto).WithMany(p => p.Quejas)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Quejas__Producto__73BA3083");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

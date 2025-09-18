using System;
using System.Collections.Generic;

namespace EntregaFinal.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Referencia { get; set; } = null!;

    public string? Marca { get; set; }

    public decimal PrecioCompra { get; set; }

    public decimal PrecioVenta { get; set; }

    public int? Stock { get; set; }

    public string? UbicacionAlmacen { get; set; }

    public virtual ICollection<CalificacionesProducto> CalificacionesProductos { get; set; } = new List<CalificacionesProducto>();

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual ICollection<Queja> Quejas { get; set; } = new List<Queja>();
}

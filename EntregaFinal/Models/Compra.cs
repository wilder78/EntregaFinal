using System;
using System.Collections.Generic;

namespace EntregaFinal.Models;

public partial class Compra
{
    public int CompraId { get; set; }

    public int ProveedorId { get; set; }

    public DateTime Fecha { get; set; }

    public decimal CostoTotal { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Proveedore Proveedor { get; set; } = null!;
}

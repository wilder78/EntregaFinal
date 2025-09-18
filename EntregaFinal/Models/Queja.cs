using System;
using System.Collections.Generic;

namespace EntregaFinal.Models;

public partial class Queja
{
    public int QuejaId { get; set; }

    public int ClienteId { get; set; }

    public int? ProductoId { get; set; }

    public int? PedidoId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime? FechaResolucion { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Pedido? Pedido { get; set; }

    public virtual Producto? Producto { get; set; }
}

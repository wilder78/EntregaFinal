using System;
using System.Collections.Generic;

namespace EntregaFinal.Models;

public partial class NotasCredito
{
    public int NotaCreditoId { get; set; }

    public int ClienteId { get; set; }

    public int? PedidoId { get; set; }

    public decimal Monto { get; set; }

    public DateTime FechaEmision { get; set; }

    public string? Motivo { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Pedido? Pedido { get; set; }
}

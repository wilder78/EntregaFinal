using System;
using System.Collections.Generic;

namespace EntregaFinal.Models;

public partial class Pedido
{
    public int PedidoId { get; set; }

    public int ClienteId { get; set; }

    public int VendedorId { get; set; }

    public DateTime FechaPedido { get; set; }

    public string EstadoPedido { get; set; } = null!;

    public decimal TotalPedido { get; set; }

    public DateTime? FechaEntregaEstimada { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Comisione? Comisione { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual ICollection<NotasCredito> NotasCreditos { get; set; } = new List<NotasCredito>();

    public virtual ICollection<Queja> Quejas { get; set; } = new List<Queja>();

    public virtual Empleado Vendedor { get; set; } = null!;
}

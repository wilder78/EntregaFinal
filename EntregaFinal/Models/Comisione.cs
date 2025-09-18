using System;
using System.Collections.Generic;

namespace EntregaFinal.Models;

public partial class Comisione
{
    public int ComisionId { get; set; }

    public int VendedorId { get; set; }

    public int PedidoId { get; set; }

    public decimal PorcentajeComision { get; set; }

    public decimal MontoComision { get; set; }

    public DateTime FechaCalculo { get; set; }

    public bool? Pagada { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;

    public virtual Empleado Vendedor { get; set; } = null!;
}

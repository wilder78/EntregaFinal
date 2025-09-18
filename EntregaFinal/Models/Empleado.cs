using System;
using System.Collections.Generic;

namespace EntregaFinal.Models;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string? UserId { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public DateOnly FechaContratacion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Comisione> Comisiones { get; set; } = new List<Comisione>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}

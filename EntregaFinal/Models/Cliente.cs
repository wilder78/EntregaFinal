using System;
using System.Collections.Generic;

namespace EntregaFinal.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? UserId { get; set; }

    public string NombreNegocio { get; set; } = null!;

    public string? NombreContacto { get; set; }

    public string NitCedula { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public bool? CreditoActivo { get; set; }

    public virtual ICollection<CalificacionesProducto> CalificacionesProductos { get; set; } = new List<CalificacionesProducto>();

    public virtual ICollection<NotasCredito> NotasCreditos { get; set; } = new List<NotasCredito>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Queja> Quejas { get; set; } = new List<Queja>();
}

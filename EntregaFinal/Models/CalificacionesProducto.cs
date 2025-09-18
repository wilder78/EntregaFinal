using System;
using System.Collections.Generic;

namespace EntregaFinal.Models;

public partial class CalificacionesProducto
{
    public int CalificacionId { get; set; }

    public int ProductoId { get; set; }

    public int ClienteId { get; set; }

    public int Puntuacion { get; set; }

    public string? Comentario { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}

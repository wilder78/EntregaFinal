﻿using System;
using System.Collections.Generic;

namespace EntregaFinal.Models;

public partial class Proveedore
{
    public int ProveedorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Contacto { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}

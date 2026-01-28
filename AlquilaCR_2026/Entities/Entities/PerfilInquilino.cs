using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class PerfilInquilino
{
    public int PerfilInquilinoId { get; set; }

    public int UsuarioId { get; set; }

    public string? Ocupacion { get; set; }

    public decimal? IngresoMensual { get; set; }

    public bool? TieneMascotas { get; set; }

    public string? NotasAdicionales { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class SolicitudesAlquiler
{
    public int SolicitudId { get; set; }

    public int PropiedadId { get; set; }

    public int InquilinoId { get; set; }

    public string? Mensaje { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual Usuario Inquilino { get; set; } = null!;

    public virtual Propiedade Propiedad { get; set; } = null!;
}

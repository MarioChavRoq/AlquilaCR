using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Cita
{
    public int CitaId { get; set; }

    public int PropiedadId { get; set; }

    public int InquilinoId { get; set; }

    public int PropietarioId { get; set; }

    public DateTime FechaCita { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Usuario Inquilino { get; set; } = null!;

    public virtual Propiedade Propiedad { get; set; } = null!;

    public virtual Usuario Propietario { get; set; } = null!;
}

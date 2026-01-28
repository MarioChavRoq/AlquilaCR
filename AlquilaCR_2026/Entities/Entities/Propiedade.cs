using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Propiedade
{
    public int PropiedadId { get; set; }

    public int PropietarioId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal PrecioMensual { get; set; }

    public string Provincia { get; set; } = null!;

    public string Canton { get; set; } = null!;

    public string? DireccionExacta { get; set; }

    public string? TipoPropiedad { get; set; }

    public int MesesMinimosAlquiler { get; set; }

    public bool Disponible { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<ImagenesPropiedad> ImagenesPropiedads { get; set; } = new List<ImagenesPropiedad>();

    public virtual Usuario Propietario { get; set; } = null!;

    public virtual ICollection<PropuestasPropiedad> PropuestasPropiedads { get; set; } = new List<PropuestasPropiedad>();

    public virtual ICollection<SolicitudesAlquiler> SolicitudesAlquilers { get; set; } = new List<SolicitudesAlquiler>();
}

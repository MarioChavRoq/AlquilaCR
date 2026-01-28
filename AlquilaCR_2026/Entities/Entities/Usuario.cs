using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? DescripcionPerfil { get; set; }

    public string? ImagenPerfilUrl { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<Cita> CitaInquilinos { get; set; } = new List<Cita>();

    public virtual ICollection<Cita> CitaPropietarios { get; set; } = new List<Cita>();

    public virtual PerfilInquilino? PerfilInquilino { get; set; }

    public virtual ICollection<Propiedade> Propiedades { get; set; } = new List<Propiedade>();

    public virtual ICollection<PropuestasPropiedad> PropuestasPropiedads { get; set; } = new List<PropuestasPropiedad>();

    public virtual ICollection<SolicitudesAlquiler> SolicitudesAlquilers { get; set; } = new List<SolicitudesAlquiler>();

    public virtual ICollection<UsuarioRole> UsuarioRoles { get; set; } = new List<UsuarioRole>();
}

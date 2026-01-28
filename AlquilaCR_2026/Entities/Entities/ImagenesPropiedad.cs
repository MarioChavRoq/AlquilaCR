using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class ImagenesPropiedad
{
    public int ImagenId { get; set; }

    public int PropiedadId { get; set; }

    public int Orden { get; set; }

    public string UrlImagen { get; set; } = null!;

    public virtual Propiedade Propiedad { get; set; } = null!;
}

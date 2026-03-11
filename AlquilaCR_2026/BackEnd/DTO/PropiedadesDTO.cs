namespace BackEnd.DTO
{
    public class PropiedadesDTO
    {
        public int PropiedadId { get; set; }

        public int PropietarioId { get; set; }

        public string? Nombre { get; set; }

        public string Titulo { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal PrecioMensual { get; set; }

        public string Provincia { get; set; } = null!;

        public string Canton { get; set; } = null!;

        public string? DireccionExacta { get; set; }

        public string? TipoPropiedad { get; set; }

        public int MesesMinimosAlquiler { get; set; }

        public bool Disponible { get; set; }
    }
}

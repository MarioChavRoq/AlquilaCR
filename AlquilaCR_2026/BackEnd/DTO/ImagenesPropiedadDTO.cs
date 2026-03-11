namespace BackEnd.DTO
{
    public class ImagenesPropiedadDTO
    {
        public int ImagenId { get; set; }

        public int PropiedadId { get; set; }

        public string? TituloPropiedad { get; set; }

        public int Orden { get; set; }

        public string UrlImagen { get; set; } = null!;
    }
}
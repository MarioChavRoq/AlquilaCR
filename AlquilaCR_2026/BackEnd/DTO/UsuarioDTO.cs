namespace BackEnd.DTO
{
    public class UsuarioDTO
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
    }
}

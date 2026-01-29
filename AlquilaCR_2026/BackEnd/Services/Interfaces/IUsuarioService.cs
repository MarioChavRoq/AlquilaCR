using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioDTO> GetUsuarios();
        UsuarioDTO GetById(int id);
        UsuarioDTO Add(UsuarioDTO usuario);
        UsuarioDTO Update(UsuarioDTO usuario);
        void Delete(int id);
    }
}

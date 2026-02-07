using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioDTO> GetAllUsers();
        void CreateUser(UsuarioDTO usuario);
        void DeleteUser(int id);
        void UpdateUser(UsuarioDTO usuario);
        UsuarioDTO GetUserById(int id);



        //List<UsuarioDTO> GetUsuarios();
        //UsuarioDTO AddU(UsuarioDTO usuario);
        //UsuarioDTO UpdateUser(UsuarioDTO usuario);
        //void Delete(int id);
        //UsuarioDTO GetById(int id);
    }
}

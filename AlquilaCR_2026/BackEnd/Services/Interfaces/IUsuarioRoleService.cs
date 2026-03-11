using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IUsuarioRoleService
    {
        List<UsuarioRolesDTO> GetUsuarioRoles();
        UsuarioRolesDTO GetById(int id);
        UsuarioRolesDTO Add(UsuarioRolesDTO usuarioRoles);
        void Delete(int id);
        UsuarioRolesDTO Update(UsuarioRolesDTO usuarioRoles);
    }
}

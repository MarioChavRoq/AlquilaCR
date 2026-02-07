using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IRoleService
    {
        RolesDTO Add(RolesDTO roles);
        void Delete(int id);
        RolesDTO GetById(int id);
        List<RolesDTO> GetRoles();
        RolesDTO Update(RolesDTO roles);
    }
}

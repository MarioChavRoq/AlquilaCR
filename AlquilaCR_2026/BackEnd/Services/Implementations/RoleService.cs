using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class RoleService : IRoleService
    {
        IUnidadDeTrabajo _Unidad;

        public RoleService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _Unidad = unidadDeTrabajo;
        }

        Role Convertir(RolesDTO roles)
        {
            return new Role
            {
                RolId = roles.RolId,
                Nombre = roles.Nombre
            };
        }

        RolesDTO Convertir(Role roles)
        {
            return new RolesDTO
            {
                RolId = roles.RolId,
                Nombre = roles.Nombre
            };
        }

        public RolesDTO Add(RolesDTO roles)
        {
            try
            {
                _Unidad.RolesDAL.Add(Convertir(roles));

                _Unidad.Complete();
                return roles;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {

            Role roles = new Role { RolId = id };
            _Unidad.RolesDAL.Remove(roles);
            _Unidad.Complete();

        }

        public RolesDTO GetById(int id)
        {
            var roles = _Unidad.RolesDAL.Get(id);

            return Convertir(roles);
        }

        public List<RolesDTO> GetRoles()
        {
            var roless = _Unidad.RolesDAL.GetAll();
            List<RolesDTO> rolessList = new List<RolesDTO>();
            foreach (var roles in roless)
            {

                rolessList.Add(Convertir(roles));
            }
            return rolessList;
        }

        public RolesDTO Update(RolesDTO roles)
        {
            try
            {
                _Unidad.RolesDAL.Update(Convertir(roles));

                _Unidad.Complete();
                return roles;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

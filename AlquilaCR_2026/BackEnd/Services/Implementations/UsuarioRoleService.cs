using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

    namespace BackEnd.Services.Implementations
    {
        public class UsuarioRoleService : IUsuarioRoleService
        {
            IUnidadDeTrabajo _Unidad;

            public UsuarioRoleService(IUnidadDeTrabajo unidadDeTrabajo)
            {
                _Unidad = unidadDeTrabajo;
            }

            UsuarioRolesDTO Convertir(UsuarioRole usuarioRoles) 
            {
            var usuario = _Unidad.UsuariosDAL.Get((int)usuarioRoles.UsuarioId);
            var rol = _Unidad.RolesDAL.Get((int)usuarioRoles.RolId);
            return new UsuarioRolesDTO
                {
                    UsuarioRolId = usuarioRoles.UsuarioRolId,
                    UsuarioId = usuarioRoles.UsuarioId,
                    NombreUsuario = usuario.Nombre,
                    RolId = usuarioRoles.RolId,
                    NombreRol = rol.Nombre
                };
            }


            UsuarioRole Convertir(UsuarioRolesDTO usuarioRoles)
            {
                return new UsuarioRole
                {
                    UsuarioRolId = usuarioRoles.UsuarioRolId,
                    UsuarioId = usuarioRoles.UsuarioId,
                    RolId = usuarioRoles.RolId
                };
            }

            public UsuarioRolesDTO Add(UsuarioRolesDTO usuarioRoles)
            {
                try
                {
                    _Unidad.UsuarioRolesDAL.Add(Convertir(usuarioRoles));
                    _Unidad.Complete();
                    return usuarioRoles;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public void Delete(int id)
            {
                UsuarioRole usuarioRoles = new UsuarioRole { UsuarioRolId = id };
                _Unidad.UsuarioRolesDAL.Remove(usuarioRoles);
                _Unidad.Complete();
            }

            public UsuarioRolesDTO GetById(int id)
            {
                var usuarioRoles = _Unidad.UsuarioRolesDAL.Get(id);
                return Convertir(usuarioRoles);
            }

            public List<UsuarioRolesDTO> GetUsuarioRoles()
            {
                var usuarioRoles = _Unidad.UsuarioRolesDAL.GetAll();
                List<UsuarioRolesDTO> usuarioRolesList = new List<UsuarioRolesDTO>();
                foreach (var usuarioRole in usuarioRoles)
                {
                    usuarioRolesList.Add(Convertir(usuarioRole));
                }
                return usuarioRolesList;
            }

            public UsuarioRolesDTO Update(UsuarioRolesDTO usuarioRoles)
            {
                try
                {
                    _Unidad.UsuarioRolesDAL.Update(Convertir(usuarioRoles));
                    _Unidad.Complete();
                    return usuarioRoles;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

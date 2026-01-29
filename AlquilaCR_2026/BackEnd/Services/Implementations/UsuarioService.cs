using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;

        public UsuarioService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        UsuarioDTO Convertir (Usuario usuario)
        {
            return new UsuarioDTO
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Email = usuario.Email,
                PasswordHash = usuario.PasswordHash,
                Telefono = usuario.Telefono,
                DescripcionPerfil = usuario.DescripcionPerfil,
                ImagenPerfilUrl = usuario.ImagenPerfilUrl,
                Activo = usuario.Activo
            };
        }

        Usuario Convertir (UsuarioDTO usuario)
        {
            return new Usuario
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Email = usuario.Email,
                PasswordHash = usuario.PasswordHash,
                Telefono = usuario.Telefono,
                DescripcionPerfil = usuario.DescripcionPerfil,
                ImagenPerfilUrl = usuario.ImagenPerfilUrl,
                Activo = usuario.Activo
            };
        }

        public UsuarioDTO Add(UsuarioDTO usuario)
        {
            try
            {
                _unidadDeTrabajo.UsuariosDAL.Add(Convertir(usuario));
                _unidadDeTrabajo.Complete();
                return usuario;
            }
            catch (Exception)
            {
                throw;

            }
        }

        public void Delete(int id)
        {
            Usuario usuario = new Usuario { UsuarioId = id };
            _unidadDeTrabajo.UsuariosDAL.Remove(usuario);
            _unidadDeTrabajo.Complete();
            throw new NotImplementedException();
        }

        public UsuarioDTO GetById(int id)
        {
            var usuario= _unidadDeTrabajo.UsuariosDAL.Get(id);
            return Convertir(usuario);
        }

        public List<UsuarioDTO> GetUsuarios()
        {
            var usuarios = _unidadDeTrabajo.UsuariosDAL.GetAll();
            List<UsuarioDTO> listaUsuarios = new List<UsuarioDTO>();
            foreach (var usuario in usuarios)
            {
                listaUsuarios.Add(Convertir(usuario));
            }
            return listaUsuarios;
        }

        public UsuarioDTO Update(UsuarioDTO usuario)
        {
            try
            {
                _unidadDeTrabajo.UsuariosDAL.Update(Convertir(usuario));
                _unidadDeTrabajo.Complete();
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

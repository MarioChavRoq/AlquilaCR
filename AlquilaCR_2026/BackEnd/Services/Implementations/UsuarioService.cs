using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        IUnidadDeTrabajo _Unidad;

        public UsuarioService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _Unidad = unidadDeTrabajo;
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

        UsuarioDTO Convertir(Usuario usuario)
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

        public void CreateUser(UsuarioDTO usuario)
        {
            var UsuarioEntity = Convertir(usuario);
            _Unidad.UsuariosDAL.Add(UsuarioEntity);
            _Unidad.Complete();



            //try
            //{
            //    _Unidad.UsuariosDAL.Add(Convertir(usuario));
            //    _Unidad.Complete();
            //    return usuario;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        public void DeleteUser(int id)
        {
            _Unidad.UsuariosDAL.DeleteUsuario(id);
            _Unidad.Complete();
        }

        public UsuarioDTO GetUserById(int id)
        {
            var usuario= _Unidad.UsuariosDAL.Get(id);
            return Convertir(usuario);
        }

        public List<UsuarioDTO> GetAllUsers()
        {
            var usuarios = _Unidad.UsuariosDAL.GetUsuarios();
            List<UsuarioDTO> listaUsuarios = new List<UsuarioDTO>();
            foreach (var usuario in usuarios)
            {
                listaUsuarios.Add(Convertir(usuario));
            }
            return listaUsuarios;
        }

        public void UpdateUser(UsuarioDTO usuario)
        {
            var usuarioEntity = Convertir(usuario);
            _Unidad.UsuariosDAL.Update(usuarioEntity);
            _Unidad.Complete();




            //try
            //{
            //    _Unidad.UsuariosDAL.Update(Convertir(usuario));

            //    _Unidad.Complete();
            //    return usuario;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
    }
}

using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUsuariosDAL : IDALGenerico<Usuario>
    {
        List<Usuario> GetUsuarios();
        bool CreateUsuario(Usuario entity);
        bool UpdateUsuario(Usuario entity);
        bool DeleteUsuario (int UsuarioId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IUsuariosDAL UsuariosDAL { get; }
        IRolesDAL RolesDAL { get; }
        IUsuarioRolesDAL UsuarioRolesDAL { get; }
        IPropiedadesDAL PropiedadesDAL { get; }
        IImagenesPropiedadDAL ImagenesPropiedadDAL { get; }

        bool Complete ();
    }
}

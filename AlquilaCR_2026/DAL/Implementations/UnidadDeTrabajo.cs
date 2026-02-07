using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IUsuariosDAL UsuariosDAL { get; set; }
        public IRolesDAL RolesDAL { get; set; }

        private readonly AlquilaCrContext _alquilaCrContext;

        public UnidadDeTrabajo
            (
            AlquilaCrContext alquilaCrContext, 
            IUsuariosDAL usuariosDAL,
            IRolesDAL rolesDAL
            )
        {
            this._alquilaCrContext = alquilaCrContext;
            this.UsuariosDAL = usuariosDAL;
            this.RolesDAL = rolesDAL;
        }

        public bool Complete()
        {
            try
            {
                _alquilaCrContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            _alquilaCrContext.Dispose();
        }
    }
}

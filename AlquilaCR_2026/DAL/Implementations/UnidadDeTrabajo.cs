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

        private AlquilaCrContext _alquilaCrContext;

        public UnidadDeTrabajo(AlquilaCrContext alquilaCrContext, IUsuariosDAL usuariosDAL)
        {
            this._alquilaCrContext = alquilaCrContext;
            this.UsuariosDAL = usuariosDAL;

        }

        public bool Complete()
        {
            try
            {
                _alquilaCrContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            this._alquilaCrContext.Dispose();
        }
    }
}

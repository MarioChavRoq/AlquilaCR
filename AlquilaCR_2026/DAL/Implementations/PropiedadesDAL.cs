using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class PropiedadesDAL : DALGenerico<Propiedade>, IPropiedadesDAL
    {
        private AlquilaCrContext _context;
        public PropiedadesDAL(AlquilaCrContext context) : base(context)
        {
            _context = context;
        }
    }
}

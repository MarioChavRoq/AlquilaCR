using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UsuarioRolesDAL : DALGenerico<UsuarioRole>, IUsuarioRolesDAL
    {
        private AlquilaCrContext _context;
        public UsuarioRolesDAL(AlquilaCrContext context) : base(context)
        {
            _context = context;
        }   
    }
}

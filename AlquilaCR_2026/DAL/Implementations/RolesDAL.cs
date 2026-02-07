using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class RolesDAL : DALGenerico<Role> , IRolesDAL
    {
        private AlquilaCrContext _context;
        public RolesDAL(AlquilaCrContext context) : base(context)
        {
            _context = context;
        }
    }
}

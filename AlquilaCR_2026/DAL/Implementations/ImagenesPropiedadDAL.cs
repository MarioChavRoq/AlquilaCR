using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class ImagenesPropiedadDAL : DALGenerico<ImagenesPropiedad>, IImagenesPropiedadDAL
    {
        private AlquilaCrContext _context;

        public ImagenesPropiedadDAL(AlquilaCrContext context) : base(context)
        {
            _context = context;
        }
    }
}
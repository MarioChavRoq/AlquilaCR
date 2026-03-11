using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IImagenesPropiedadService
    {
        List<ImagenesPropiedadDTO> GetImagenes();
        ImagenesPropiedadDTO GetById(int id);
        ImagenesPropiedadDTO Add(ImagenesPropiedadDTO imagen);
        ImagenesPropiedadDTO Update(ImagenesPropiedadDTO imagen);
        void Delete(int id);
    }
}
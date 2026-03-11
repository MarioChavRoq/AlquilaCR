using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IPropiedadService
    {
        List<PropiedadesDTO> GetPropiedades();
        PropiedadesDTO GetById(int id);
        PropiedadesDTO Add(PropiedadesDTO propiedades);
        void Delete(int id);
        PropiedadesDTO Update(PropiedadesDTO propiedades);
    }
}

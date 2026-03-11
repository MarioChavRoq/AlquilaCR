using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class PropiedadService : IPropiedadService
    {
        IUnidadDeTrabajo _Unidad;

        public PropiedadService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _Unidad = unidadDeTrabajo;
        }

        PropiedadesDTO Convertir(Propiedade propiedades)
        {
            var usuarioPropiedad = _Unidad.UsuariosDAL.Get((int)propiedades.PropietarioId);
            return new PropiedadesDTO
            {
                PropiedadId = propiedades.PropiedadId,
                PropietarioId = propiedades.PropietarioId,
                Nombre = usuarioPropiedad.Nombre,
                Titulo = propiedades.Titulo,
                Descripcion = propiedades.Descripcion,
                PrecioMensual = propiedades.PrecioMensual,
                Provincia = propiedades.Provincia,
                Canton = propiedades.Canton,
                DireccionExacta = propiedades.DireccionExacta,
                TipoPropiedad = propiedades.TipoPropiedad,
                MesesMinimosAlquiler = propiedades.MesesMinimosAlquiler,
                Disponible = propiedades.Disponible
            };
        }


        Propiedade Convertir(PropiedadesDTO propiedades)
        {
            return new Propiedade
            {
                PropiedadId = propiedades.PropiedadId,
                PropietarioId = propiedades.PropietarioId,
                Titulo = propiedades.Titulo,
                Descripcion = propiedades.Descripcion,
                PrecioMensual = propiedades.PrecioMensual,
                Provincia = propiedades.Provincia,
                Canton = propiedades.Canton,
                DireccionExacta = propiedades.DireccionExacta,
                TipoPropiedad = propiedades.TipoPropiedad,
                MesesMinimosAlquiler = propiedades.MesesMinimosAlquiler,
                Disponible = propiedades.Disponible
            };
        }

        public PropiedadesDTO Add(PropiedadesDTO propiedades)
        {
            try
            {
                _Unidad.PropiedadesDAL.Add(Convertir(propiedades));
                _Unidad.Complete();
                return propiedades;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            Propiedade propiedades = new Propiedade { PropiedadId = id };
            _Unidad.PropiedadesDAL.Remove(propiedades);
            _Unidad.Complete();
        }

        public PropiedadesDTO GetById(int id)
        {
            var propiedades = _Unidad.PropiedadesDAL.Get(id);
            return Convertir(propiedades);
        }

        public List<PropiedadesDTO> GetPropiedades()
        {
            var propiedades = _Unidad.PropiedadesDAL.GetAll();
            List<PropiedadesDTO> propiedadesList = new List<PropiedadesDTO>();
            foreach (var propiedade in propiedades)
            {
                propiedadesList.Add(Convertir(propiedade));
            }
            return propiedadesList;
        }

        public PropiedadesDTO Update(PropiedadesDTO propiedades)
        {
            try
            {
                _Unidad.PropiedadesDAL.Update(Convertir(propiedades));
                _Unidad.Complete();
                return propiedades;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}

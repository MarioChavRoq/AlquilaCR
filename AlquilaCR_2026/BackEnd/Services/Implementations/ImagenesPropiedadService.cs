using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ImagenesPropiedadService : IImagenesPropiedadService
    {
        IUnidadDeTrabajo _Unidad;

        public ImagenesPropiedadService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _Unidad = unidadDeTrabajo;
        }

        ImagenesPropiedadDTO Convertir(ImagenesPropiedad imagen)
        {
            var propiedad = _Unidad.PropiedadesDAL.Get(imagen.PropiedadId);

            return new ImagenesPropiedadDTO
            {
                ImagenId = imagen.ImagenId,
                PropiedadId = imagen.PropiedadId,
                TituloPropiedad = propiedad.Titulo,
                Orden = imagen.Orden,
                UrlImagen = imagen.UrlImagen
            };
        }

        ImagenesPropiedad Convertir(ImagenesPropiedadDTO imagen)
        {
            return new ImagenesPropiedad
            {
                ImagenId = imagen.ImagenId,
                PropiedadId = imagen.PropiedadId,
                Orden = imagen.Orden,
                UrlImagen = imagen.UrlImagen
            };
        }

        public ImagenesPropiedadDTO Add(ImagenesPropiedadDTO imagen)
        {
            try
            {
                var imagenesPropiedad = _Unidad.ImagenesPropiedadDAL
                    .GetAll()
                    .Where(i => i.PropiedadId == imagen.PropiedadId)
                    .ToList();

                int nuevoOrden = 1;

                if (imagenesPropiedad.Any())
                {
                    nuevoOrden = imagenesPropiedad.Max(i => i.Orden) + 1;
                }

                imagen.Orden = nuevoOrden;

                _Unidad.ImagenesPropiedadDAL.Add(Convertir(imagen));
                _Unidad.Complete();

                return imagen;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            ImagenesPropiedad imagen = new ImagenesPropiedad { ImagenId = id };

            _Unidad.ImagenesPropiedadDAL.Remove(imagen);
            _Unidad.Complete();
        }

        public ImagenesPropiedadDTO GetById(int id)
        {
            var imagen = _Unidad.ImagenesPropiedadDAL.Get(id);
            return Convertir(imagen);
        }

        public List<ImagenesPropiedadDTO> GetImagenes()
        {
            var imagenes = _Unidad.ImagenesPropiedadDAL.GetAll().OrderBy(i => i.Orden);

            List<ImagenesPropiedadDTO> lista = new List<ImagenesPropiedadDTO>();

            foreach (var imagen in imagenes)
            {
                lista.Add(Convertir(imagen));
            }

            return lista;
        }

        public ImagenesPropiedadDTO Update(ImagenesPropiedadDTO imagen)
        {
            try
            {
                _Unidad.ImagenesPropiedadDAL.Update(Convertir(imagen));
                _Unidad.Complete();
                return imagen;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
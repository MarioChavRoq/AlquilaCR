using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenesPropiedadController : ControllerBase
    {
        IImagenesPropiedadService _imagenesService;

        public ImagenesPropiedadController(IImagenesPropiedadService imagenesService)
        {
            this._imagenesService = imagenesService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _imagenesService.GetImagenes();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _imagenesService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public void Post([FromBody] ImagenesPropiedadDTO imagen)
        {
            _imagenesService.Add(imagen);
        }

        [HttpPut]
        public void Put([FromBody] ImagenesPropiedadDTO imagen)
        {
            _imagenesService.Update(imagen);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _imagenesService.Delete(id);
        }
    }
}
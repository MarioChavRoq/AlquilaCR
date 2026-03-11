using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadesController : ControllerBase
    {
        IPropiedadService _propiedadService;

        public PropiedadesController(IPropiedadService propiedadService)
        {
            this._propiedadService = propiedadService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _propiedadService.GetPropiedades();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _propiedadService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public void Post([FromBody] PropiedadesDTO propiedadesDTO)
        {
            _propiedadService.Add(propiedadesDTO);
        }

        [HttpPut]
        public void Put([FromBody] PropiedadesDTO propiedades)
        {
            _propiedadService.Update(propiedades);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _propiedadService.Delete(id);
        }
    }
}

using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var usuarios = _usuarioService.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var usuarios = _usuarioService.GetById(id);
            return Ok(usuarios);
        }

        [HttpPost]
        public void Post([FromBody] UsuarioDTO usuarioDTO)
        {
            _usuarioService.Add(usuarioDTO);
        }

        [HttpPut]
        public void Put([FromBody] UsuarioDTO usuarioDTO)
        {
            _usuarioService.Update(usuarioDTO);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _usuarioService.Delete(id);
        }
    }
}
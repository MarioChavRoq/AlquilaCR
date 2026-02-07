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
        public IEnumerable<UsuarioDTO> Get()
        {
            return _usuarioService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public UsuarioDTO Get(int id)
        {
            return _usuarioService.GetUserById(id);
        }

        [HttpPost]
        public void Post([FromBody] UsuarioDTO usuario)
        {
            _usuarioService.CreateUser(usuario);
        }

        [HttpPut]
        public void Put([FromBody] UsuarioDTO usuario)
        {
            _usuarioService.UpdateUser(usuario);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _usuarioService.DeleteUser(id);
        }
    }
}
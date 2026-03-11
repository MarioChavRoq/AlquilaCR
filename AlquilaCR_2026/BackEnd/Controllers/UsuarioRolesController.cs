using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRolesController : ControllerBase
    {
        IUsuarioRoleService _usuarioRoleService;

        public UsuarioRolesController(IUsuarioRoleService usuarioRoleService)
        {
            this._usuarioRoleService = usuarioRoleService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _usuarioRoleService.GetUsuarioRoles();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _usuarioRoleService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public void Post([FromBody] UsuarioRolesDTO usuarioRolesDTO)
        {
            _usuarioRoleService.Add(usuarioRolesDTO);
        }

        [HttpPut]
        public void Put([FromBody] UsuarioRolesDTO usuarioRoles)
        {
            _usuarioRoleService.Update(usuarioRoles);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _usuarioRoleService.Delete(id);
        }


    }
}

using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            this._roleService = roleService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _roleService.GetRoles();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _roleService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public void Post([FromBody] RolesDTO rolesDTO)
        {
            _roleService.Add(rolesDTO);
        }

        [HttpPut]
        public void Put([FromBody] RolesDTO roles)
        {
            _roleService.Update(roles);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _roleService.Delete(id);
        }
    }
}

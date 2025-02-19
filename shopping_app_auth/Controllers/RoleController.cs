using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopping_app_auth.Model.Models;
using shopping_app_auth.Services.Interfaces;

namespace shopping_app_auth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ILoggerService _loggerService;

        public RoleController(IRoleService roleService, ILoggerService loggerService)
        {
            _roleService = roleService;
            _loggerService = loggerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] Role role)
        {
            try
            {
                var createdRole = await _roleService.CreateRole(role);
                if (createdRole == null) return BadRequest("Role name cannot be empty.");

                return Ok(createdRole);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("An error occurred while creating the role.", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the role.");
            }
        }

        [HttpDelete("{roleId}")]
        public async Task<ActionResult> DeleteRole([FromRoute] int roleId)
        {
            try
            {
                var isDeleted = await _roleService.DeleteRole(roleId);
                if (!isDeleted) return NotFound("Role not found.");

                return Ok("Role deleted successfully.");
            }
            catch (Exception ex)
            {
                _loggerService.LogError("An error occurred while deleting the role.", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the role.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromBody] Role role)
        {
            try
            {
                var isUpdated = await _roleService.UpdateRole(role);
                if (!isUpdated) return NotFound("Role not found.");

                return Ok("Role updated successfully.");
            }
            catch (Exception ex)
            {
                _loggerService.LogError("An error occurred while updating the role.", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the role.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var roles = await _roleService.GetAll();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("An error occurred while getting all the roles.", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while getting all the roles.");
            }
        }

        [HttpGet("{roleId}")]
        public async Task<ActionResult<Role>> GetRoleByID([FromRoute] int roleId) {
            try
            {
                var role = await _roleService.GetRoleById(roleId);
                return Ok(role);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("An error occurred while getting the role.", ex);
                return StatusCode(StatusCodes.Status404NotFound, "No role was found with that ID.");
            }
        }
    }
}
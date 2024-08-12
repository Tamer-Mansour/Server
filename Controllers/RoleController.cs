using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server.DTOs.RoleDTOs;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly UserManager<User> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<ActionResult> CreateRole([FromBody] CreateRoleDto createRoleDto)
        {
            if (string.IsNullOrEmpty(createRoleDto.RoleName))
            {
                return BadRequest("Role name is required");
            }
            var roleExist = await _roleManager.RoleExistsAsync(createRoleDto.RoleName);
            if (roleExist)
            {
                return BadRequest("Role Already Exist");
            }
            var roleResult = await _roleManager.CreateAsync(new IdentityRole(createRoleDto.RoleName));
            if (roleResult.Succeeded)
            {
                return Ok(new { message = "Role created successfully" });
            }
            return BadRequest("Role creation faild");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            var roleDtos = roles.Select(role => new RoleDto
            {
                RoleID = role.Id,
                RoleName = role.Name
            }).ToList();

            return Ok(roleDtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetRoleById(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var roleDto = new RoleDto
            {
                RoleID = role.Id,
                RoleName = role.Name
            };

            return Ok(roleDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRole(string id, [FromBody] UpdateRoleDto updateRoleDto)
        {
            if (string.IsNullOrEmpty(updateRoleDto.RoleName))
            {
                return BadRequest("Role name is required");
            }

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            role.Name = updateRoleDto.RoleName;
            var roleResult = await _roleManager.UpdateAsync(role);

            if (roleResult.Succeeded)
            {
                return Ok(new { message = "Role updated successfully" });
            }

            return BadRequest("Role update failed");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var roleResult = await _roleManager.DeleteAsync(role);
            if (roleResult.Succeeded)
            {
                return Ok(new { message = "Role deleted successfully" });
            }

            return BadRequest("Role deletion failed");
        }

    }
}

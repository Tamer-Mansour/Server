using System.ComponentModel.DataAnnotations;

namespace Server.DTOs.RoleDTOs
{
    public class CreateRoleDto
    {
        [Required(ErrorMessage = "Role name is required")]
        public string? RoleName { get; set; }
    }
}

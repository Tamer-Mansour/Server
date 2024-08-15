using System.ComponentModel.DataAnnotations;

namespace Server.DTOs.UserDTOs
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}

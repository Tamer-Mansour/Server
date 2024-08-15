﻿using System.ComponentModel.DataAnnotations;

namespace Server.DTOs.UserDTOs
{
    public class ChangePasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required]
        public string NewPasseord { get; set; } = string.Empty;

    }
}

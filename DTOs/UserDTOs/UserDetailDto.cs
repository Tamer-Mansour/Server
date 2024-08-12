namespace Server.DTOs.UserDTOs
{
    public class UserDetailDto
    {
        public string? Id { get; set; }
        public string? FUllName { get; set; }

        public string? Email { get; set; }
        public string[]? Roles { get; set; }
        public string? PhoneNumber { get; set; }

        public string? TowFactorEnabled { get; set; }
        public string? PhoneNumberConfirmed { get; set; }
        public int? AccessFailedCount { get; set; }
    }
}

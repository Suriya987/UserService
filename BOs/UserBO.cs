namespace UserService.BOs
{
    public class UserBO
    {
        public long UserId { get; set; }
        public string DisplayName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? ProfileImageUrl { get; set; }

        public string Password { get; set; }
    }
}

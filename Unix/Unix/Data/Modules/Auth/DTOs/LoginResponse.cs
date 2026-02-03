namespace Unix.Data.Modules.Auth.DTOs
{
    public class LoginResponse
    {
        public bool Success { get; set; } = true;
        public UserDto User { get; set; } = null!;
        public string Token { get; set; } = string.Empty;
        public int ExpiresIn { get; set; }
    }
}

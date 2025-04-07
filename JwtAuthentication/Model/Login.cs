namespace JwtAuthentication.Model
{
    public class Login
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? LoginId { get; set; }
        public string? Role { get; set; }
    }
}


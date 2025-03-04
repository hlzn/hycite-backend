namespace Hycite.APIModels;

public class AuthenticateAPIModels
{
    public class Request
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public class Response
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public required string Token { get; set; }
    }
}

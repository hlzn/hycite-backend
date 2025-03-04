namespace Hycite.APIModels;

public partial class BaseAPIModels<T>
{
    public partial class Request
    {
        public required T Data { get; set; }
    }

    public class Response
    {
        public required bool Success { get; set; }
        public string? Error { get; set; }
        public required T Data { get; set; }
    }
}
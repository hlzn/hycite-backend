using Hycite.Models;

namespace Hycite.APIModels;

public class UserAPIModel : BaseAPIModels<User>
{
    public partial class Request : BaseAPIModels<User>.Request
    {
        public required string Password { get; set; }
        public required string Email { get; set; }
    }

    public partial class Response : BaseAPIModels<User>.Response
    {}
}
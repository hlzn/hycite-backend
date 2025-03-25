using Hycite.Models;
using Hycite.DTOs;

namespace Hycite.APIModels;

public class UserAPIModel 
{
    public partial class Request 
    {
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Phone { get; set; }
        public int AccessLevelId { get; set; }

    }

    public partial class Response : BaseAPIModels<UserCreatedDTO>.Response
    {}
}
using Hycite.Models;
using FastEndpoints;
using Hycite.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Hycite.APIModels;
using hlzn.util;


namespace Hycite.Endpoints;

public class UserEndpoints : Endpoint<UserAPIModel.Request, UserAPIModel.Response>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserSecurityRepository _userSecurityRepository;
    private readonly char[] _jwtSecret;

    public UserEndpoints(IUserRepository userRepository, IUserSecurityRepository userSecurityRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _userSecurityRepository = userSecurityRepository;
        _jwtSecret = configuration["Jwt:Key"]?.ToCharArray() ?? throw new ArgumentNullException("Jwt:Key");
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/user");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UserAPIModel.Request request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Phone = request.Phone,
            DateHired = DateTime.UtcNow.ToDateOnly(), // Set appropriate value
            OnboardingDate = DateTime.UtcNow.ToDateOnly() // Set appropriate value
        };

        await _userRepository.AddAsync(user);

        var userSecurity = new UserSecurity
        {
            Password = request.Password,
            Salt = new Guid().ToString(),
            Email = request.Email,
            UserId = user.Id,
            CreatedBy = 0 // TODO: Decide how to handle this
        };
        await _userSecurityRepository.AddAsync(userSecurity);
        Response = new UserAPIModel.Response
        {
            Success = true,
            Data = new DTOs.UserCreatedDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = userSecurity.Email
            }
        };
        await SendAsync(Response);
    }
}
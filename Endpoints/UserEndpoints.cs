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

    public UserEndpoints(IUserRepository userRepository, IUserSecurityRepository userSecurityRepository, char[] jwtSecret)
    {
        _userRepository = userRepository;
        _userSecurityRepository = userSecurityRepository;
        _jwtSecret = jwtSecret;
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
            FirstName = request.Data.FirstName,
            LastName = request.Data.LastName,
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
            Data = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateHired = user.DateHired,
                OnboardingDate = user.OnboardingDate
            }
        };
        await SendAsync(Response);
    }
}
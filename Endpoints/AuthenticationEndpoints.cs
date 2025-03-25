using FastEndpoints;
using Hycite.Repositories;
using System.Security.Claims;
using hlzn.util;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApiModel = Hycite.APIModels.AuthenticateAPIModels;

namespace Hycite.Endpoints;

public class Authenticate : Endpoint<ApiModel.Request, ApiModel.Response>
{
    private IUserSecurityRepository _userSecurityRepository;
    private IUserRepository _userRepository;
    private char[] _jwtSecret;

    public Authenticate(IUserSecurityRepository userSecurityRepository, IUserRepository userRepository, IConfiguration configuration)
    {
        _userSecurityRepository = userSecurityRepository;
        _userRepository = userRepository;
        var secret = configuration["Jwt:Key"]?.ToCharArray() ?? throw new ArgumentNullException("Jwt:Key");
        _jwtSecret = secret;        
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/authenticate");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ApiModel.Request request, CancellationToken cancellationToken)
    {
        // Authenticate user
        var userSecurity = await _userSecurityRepository.GetByEmailAsync(request.Username);
        if (userSecurity == null || !request.Password.HasValidPassword(userSecurity.Password, Convert.FromHexString(userSecurity.Salt)))
        {
            return;
        }
        // Get user
        var user = await _userRepository.GetByIdAsync(userSecurity.UserId);
        if (user == null)
        {
            return;
        }
        // Generate Authentication token
        var token = GenerateJwtToken(user, userSecurity);
        Response = new ApiModel.Response
        {
            Token = token
        };
        await SendAsync(Response);        
    }

    private string GenerateJwtToken(Models.User user, Models.UserSecurity userSecurity)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.Email, userSecurity.Email),
            new Claim(ClaimTypes.Role, "User") //TODO: Where is the role?
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "Hycite",
            audience: "HyciteUsers",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;
using SimpleBlog.Domain.Providers;
using SimpleBlog.Infra.Data.Authorization;
using SimpleBlog.Infra.Data.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleBlog.Application.Services;

public class LoginService(IUserService userService, IOptions<JwtOptions> jwtOptions, AppDatabaseContext appDatabaseContext) : ILoginService
{
    private readonly IUserService _userService = userService;
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;
    private readonly AppDatabaseContext _dbContext = appDatabaseContext;

    private string GerarTokenJWT(UserViewModel user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Exp, DateTime.Now.AddMinutes(120).ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims,
            null,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }

    public string Login(LoginViewModel loginViewModel)
    {
        var errorMessage = "Usuário ou senha incorretos";

        var user = _userService.GetUserByUsername(loginViewModel.UserName) ?? throw new InvalidDataException(errorMessage);

        var validPassword = PasswordHasher.VerifyPassword(loginViewModel.Password, user.Password);
        if (!validPassword)
            throw new InvalidDataException(errorMessage);

        var token = GerarTokenJWT(user);
        return token;
    }
}

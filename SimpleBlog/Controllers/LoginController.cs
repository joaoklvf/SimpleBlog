using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;

namespace SimpleBlog.Api.Controllers;

[Route("api/login")]
public class LoginController(ILoginService loginService) : ControllerBase
{
    private readonly ILoginService _loginService = loginService;

    [HttpPost]
    public IActionResult Login([FromBody] LoginViewModel loginViewModel)
    {
        var token = _loginService.Login(loginViewModel);

        if (string.IsNullOrEmpty(token))
            return Unauthorized();

        return Ok(new { token });
    }
}

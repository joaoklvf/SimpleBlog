using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleBlog.Api.Controllers;

[Route("api/users")]
[ApiController]
[Authorize]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    public IActionResult Get()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateUser([FromBody] UserViewModel user)
    {
        var userCreated = await _userService.Add(user);
        return CreatedAtAction(nameof(CreateUser), new { id = userCreated.Id }, userCreated);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UserViewModel user)
    {
        user.Id = id;
        var userUpdated = await _userService.Edit(user);

        return userUpdated is null ? NotFound("User não encontrado") : Ok(userUpdated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userLoggedId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var isUserDeleted = await _userService.Remove(id, userLoggedId);
        return isUserDeleted ? Ok() : BadRequest();
    }
}

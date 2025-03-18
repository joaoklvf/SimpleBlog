using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleBlog.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;
    // GET: api/<ValuesController>
    [HttpGet]
    public IActionResult Get()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public IActionResult Get(Guid id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }

    // POST api/<ValuesController>
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserViewModel user)
    {
        var userCreated = await _userService.Add(user);
        return CreatedAtAction(nameof(CreateUser), new { id = userCreated.Id }, userCreated);
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UserViewModel user)
    {
        user.Id = id;
        var userUpdated = await _userService.Edit(user);

        return userUpdated is null ? NotFound("User não encontrado") : Ok(userUpdated);
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var isUserDeleted = await _userService.Remove(id);
        return isUserDeleted ? Ok() : BadRequest();
    }
}

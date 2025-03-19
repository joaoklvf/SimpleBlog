using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;
using System.Security.Authentication;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleBlog.Api.Controllers;

[Route("api/posts")]
[Authorize]
[ApiController]
public class PostController(IPostService postService) : ControllerBase
{
    private readonly IPostService _postService = postService;

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get()
    {
        var posts = _postService.GetAll();
        return Ok(posts);
    }

    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var post = _postService.GetById(id);
        return Ok(post);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] PostViewModel post)
    {
        var userLoggedId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!post.AuthorId.ToString().Equals(userLoggedId))
            throw new InvalidCredentialException("O usuário logado corresponde ao usuário informado na requisição.");

        var postCreated = await _postService.Add(post);
        return CreatedAtAction(nameof(CreatePost), new { id = postCreated.Id }, postCreated);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] PostViewModel post)
    {
        var userLoggedId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!post.AuthorId.ToString().Equals(userLoggedId))
            throw new InvalidCredentialException("O usuário logado corresponde ao usuário informado na requisição.");

        post.Id = id;
        var postUpdated = await _postService.Edit(post);

        return postUpdated is null ? NotFound("Post não encontrado") : Ok(postUpdated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userLoggedId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var isPostDeleted = await _postService.Remove(id, userLoggedId);
        return isPostDeleted ? Ok() : BadRequest();
    }
}

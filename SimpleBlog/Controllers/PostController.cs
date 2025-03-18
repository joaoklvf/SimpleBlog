using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleBlog.Api.Controllers;

[Route("api/posts")]
[ApiController]
public class PostController(IPostService postService) : ControllerBase
{
    private readonly IPostService _postService = postService;
    // GET: api/<ValuesController>
    [HttpGet]
    public IActionResult Get()
    {
        var posts = _postService.GetAll();
        return Ok(posts);
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public IActionResult Get(Guid id)
    {
        var post = _postService.GetById(id);
        return Ok(post);
    }

    // POST api/<ValuesController>
    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] PostViewModel post)
    {
        var postCreated = await _postService.Add(post);
        return CreatedAtAction(nameof(CreatePost), new { id = postCreated.Id }, postCreated);
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] PostViewModel post)
    {
        post.Id = id;
        var postUpdated = await _postService.Edit(post);

        return postUpdated is null ? NotFound("Post não encontrado") : Ok(postUpdated);
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var isPostDeleted = await _postService.Remove(id);
        return isPostDeleted ? Ok() : BadRequest();
    }
}

using AutoMapper;
using SimpleBlog.Application.Commands.PostCommand;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;
using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Application.Services;

public class PostService(IMapper mapper, IPostRepository userRepository, IEventBus bus) : IPostService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPostRepository _userRepository = userRepository;
    private readonly IEventBus _bus = bus;

    public IEnumerable<PostViewModel> GetAll() =>
        _mapper.Map<IEnumerable<PostViewModel>>(_userRepository.GetAll());

    public PostViewModel? GetById(Guid id) =>
         _mapper.Map<PostViewModel?>(_userRepository.GetById(id));

    public async Task<bool> Remove(Guid id) { 
        var deletedPost = await _bus.Send<DeletePostCommand, Post>(new DeletePostCommand(id));
        return deletedPost != null;
    }

    public async Task<PostViewModel> Add(PostViewModel user)
    {
        var createPostCommand = _mapper.Map<CreatePostCommand>(user);
        var postCreated = await _bus.Send<CreatePostCommand, Post>(createPostCommand);

        return _mapper.Map<PostViewModel>(postCreated);
    }

    public async Task<PostViewModel> Edit(PostViewModel user)
    {
        var updatePostCommand = _mapper.Map<UpdatePostCommand>(user);
        var postUpdated = await _bus.Send<UpdatePostCommand, Post>(updatePostCommand);

        return _mapper.Map<PostViewModel>(postUpdated);
    }
}

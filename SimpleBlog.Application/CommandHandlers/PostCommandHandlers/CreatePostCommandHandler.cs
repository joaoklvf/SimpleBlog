using MediatR;
using SimpleBlog.Application.Commands.PostCommand;
using SimpleBlog.Application.Notifications;
using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Domain.Interfaces.Base;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Application.CommandHandlers.PostCommandHandlers;

public class CreatePostCommandHandler(IUnitOfWork unitOfWork, IEventBus bus) : IRequestHandler<CreatePostCommand, Post>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IEventBus _bus = bus;

    public async Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var user = _unitOfWork.UserRepository.GetById(request.AuthorId) ?? throw new InvalidOperationException("Autor não encontrado.");
        var newPost = new Post(Guid.NewGuid(), user, request.Title, request.Content);

        _unitOfWork.PostRepository.Create(newPost);

        await _unitOfWork.CommitAsync();

        var postNofication = new PostNotification(newPost);

        await _bus.Publish(postNofication);

        return newPost;
    }
}

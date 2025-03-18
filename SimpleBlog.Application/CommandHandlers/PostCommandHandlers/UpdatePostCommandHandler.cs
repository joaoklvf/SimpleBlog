using MediatR;
using SimpleBlog.Application.Commands.PostCommand;
using SimpleBlog.Domain.Interfaces.Base;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Application.CommandHandlers.PostCommandHandlers;

public class UpdatePostCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdatePostCommand, Post>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Post> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        _ = _unitOfWork.PostRepository.GetById(request.Id) ?? throw new InvalidOperationException("Post não encontrado.");
        _ = _unitOfWork.UserRepository.GetById(request.AuthorId) ?? throw new InvalidOperationException("Autor não encontrado.");

        var newPost = new Post(request.Id, request.AuthorId, request.Title, request.Content);

        _unitOfWork.PostRepository.Update(newPost);

        await _unitOfWork.CommitAsync();
        return newPost;
    }
}

using MediatR;
using SimpleBlog.Application.Commands.PostCommand;
using SimpleBlog.Domain.Interfaces.Base;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Application.CommandHandlers.PostCommandHandlers;

public class DeletePostCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeletePostCommand, Post>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Post> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            throw new InvalidOperationException("O ID não pode estar vazio.");

        var post =
            _unitOfWork.PostRepository.GetById(request.Id) ?? throw new InvalidOperationException("Post não encontrado.");

        _unitOfWork.PostRepository.Delete(post);

        await _unitOfWork.CommitAsync();
        return post;
    }
}

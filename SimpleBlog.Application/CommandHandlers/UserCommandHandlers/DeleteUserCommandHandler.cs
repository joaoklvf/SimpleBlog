using MediatR;
using SimpleBlog.Application.Commands.UserCommand;
using SimpleBlog.Domain.Interfaces.Base;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Application.CommandHandlers.UserCommandHandlers;

public class DeleteUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserCommand, User>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            throw new InvalidOperationException("O ID não pode estar vazio.");

        var user =
            _unitOfWork.UserRepository.GetById(request.Id) ?? throw new InvalidOperationException("Usuário não encontrado.");

        _unitOfWork.UserRepository.Delete(user);

        await _unitOfWork.CommitAsync();
        return user;
    }
}

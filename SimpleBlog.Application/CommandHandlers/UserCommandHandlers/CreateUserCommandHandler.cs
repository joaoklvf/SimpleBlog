using MediatR;
using SimpleBlog.Application.Commands.UserCommand;
using SimpleBlog.Domain.Interfaces.Base;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Application.CommandHandlers.UserCommandHandlers;

public class CreateUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateUserCommand, User>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var hasAnyUserByEmail = _unitOfWork.UserRepository.HasAnyUserByEmail(request.Email);

        if (hasAnyUserByEmail)
            throw new Exception("Já existe um usuário cadastrado com este e-mail.");

        var newUser = new User(Guid.NewGuid(), request.Name, request.Email, request.UserName, request.Password, request.BirthDate);

        _unitOfWork.UserRepository.Create(newUser);

        await _unitOfWork.CommitAsync();
        return newUser;
    }
}

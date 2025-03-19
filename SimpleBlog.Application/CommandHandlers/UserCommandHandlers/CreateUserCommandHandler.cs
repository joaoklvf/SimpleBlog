using MediatR;
using SimpleBlog.Application.Commands.UserCommand;
using SimpleBlog.Domain.Interfaces.Base;
using SimpleBlog.Domain.Models;
using SimpleBlog.Domain.Providers;

namespace SimpleBlog.Application.CommandHandlers.UserCommandHandlers;

public class CreateUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateUserCommand, User>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = _unitOfWork.UserRepository.GetUserByEmailOrUserName(request.Email, request.UserName);
        if (existingUser is not null)
            throw new Exception("Já existe um usuário cadastrado com este e-mail ou nome de usuário.");

        var newUser = new User(Guid.NewGuid(), request.UserName, PasswordHasher.HashPassword(request.Password), request.Name, request.Email, request.BirthDate);

        _unitOfWork.UserRepository.Create(newUser);

        await _unitOfWork.CommitAsync();
        return newUser;
    }
}

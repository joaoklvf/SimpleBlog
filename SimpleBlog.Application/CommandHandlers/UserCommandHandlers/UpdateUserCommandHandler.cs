using MediatR;
using SimpleBlog.Application.Commands.UserCommand;
using SimpleBlog.Domain.Interfaces.Base;
using SimpleBlog.Domain.Models;
using SimpleBlog.Domain.Providers;

namespace SimpleBlog.Application.CommandHandlers.UserCommandHandlers;

class UpdateUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateUserCommand, User>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = _unitOfWork.UserRepository.GetUserByEmailOrUserName(request.Email, request.UserName);
        if (existingUser is not null && existingUser.Id != request.Id)
            throw new Exception("Já existe um usuário cadastrado com este e-mail.");

        _ = _unitOfWork.UserRepository.GetById(request.Id) ?? throw new InvalidOperationException("Usuário não encontrado.");

        var newUser = new User(request.Id, request.UserName, PasswordHasher.HashPassword(request.Password), request.Name, request.Email, request.BirthDate);

        _unitOfWork.UserRepository.Update(newUser);

        await _unitOfWork.CommitAsync();
        return newUser;
    }
}

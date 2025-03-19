using AutoMapper;
using SimpleBlog.Application.Commands.UserCommand;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;
using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Application.Services;

public class UserService(IMapper mapper, IUserRepository userRepository, IEventBus bus) : IUserService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IEventBus _bus = bus;

    public IEnumerable<UserViewModel> GetAll() =>
        _mapper.Map<IEnumerable<UserViewModel>>(_userRepository.GetAll());

    public UserViewModel? GetById(Guid id) =>
         _mapper.Map<UserViewModel?>(_userRepository.GetById(id));

    public async Task<bool> Remove(Guid id, string userLoggedInId)
    {
        var deletedUser = await _bus.Send<DeleteUserCommand, User>(new DeleteUserCommand(id, userLoggedInId));
        return deletedUser != null;
    }

    public async Task<UserViewModel> Add(UserViewModel user)
    {
        var createUserCommand = _mapper.Map<CreateUserCommand>(user);
        var userCreated = await _bus.Send<CreateUserCommand, User>(createUserCommand);

        return _mapper.Map<UserViewModel>(userCreated);
    }

    public async Task<UserViewModel> Edit(UserViewModel user)
    {
        var updateUserCommand = _mapper.Map<UpdateUserCommand>(user);
        var userUpdated = await _bus.Send<UpdateUserCommand, User>(updateUserCommand);

        return _mapper.Map<UserViewModel>(userUpdated);
    }

    public UserViewModel? GetUserByUsername(string username) =>
         _mapper.Map<UserViewModel?>(_userRepository.GetByUsername(username));
}

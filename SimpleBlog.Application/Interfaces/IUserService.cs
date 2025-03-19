using SimpleBlog.Application.Interfaces.Base;
using SimpleBlog.Application.ViewModels;

namespace SimpleBlog.Application.Interfaces;

public interface IUserService : IRepositoryService<UserViewModel>
{
    public UserViewModel? GetUserByUsername(string username);
}
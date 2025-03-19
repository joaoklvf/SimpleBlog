using SimpleBlog.Application.ViewModels;

namespace SimpleBlog.Application.Interfaces;

public interface ILoginService
{
    string Login(LoginViewModel loginViewModel);
}
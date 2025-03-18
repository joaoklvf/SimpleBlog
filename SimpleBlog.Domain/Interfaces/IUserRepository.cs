using SimpleBlog.Domain.Interfaces.Base;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Check if there is any user registered with <paramref name="email"/>
    /// </summary>
    /// <param name="email"></param>
    /// <returns>True if has any user with the email; otherwise, false.</returns>
    public bool HasAnyUserByEmail(string email);
}

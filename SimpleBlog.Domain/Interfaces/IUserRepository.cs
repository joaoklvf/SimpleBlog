using SimpleBlog.Domain.Interfaces.Base;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Check if there is any user registered with <paramref name="email"/>
    /// </summary>
    /// <param name="email">User e-mail</param>
    /// <param name="username">User username</param>
    /// <returns>True if has any user with the e-mail or username; otherwise, false.</returns>
    public User? GetUserByEmailOrUserName(string email, string username);
    
    /// <summary>
    /// Get user by username.
    /// </summary>
    /// <param name="username">User username</param>
    /// <returns>An possible user.</returns>
    public User? GetByUsername(string username);
}

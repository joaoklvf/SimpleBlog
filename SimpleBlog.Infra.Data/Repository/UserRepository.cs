using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Domain.Models;
using SimpleBlog.Infra.Data.Context;
using SimpleBlog.Infra.Data.Repository.Base;

namespace SimpleBlog.Infra.Data.Repository;

public class UserRepository(AppDatabaseContext context) : Repository<User>(context), IUserRepository
{
    public User? GetByUsername(string username) =>
        _dbSet.FirstOrDefault(x=> x.UserName.Equals(username));

    public User? GetUserByEmailOrUserName(string email, string userName) =>
         _dbSet.FirstOrDefault(x => x.Email.Equals(email) || x.UserName.Equals(userName));
}


using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Domain.Models;
using SimpleBlog.Infra.Data.Context;
using SimpleBlog.Infra.Data.Repository.Base;

namespace SimpleBlog.Infra.Data.Repository;

public class UserRepository(AppDatabaseContext context) : Repository<User>(context), IUserRepository
{
    public bool HasAnyUserByEmail(string email) =>
         _dbSet.Any(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
}

